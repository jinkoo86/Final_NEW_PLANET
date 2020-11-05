using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.UI;

public class NPCCustomer : MonoBehaviour {
    public enum State {
        Search,
        Move,
        Wait,
        Good,
        Bad,
        Run
    }
    public State state;

    public float speed = 5.0f;  //이동속도(public이라 인스펙터에서 적절한값으로 수정)
    Vector3 dir;                //이동할 방향

    public Animator anim;
    public GameObject targetObject;
    public Text myNum;
    public Canvas myCanvas;

    int foodPrice;
    public int FoodPrice {
        get { return foodPrice; }
        set {
            foodPrice = value;
        }
    }

    public List<int> emptyTableCheck = new List<int>();
    public int myTableNum = 0;
    public int myCustomerNum;

    void Start() {
        state = State.Search;
        //emptyTableCheck.Clear();
        //내 손님번호는 NPCSpawnManager에서 가져온후 뒤의 고객을위해 증가시킴
        myCustomerNum = NPCSpawnManager.Instance.customerNum++;
    }
    // Update is called once per frame
    void Update() {
        //Debug.Log("myname: "+transform.name +", myState: " + state);
        switch (state) {
            case State.Search: UpdateSearch(); break;
            case State.Move: UpdateMove(); break;
            case State.Wait: UpdateWait(); break;
            case State.Good: UpdateGood(); break;
            case State.Bad: UpdateBad(); break;
            case State.Run: UpdateRun(); break;
        }
    }



    private void OnTriggerEnter(Collider other) {
        if (other.tag == "CHECK") {
            myCanvas.gameObject.SetActive(true);
            //도착하면 그자리에 정지 후
            //랜덤돌려서 주문
            myNum.text = myCustomerNum.ToString();
            //checkFoodChild에서 order상태로 변경
            state = State.Wait;
        }
        if (other.tag == "EXIT") {
            //print("exit 진입");
            if (GameObject.FindWithTag("ROBBER")) {
                Destroy(gameObject, 0);
            }
            else {
                NPCSpawnManager.Instance.emptyTableList[myTableNum] = true;
                Destroy(gameObject, 0);
            }
        }
    }

    //빈 테이블을 찾기위해 돌리는 랜덤함수
    private int GetRandomNumber() {
        var exclude = new HashSet<int>(emptyTableCheck);
        var range = Enumerable.Range(0, 5).Where(i => !exclude.Contains(i));
        var rand = new System.Random();
        int index = rand.Next(0, 5 - exclude.Count);
        return range.ElementAt(index);
    }

    // - 목적지를 찾는 상태
    private void UpdateSearch() {
        //시작하자마자 빈 테이블을 찾음
        for (int i = 0; i < NPCSpawnManager.Instance.emptyTableList.Count; i++) {
            if (NPCSpawnManager.Instance.emptyTableList[i] == false) {
                emptyTableCheck.Add(i);
            }
        }
        myTableNum = GetRandomNumber();
        targetObject = NPCSpawnManager.Instance.TableList[myTableNum];
        NPCSpawnManager.Instance.emptyTableList[myTableNum] = false;
        //print("손님 생성, 위치:" + targetObject.name);
        //print("남은번호:" + NPCSpawnManager.Instance.TableList.Count);
        if (targetObject != null) {
            //print(targetObject.name);
            //이동상태로 전이
            state = State.Move;
        }
    }
    private void UpdateMove() {
        //customer의 목적지를 타겟으로
        dir = targetObject.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        //움직이는 애니메이션도 필요
    }

    private void UpdateWait() {

    }
    private void UpdateGood() {
        //돈 올리고 손님카운트 1개 제거
        //근데 음식별 돈이 또 따로 있음
        GameManager.Instance.Profit += foodPrice;
        NPCSpawnManager.Instance.orderNum--;
        //좋은 애니메이션
        //우선 머리위에 띄워서 확인
        myNum.text = "G";
        //머리위에 번호판은 끄고
        //myCanvas.gameObject.SetActive(false);
        //포탈로 돌아가야하므로 타겟오브젝트 포탈로
        targetObject = GameObject.Find("EXIT");
        //그러고 이동
        state = State.Move;
        //이동하면서 CheckFood랑 ontriggerExit되면 숫자를 초기화
    }
    private void UpdateBad() {
        //컴플레인 올리고
        GameManager.Instance.Complain -= 1;
        //나쁜 애니메이션
        //우선 머리위에 띄워서 확인
        myNum.text = "B";
        //머리위에 번호판은 끄고
        //myCanvas.gameObject.SetActive(false);
        //포탈로 돌아가야하므로 타겟오브젝트 포탈로
        targetObject = GameObject.Find("EXIT");
        //그러고 이동
        state = State.Move;
    }

    private void UpdateRun() {
        //속도 빠르게하고
        speed = 15f;
        targetObject = GameObject.Find("EXIT");
        state = State.Move;
    }
}


    