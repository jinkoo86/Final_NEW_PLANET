using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawnManager : MonoBehaviour {
    public static IngredientsSpawnManager Instance;
    public void Awake() {
        Instance = this;
    }

    [Header("Food Ingredients")]
    public GameObject[] breads;
    public GameObject[] meats;
    public GameObject[] lettuces;
    //빵은 FoodType0, 고기는 FoodType1, 상추는 FoodType2
    public Dictionary<string, GameObject> breadDict = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> meatDict = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> lettuceDict = new Dictionary<string, GameObject>();

    public GameObject cheese;
    public GameObject eye;
    public GameObject burnedFood;

    [Header("Spawn Point")]
    public GameObject breadSpawnPoint;
    public GameObject meatSpawnPoint;
    public GameObject lettuceSpawnPoint;
    public GameObject cheeseSpawnPoint;


    public int stageLevel;

    GameObject foodBread, foodMeat, foodLettuce, foodCheese, foodBurned;
    // Start is called before the first frame update
    void Start() {
        breadDict.Add("SquareStoneBread", breads[0]);
        breadDict.Add("RoundStone", breads[1]);
        breadDict.Add("HamburgerBreadUp", breads[2]);
        breadDict.Add("HamburgerBreadDown", breads[3]);
        breadDict.Add("SquareBread", breads[4]);
        breadDict.Add("ToastBread", breads[5]);

        meatDict.Add("FreshMeat", meats[0]);
        meatDict.Add("MincedMeat", meats[1]);
        meatDict.Add("HamburgerPatty", meats[2]);
        meatDict.Add("SteakMeat", meats[3]);
        meatDict.Add("RareSteak", meats[4]);
        meatDict.Add("MediumSteak", meats[5]);
        meatDict.Add("WelldoneSteak", meats[6]);

        lettuceDict.Add("Lettuce", lettuces[0]);
        lettuceDict.Add("HamburgerLet", lettuces[1]);
        lettuceDict.Add("SaladLet", lettuces[2]);

        foodBread = Instantiate(breadDict["SquareStoneBread"]);
        foodBread.name = "SquareStoneBread";
        foodBread.transform.position = breadSpawnPoint.transform.position + new Vector3(0, 0.3f, 0);

        foodMeat = Instantiate(meatDict["FreshMeat"]);
        foodMeat.name = "FreshMeat";
        foodMeat.transform.position = meatSpawnPoint.transform.position + new Vector3(0, 0.3f, 0);

        foodLettuce = Instantiate(lettuceDict["Lettuce"]);
        foodLettuce.name = "Lettuce";
        foodLettuce.transform.position = lettuceSpawnPoint.transform.position + new Vector3(0, 0.3f, 0);

        foodCheese = Instantiate(cheese);
        foodCheese.name = "Cheese";
        foodCheese.transform.position = cheeseSpawnPoint.transform.position + new Vector3(0, 0.3f, 0);

    }

    // Update is called once per frame
    void Update() {
    }

    public void FoodPrepping(Vector3 FoodPosition, string FoodName, int FoodType) {
        switch (FoodType) {
            case 0:
                foodBread = Instantiate(breadDict[FoodName]);
                foodBread.name = FoodName;
                foodBread.transform.position = FoodPosition;
                break;
            case 1:
                foodMeat = Instantiate(meatDict[FoodName]);
                foodMeat.name = FoodName;
                foodMeat.transform.position = FoodPosition;
                break;
            case 2:
                foodLettuce = Instantiate(lettuceDict[FoodName]);
                foodLettuce.name = FoodName;
                foodLettuce.transform.position = FoodPosition;
                break;
            case 3:
                foodCheese = Instantiate(cheese);
                foodCheese.name = FoodName;
                foodCheese.transform.position = FoodPosition;
                break;
            case 4:
                foodBurned = Instantiate(burnedFood);
                foodBurned.name = FoodName;
                foodBurned.transform.position = FoodPosition;
                break;
        }
    }
}
