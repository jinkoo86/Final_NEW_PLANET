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
        breadDict.Add("0Square_Rock", breads[0]);
        breadDict.Add("1Round_Rock", breads[1]);
        breadDict.Add("2BurgerBun_Top", breads[2]);
        breadDict.Add("3BurgerBun_Bottom", breads[3]);
        breadDict.Add("4SquareBread_Left", breads[4]);
        breadDict.Add("4SquareBread_Right", breads[5]);
        breadDict.Add("5Toast", breads[6]);

        meatDict.Add("0BIGMeat", meats[0]);
        meatDict.Add("1MeatBone", meats[1]);
        meatDict.Add("2Patty", meats[2]);
        meatDict.Add("3SteakMeat", meats[3]);
        meatDict.Add("4Steak_Rare", meats[4]);
        meatDict.Add("5Steak_medium", meats[5]);
        meatDict.Add("6Steak_Welldone", meats[6]);

        lettuceDict.Add("0Cabbage", lettuces[0]);
        lettuceDict.Add("1Hamburger_lettuce", lettuces[1]);
        lettuceDict.Add("2mass_lettuce", lettuces[2]);

        foodBread = Instantiate(breadDict["0Square_Rock"]);
        foodBread.name = "0Square_Rock";
        foodBread.transform.position = breadSpawnPoint.transform.position + new Vector3(0, 0.3f, 0);

        foodMeat = Instantiate(meatDict["0BIGMeat"]);
        foodMeat.name = "0BIGMeat";
        foodMeat.transform.position = meatSpawnPoint.transform.position + new Vector3(0, 0.3f, 0);

        foodLettuce = Instantiate(lettuceDict["0Cabbage"]);
        foodLettuce.name = "0Cabbage";
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
