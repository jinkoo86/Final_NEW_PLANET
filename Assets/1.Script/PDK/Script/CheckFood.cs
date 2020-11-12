using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFood : MonoBehaviour {
    int mycustomerNum;
    int myNum;
    public Text myTimer;
    //    1: 블랙음료 초록음료 초록잼토스트 보라잼토스트
    List<string> foodLevel1 = new List<string>() { "BlackDrink", "GreenDrink", "GreenToast", "PurpleToast" };
    //2: 레어 미디움 웰던스테이크 보라샐러드 초록샐러드
    List<string> foodLevel2 = new List<string>() { "RareSteak", "MediumSteak", "WelldoneSteak", "PurpleSalad", "GreenSalad" };
    //3: 검정음료 초록음료 미니버거(빵아래 고기 치즈 빵위)
    List<string> foodLevel3 = new List<string>() { "BlackDrink", "GreenDrink", "MiniBurger" };
    //4: 기본버거(빵아래, 고기, 치즈, 야채, 보라소스, 빵위) 보라샐러드 초록샐러드 검정음료 초록음료
    List<string> foodLevel4 = new List<string>() { "FullBurger", "PurpleSalad", "GreenSalad", "BlackDrink", "GreenDrink" };
    //5: 전부 다 이미지는? 모양
    List<string> foodLevel5 = new List<string>() { "BlackDrink", "GreenDrink", "GreenToast", "PurpleToast", "PurpleSalad", "GreenSalad", "RareSteak", "MediumSteak", "WelldoneSteak", "MiniBurger", "FullBurger" };

    List<string> foodList;
    string orderName;
    float orderTime;
    public string dishFoodName;
    bool timeCheck;
    NPCCustomer npcCus;
    FoodManager parent;

    int stageLevel;

    // Start is called before the first frame update
    void Start() {
        parent = FoodManager.Instance;
        myTimer.text = "";
        //Debug.Log("음식명: " + foodList[Random.Range(0, 8)]);
        myNum = transform.GetSiblingIndex();
        GetStageLevel();

    }

    // Update is called once per frame
    void Update() {
        if (timeCheck) {
            orderTime -= Time.deltaTime;
            myTimer.text = Mathf.FloorToInt(orderTime).ToString();
            if (orderTime <= 0) {
                myTimer.text = "";
                npcCus.state = NPCCustomer.State.Bad;
                timeCheck = false;
                npcCus = null;
            }
        }
    }
    void GetStageLevel() {
        stageLevel = GameManager.Instance.StageLevel;
        switch (stageLevel) {

            case 1:
                foodList = foodLevel1;
                break;

            case 2:
                foodList = foodLevel2;
                break;

            case 3:
                foodList = foodLevel3;
                break;

            case 4:
                foodList = foodLevel4;
                break;

            case 5:
                foodList = foodLevel5;
                break;
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "CUSTOMER") {
            //Debug.Log("내이름: " + transform.name + ", 번호: " + CustomerNum);
            npcCus = other.transform.gameObject.GetComponent<NPCCustomer>();
            mycustomerNum = npcCus.myCustomerNum;
            //해당 랜덤부분 가중치 설정 필요
            orderName = foodList[Random.Range(0, foodList.Count)];
            Debug.Log(orderName);
            orderTime = parent.foodTimeDict[orderName];
            Debug.Log("orderTime:" + orderTime);
            //Debug.Log(orderTime);
            parent.OnChildTriggerEnter(orderName, myNum, mycustomerNum); // pass the own collider and the one we've hit
            timeCheck = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "CUSTOMER") {
            parent.OnChildTriggerExit(myNum);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "DISH" || other.transform.tag == "WATERCUP") {
            Debug.Log("dishFoodName: " + dishFoodName + ", orderName: " + orderName);
            if (dishFoodName == orderName) {

                Destroy(other.gameObject, 0);
                npcCus.FoodPrice = parent.foodPriceDict[orderName];
                npcCus.state = NPCCustomer.State.Good;
                timeCheck = false;
                GameManager.Instance.RemainOrderTime += orderTime;
                npcCus = null;
                myTimer.text = "";
            }
            else if (dishFoodName != orderName) {
                Destroy(other.gameObject, 0);
                npcCus.state = NPCCustomer.State.Bad;
                timeCheck = false;
                npcCus = null;
                myTimer.text = "";
            }
        }
    }
}
