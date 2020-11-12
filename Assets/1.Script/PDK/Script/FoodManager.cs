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
        {"BlackDrink", 5f },
        {"GreenDrink", 5f},
        {"GreenToast", 5f},
        {"PurpleToast", 5f},
        {"GreenSalad",5f},
        {"PurpleSalad",5f},
        {"RareSteak", 5f},
        {"MediumSteak", 5f},
        {"WelldoneSteak", 5f},
        {"MiniBurger", 5f},
        {"FullBurger", 5f}
    };

    public Dictionary<string, int> foodPriceDict = new Dictionary<string, int>() {
        {"BlackDrink", 100 },
        {"GreenDrink", 100},
        {"GreenToast", 200},
        {"PurpleToast", 200},
        {"GreenSalad",200},
        {"PurpleSalad",200},
        {"RareSteak", 500},
        {"MediumSteak", 500},
        {"WelldoneSteak", 500},
        {"MiniBurger", 300},
        {"FullBurger", 300},
    };
    public Dictionary<string, float> foodRandomWeightDict = new Dictionary<string, float>() {
        {"BlackDrink", 9.09f },
        {"GreenDrink", 9.09f},
        {"GreenToast", 9.09f},
        {"PurpleToast", 9.09f},
        {"GreenSalad",9.09f},
        {"PurpleSalad",9.09f},
        {"RareSteak", 9.09f},
        {"MediumSteak", 9.09f},
        {"WelldoneSteak", 9.09f},
        {"MiniBurger", 9.09f},
        {"FullBurger", 9.09f},
    };

    public GameObject panel1, panel2, panel3, panel4;
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
        foodTimeDict.Add("BlackDrink", 300f);
        foodTimeDict.Add("GreenDrink", 300f);
        foodTimeDict.Add("GreenToast", 300f);
        foodTimeDict.Add("PurpleToast", 300f);
        foodTimeDict.Add("GreenSalad", 300f);
        foodTimeDict.Add("PurpleSalad", 300f);
        foodTimeDict.Add("RareSteak", 400f);
        foodTimeDict.Add("MediumSteak", 500f);
        foodTimeDict.Add("WelldoneSteak", 600f);
        foodTimeDict.Add("MiniBurger", 600f);
        foodTimeDict.Add("FullBurger", 700f);
    }

    public void OnChildTriggerEnter(string customerFood, int childNum, int customerNum) {
        switch (childNum) {
            case 0:
                manual1.text = customerNum.ToString();
                manual1.text += "\n" + customerFood;
                panel1.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/" + customerFood.ToString());
                break;
            case 1:
                manual2.text = customerNum.ToString();
                manual2.text += "\n" + customerFood;
                panel2.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/" + customerFood.ToString());
                break;
            case 2:
                manual3.text = customerNum.ToString();
                manual3.text += "\n" + customerFood;
                panel3.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/" + customerFood.ToString());
                break;
            case 3:
                manual4.text = customerNum.ToString();
                manual4.text += "\n" + customerFood;
                panel4.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/" + customerFood.ToString());
                break;

        }
    }

    public void OnChildTriggerExit(int childNum) {
        switch (childNum) {
            case 0:
                manual1.text = "";
                panel1.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/background");
                break;
            case 1:
                manual2.text = "";
                panel2.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/background");
                break;
            case 2:
                manual3.text = "";
                panel3.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/background");
                break;
            case 3:
                manual4.text = "";
                panel4.GetComponent<Image>().sprite = Resources.Load<Sprite>("OrderImage/background");
                break;

        }
    }
}
