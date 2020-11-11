using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFood : MonoBehaviour {
    int mycustomerNum;
    int myNum;
    public Text myTimer;
    List<string> foodList = new List<string>() { "BlackDrink", "GreenDrink", "GreenToast", "PurpleToast", "Salad", "RareSteak", "MediumSteak", "WelldoneSteak", "MiniBurger", "HamBurger", "CheeseBurger" };
    string orderName;
    float orderTime;
    public string dishFoodName;
    bool timeCheck;
    NPCCustomer npcCus;
    FoodManager parent;

    // Start is called before the first frame update
    void Start() {
        parent = FoodManager.Instance;
        myTimer.text = "";
        //Debug.Log("음식명: " + foodList[Random.Range(0, 8)]);
        myNum = transform.GetSiblingIndex();
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
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "CUSTOMER") {
            //Debug.Log("내이름: " + transform.name + ", 번호: " + CustomerNum);
            npcCus = other.transform.gameObject.GetComponent<NPCCustomer>();
            mycustomerNum = npcCus.myCustomerNum;
            //해당 랜덤부분 가중치 설정 필요
            orderName = foodList[Random.Range(0, 10)];
            //Debug.Log(orderName);
            orderTime = parent.foodTimeDict[orderName];
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
