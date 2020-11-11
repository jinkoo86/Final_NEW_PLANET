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
        { "BlackDrink", 300f },
        {"GreenDrink", 300f},
        {"GreenToast", 300f},
        {"PurpleToast", 300f},
        {"Salad",300f},
        {"RareSteak", 400f},
        {"MediumSteak", 500f},
        {"WelldoneSteak", 600f},
        {"MiniBurger", 600f},
        {"HamBurger", 700f},
        {"CheeseBurger", 800f}
    };

    public Dictionary<string, int> foodPriceDict = new Dictionary<string, int>() {
        {"BlackDrink", 100 },
        {"GreenDrink", 100},
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
        {"BlackDrink", 9.09f },
        {"GreenDrink", 9.09f},
        {"GreenToast", 9.09f},
        {"PurpleToast", 9.09f},
        {"Salad",9.09f},
        {"RareSteak", 9.09f},
        {"MediumSteak", 9.09f},
        {"WelldoneSteak", 9.09f},
        {"MiniBurger", 9.09f},
        {"HamBurger", 9.09f},
        {"CheeseBurger", 9.09f}
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
                manual1.text += "\n" + customerFood;
                break;
            case 1:
                manual2.text = customerNum.ToString();
                manual2.text += "\n" + customerFood;
                break;
            case 2:
                manual3.text = customerNum.ToString();
                manual3.text += "\n" + customerFood;
                break;
            case 3:
                manual4.text = customerNum.ToString();
                manual4.text += "\n" + customerFood;
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
