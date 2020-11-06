using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TESTSCRIPT : MonoBehaviour {
    public Dictionary<string, float> foodTimeDict = new Dictionary<string, float>() {
        {"GreenToast", 150f},
        {"PurpleToast", 150f},
        {"Salad",150f},
        {"RareSteak", 200f},
        {"MediumSteak", 200f},
        {"WelldoneSteak", 200f},
        {"MiniBurger", 300f},
        {"HamBurger", 300f},
        {"CheeseBurger", 300f}
    };
    private void Start() {
        Debug.Log(foodTimeDict.Count);
        foodTimeDict.Clear();
        Debug.Log(foodTimeDict.Count);

        //Debug.Log(foodTimeDict.Keys.ElementAt(5));
        //Debug.Log(foodTimeDict.Values.ElementAt(5));
    }
}
