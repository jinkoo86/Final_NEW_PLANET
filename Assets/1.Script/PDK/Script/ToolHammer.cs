using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHammer : MonoBehaviour {
    float powerLevel;
    public Rigidbody rb;
    public float speed = 0;
    FoodScript food;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

        if (gameObject.transform.name.Contains("level3")) {
            powerLevel = 1f;
        }
        else if (gameObject.transform.name.Contains("level2")) {
            powerLevel = 0.5f;
        }
        else {
            powerLevel = 0.4f;
        }

    }

    // Update is called once per frame
    void Update() {
        speed = rb.velocity.magnitude;
        //Debug.Log("Speed: "+speed);
        //TESTSCRIPT.Instance.hammerSpeed = speed;
        //Debug.Log("HammerPower: " + powerLevel);
        //Debug.Log("Hammer:"+speed);
    }

    private void OnCollisionEnter(Collision other) {
        //Debug.Log("칼충돌: " + other.transform.name);
        //TESTSCRIPT.Instance.knifeTag = other.transform.tag;
        if (other.transform.tag == "FOOD" && speed >= 2.0f) {

            //transform.GetComponent<Rigidbody>().isKinematic = true;
            //transform.GetComponent<Rigidbody>().useGravity = false;
            //transform.GetComponent<BoxCollider>().isTrigger = true;

            food = other.transform.gameObject.GetComponent<FoodScript>();
            food.HP -= powerLevel;
            speed = 0;

        }
    }
    private void OnCollisionExit(Collision other) {
        if (other.transform.tag == "FOOD") {
            //transform.GetComponent<Rigidbody>().isKinematic = false;
            //transform.GetComponent<Rigidbody>().useGravity = true;
            //transform.GetComponent<BoxCollider>().isTrigger = false;
            food = null;
        }
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other.transform.tag == "FOOD" && speed >= 3.0f) {
    //        food = other.transform.gameObject.GetComponent<FoodScript>();
    //        food.HP -= powerLevel;
    //    }
    //}

    //private void OnTriggerExit(Collider other) {
    //    if (other.transform.tag == "FOOD") {
    //        transform.GetComponent<Rigidbody>().isKinematic = false;
    //        transform.GetComponent<Rigidbody>().useGravity = true;
    //        transform.GetComponent<BoxCollider>().isTrigger = false;
    //        food = null;
    //    }
    //}
}
