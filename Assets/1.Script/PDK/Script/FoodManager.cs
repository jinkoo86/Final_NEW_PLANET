using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour {
    public static FoodManager Instance;
    public void Awake() {
        Instance = this;
    }
    public Dictionary<string, float> foodTimeDict = new Dictionary<string, float>() {
        {"GreenToast", 30f},
        {"PurpleToast", 30f},
        {"Salad",30f},
        {"RareSteak", 40f},
        {"MediumSteak", 50f},
        {"WelldoneSteak", 60f},
        {"MiniBurger", 60f},
        {"HamBurger", 70f},
        {"CheeseBurger", 80f}
    };

    public Dictionary<string, int> foodPriceDict = new Dictionary<string, int>() {
        {"GreenToast", 200},
        {"PurpleToast", 200},
        {"Salad",200},
        {"RareSteak", 500},
        {"MediumSteak", 500},
        {"WelldoneSteak", 500},
        {"MiniBurger", 300},
        {"HamBurger", 300},
        {"CheeseBurger", 300}
    };
    public Dictionary<string, float> foodRandomWeightDict = new Dictionary<string, float>() {
        {"GreenToast", 11.1f},
        {"PurpleToast", 11.1f},
        {"Salad",11.1f},
        {"RareSteak", 11.1f},
        {"MediumSteak", 11.1f},
        {"WelldoneSteak", 11.1f},
        {"MiniBurger", 11.1f},
        {"HamBurger", 11.1f},
        {"CheeseBurger", 11.1f}
    };

    public Text manual1, manual2, manual3, manual4;
    List<string> dishFood = new List<string> { };

    public List<string> FinishedDish {
        get { return dishFood; }
        set {
        }
    }
    void Start() {
    }
    // Update is called once per frame
    void Update() {
    }

    public void FoodTimePlus() {
        foodTimeDict.Clear();
        foodTimeDict.Add("GreenToast", 35f);
        foodTimeDict.Add("PurpleToast", 35f);
        foodTimeDict.Add("Salad", 35f);
        foodTimeDict.Add("RareSteak", 45f);
        foodTimeDict.Add("MediumSteak", 55f);
        foodTimeDict.Add("WelldoneSteak", 65f);
        foodTimeDict.Add("MiniBurger", 65f);
        foodTimeDict.Add("HamBurger", 75f);
        foodTimeDict.Add("CheeseBurger", 85f);
    }

    public void OnChildTriggerEnter(string customerFood, int childNum, int customerNum) {
        switch (childNum) {
            case 0:
                manual1.text = customerNum.ToString();
                manual1.text += "\n"+customerFood;
                break;
            case 1:
                manual2.text = customerNum.ToString();
                manual2.text += "\n"+customerFood;
                break;
            case 2:
                manual3.text = customerNum.ToString();
                manual3.text += "\n"+customerFood;
                break;
            case 3:
                manual4.text = customerNum.ToString();
                manual4.text += "\n"+customerFood;
                break;

        }
    }

    public void OnChildTriggerExit(int childNum) {
        switch (childNum) {
            case 0:
                manual1.text = "";
                break;
            case 1:
                manual2.text = "";
                break;
            case 2:
                manual3.text = "";
                break;
            case 3:
                manual4.text = "";
                break;

        }
    }
}
