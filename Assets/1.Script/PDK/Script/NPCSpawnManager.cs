using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCSpawnManager : MonoBehaviour {

    public static NPCSpawnManager Instance;
    public void Awake() {
        Instance = this;
    }

    public float currentTime;
    public float createtTime;
    public float startRandomCreateTime = 1f; //(public이라 인스펙터에서 적절한값으로 수정)
    public float startRandomEndTime = 1f; //(public이라 인스펙터에서 적절한값으로 수정)

    public List<GameObject> TableList = new List<GameObject>();
    public List<bool> emptyTableList = new List<bool>() { true, true, true, true, true };
    public GameObject npcCustomer;
    public GameObject npcRobber;
    //10퍼센트의 확률로 강도 출현
    public int rndRobberValue = 10;
    //orderNum은 스테이지에서 처리해야될 고객의 숫자
    public int orderNum;
    //customerNum은 1부터 게임끝날때까지 쭉 늘어나는 숫자
    public int customerNum=1;



    // Start is called before the first frame update
    void Start() {
        createtTime = 5f;
        for (int i = 0; i < emptyTableList.Count; i++) {
            emptyTableList[i] = true;
        }
        orderNum = GameManager.Instance.orderNumber;
    }
    void SpawnCustomer() {
        GameObject customer = Instantiate(npcCustomer);
        customer.transform.position = transform.position;
        customer.transform.parent = transform;
        currentTime = 0;
        createtTime = Random.Range(startRandomCreateTime, startRandomEndTime);
    }
    void SpawnRobber() {
        for (int i = 0; i < emptyTableList.Count; i++) {
            emptyTableList[i] = false;
        }
        //강도가 나오면 모든 customer의 state를 Run으로 변경
        for (int i = 0; i < transform.childCount; i++) {
            //Debug.Log("자식이름: " + transform.GetChild(i).name);
            if (transform.GetChild(i).name.Contains("Robber")) {
                return;
            }
            NPCCustomer customer = transform.GetChild(i).gameObject.GetComponent<NPCCustomer>();
            customer.state = NPCCustomer.State.Run;
        }
        GameObject robber = Instantiate(npcRobber);
        robber.transform.position = transform.position;
        robber.transform.parent = transform;
        GameManager.Instance.RobberCount++;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update() {
        if (emptyTableList.Contains(true) && orderNum > 0) {
            currentTime += Time.deltaTime;
            if (currentTime >= createtTime) {
                if (Random.Range(0, 100) > rndRobberValue) {
                    //NPC를 생산하는데
                    //랜덤하게 해서 어느정도면 고객이고
                    SpawnCustomer();
                }

                //아니면 강도인데
                //강도 호출 함수로 만들어야됨
                else {
                    SpawnRobber();
                }
            }
        }
    }
}
