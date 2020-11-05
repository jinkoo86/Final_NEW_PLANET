﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawnPoint : MonoBehaviour {

    bool foodInCheck = true;
    public float foodWaitTime = 2f;
    public float foodSpawnTime;
    string myname;

    // Start is called before the first frame update
    void Start() {
        foodInCheck = true;
        myname = transform.name;
    }

    // Update is called once per frame
    void Update() {
        if (!foodInCheck) {
            foodSpawnTime += Time.deltaTime;
            if (foodSpawnTime >= foodWaitTime) {
                //음식 소환
                FoodSpawn();
                foodInCheck = true;
                foodSpawnTime = 0.0f;
            }
        }
    }

    void FoodSpawn() {

        switch (myname) {
            case "BreadSpawnPoint":
                IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "SquareStoneBread", 0);
                //foodInCheck = true;
                break;
            case "MeatSpawnPoint":
                IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "FreshMeat", 1);
                //foodInCheck = true;
                break;
            case "LettuceSpawnPoint":
                IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Lettuce", 2);
                //foodInCheck = true;
                break;
            case "CheeseSpawnPoint":
                IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Cheese", 3);
                //foodInCheck = true;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "FOOD") {
            //Debug.Log("myname: " + myname + "들어온놈: " + other.transform.name);
            foodInCheck = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if (other.transform.tag == "FOOD") {
            //Debug.Log("myname: " + myname + "나간놈: " + other.transform.name);
            foodInCheck = false;
        }
    }
}