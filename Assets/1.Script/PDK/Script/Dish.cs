using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class Dish : MonoBehaviour {

    //List<string> GreenToast = new List<string> { "ToastBread", "Sauce1" };
    List<string> GreenToast = new List<string> { "ToastBread" };
    //List<string> PurpleToast = new List<string> { "ToastBread", "Sauce1" };
    List<string> PurpleToast = new List<string> { "ToastBread" };

    List<string> RareSteak = new List<string> { "RareSteak" };
    List<string> MediumSteak = new List<string> { "MediumSteak" };
    List<string> WelldoneSteak = new List<string> { "WelldoneSteak" };

    List<string> MiniBurger = new List<string> { "HamburgerBreadDown", "HamburgerPatty", "HamburgerBreadUp" };
    //List<string> HamBurger = new List<string> { "HamburgerBreadDown", "HamburgerLet", "HamburgerPatty", "Sauce1", "Sauce2", "HamburgerBreadUp" };
    List<string> HamBurger = new List<string> { "HamburgerBreadDown", "HamburgerLet", "HamburgerPatty", "HamburgerBreadUp" };
    //List<string> CheeseBurger = new List<string> { "HamburgerBreadDown", "HamburgerLet", "HamburgerPatty", "Cheese", "Sauce1", "Sauce2", "HamburgerBreadUp" };
    List<string> CheeseBurger = new List<string> { "HamburgerBreadDown", "HamburgerLet", "HamburgerPatty", "Cheese", "HamburgerBreadUp" };

    List<string> myfood = new List<string> { };
    public enum enumFood {
        none,       //0
        GreenToast,
        PurpleToast,
        RareSteak,
        MediumSteak,
        WelldoneSteak,
        MiniBurger,
        HamBurger,
        CheeseBurger //8
    }
    enumFood ef;
    BoxCollider myCollider;

    // Start is called before the first frame update
    void Start() {
        
        ef = enumFood.none;
        myCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {
    }
    bool CheckGreenToast() {
        if (myfood.Count != GreenToast.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != GreenToast[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckPurpleToast() {
        if (myfood.Count != PurpleToast.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != PurpleToast[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckRareSteak() {
        if (myfood.Count != RareSteak.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != RareSteak[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckMediumSteak() {
        if (myfood.Count != MediumSteak.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != MediumSteak[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckWelldoneSteak() {
        if (myfood.Count != WelldoneSteak.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != WelldoneSteak[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckMiniBurger() {
        if (myfood.Count != MiniBurger.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != MiniBurger[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckHamBurger() {
        if (myfood.Count != HamBurger.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != HamBurger[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckCheeseBurger() {
        if (myfood.Count != CheeseBurger.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != CheeseBurger[i]) {
                return false;
            }
        }
        return true;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "FOOD") {
            //하나 닿을때마다 나의 컬라이더박스의 y값을 늘림(위로)
            myCollider.size += new Vector3(0, 1, 0);
            myCollider.center += new Vector3(0, 0.5f, 0);
        }

        if (other.transform.tag == "CHECK") {
            int children = transform.childCount;
            for (int i = 0; i < children; ++i) {
                myfood.Add(transform.GetChild(i).name);
            }
            if (CheckGreenToast()) {
                ef = enumFood.GreenToast;
            }
            else if (CheckPurpleToast()) {
                ef = enumFood.PurpleToast;
            }
            else if (CheckRareSteak()) {
                ef = enumFood.RareSteak;
            }
            else if (CheckMediumSteak()) {
                ef = enumFood.MediumSteak;
            }
            else if (CheckWelldoneSteak()) {
                ef = enumFood.WelldoneSteak;
            }
            else if (CheckMiniBurger()) {
                ef = enumFood.MiniBurger;
            }
            else if (CheckHamBurger()) {
                ef = enumFood.HamBurger;
            }
            else if (CheckCheeseBurger()) {
                ef = enumFood.CheeseBurger;
            }
            CheckFood checkFood = other.transform.gameObject.GetComponent<CheckFood>();
            checkFood.dishFoodName = ef.ToString();
        }
    }
}
