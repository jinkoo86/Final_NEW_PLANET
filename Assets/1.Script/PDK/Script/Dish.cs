using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class Dish : MonoBehaviour {

    //List<string> GreenToast = new List<string> { "ToastBread", "Sauce1" };
    List<string> GreenToast = new List<string> { "5Toast" };
    //List<string> PurpleToast = new List<string> { "ToastBread", "Sauce1" };
    List<string> PurpleToast = new List<string> { "5Toast" };

    List<string> RareSteak = new List<string> { "4Steak_Rare" };
    List<string> MediumSteak = new List<string> { "5Steak_medium" };
    List<string> WelldoneSteak = new List<string> { "6Steak_Welldone" };

    List<string> MiniBurger = new List<string> { "3BurgerBun_Bottom", "2Patty", "2BurgerBun_Top" };
    //List<string> HamBurger = new List<string> { "HamburgerBreadDown", "HamburgerLet", "HamburgerPatty", "Sauce1", "Sauce2", "HamburgerBreadUp" };
    List<string> HamBurger = new List<string> { "3BurgerBun_Bottom", "1Hamburger_lettuce", "2Patty", "2BurgerBun_Top" };
    //List<string> CheeseBurger = new List<string> { "HamburgerBreadDown", "HamburgerLet", "HamburgerPatty", "Cheese", "Sauce1", "Sauce2", "HamburgerBreadUp" };
    List<string> CheeseBurger = new List<string> { "3BurgerBun_Bottom", "1Hamburger_lettuce", "2Patty", "Cheese", "2BurgerBun_Top" };

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
    BoxCollider otherCollider;
    Vector3 allColliderSize;

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
            other.transform.SetParent(transform);
            otherCollider = other.transform.GetComponent<BoxCollider>();

            //하나 닿을때마다 나의 컬라이더박스의 y값을 늘림(위로)
            myCollider.size += new Vector3(0, otherCollider.size.y, 0);
            myCollider.center += new Vector3(0, otherCollider.size.y / 2, 0);
            allColliderSize += new Vector3(0, otherCollider.size.y, 0);

            other.transform.localScale = new Vector3(1, 1, 1);
            other.transform.localRotation = Quaternion.Euler(0, 0, 0);
            other.transform.localPosition = allColliderSize;

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
