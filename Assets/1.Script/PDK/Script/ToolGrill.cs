using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolGrill : MonoBehaviour {
    float powerLevel;
    public Rigidbody rb;
    bool collisionDetect=false;
    GameObject detectObject;
    FoodScript food;

    // Start is called before the first frame update
    void Start() {
        if (gameObject.transform.name.Contains("level3")) {
            powerLevel = 0.005f;
        }
        else if (gameObject.transform.name.Contains("level2")) {
            powerLevel = 0.003f;
        }
        else {
            powerLevel = 0.0015f;
        }
    }

    // Update is called once per frame
    void Update() {
        if (collisionDetect) {

            food.HP -= powerLevel;
            Debug.Log("food HP: " + food.HP);
        }

    }
    private void OnCollisionEnter(Collision other) {
        //Debug.Log("충돌발생" + other.gameObject.name);
        if (other.transform.tag == "FOOD") {
            food = other.transform.gameObject.GetComponent<FoodScript>();
            //transform.GetComponent<Rigidbody>().useGravity = false;
            collisionDetect = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        //Debug.Log("충돌해제" + other.gameObject.name);
        if (other.transform.tag == "FOOD") {
            //transform.GetComponent<Rigidbody>().useGravity = true;
            collisionDetect = false;
            food = null;
        }
    }
    //private void OnTriggerEnter(Collider other) {
    //    if (other.transform.tag == "FOOD") {
    //        collisionDetect = true;
    //        food = other.transform.gameObject.GetComponent<FoodScript>();
    //    }
    //}

    //private void OnTriggerExit(Collider other) {
    //    if (other.transform.tag == "FOOD") {
    //        //transform.GetComponent<Rigidbody>().useGravity = true;
    //        collisionDetect = false;
    //        food = null;
    //    }
    //}
}