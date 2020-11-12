using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class Dish : MonoBehaviour {


    List<string> GreenToast = new List<string> { "5Toast", "greenSauce" };
    List<string> PurpleToast = new List<string> { "5Toast", "purpleSauce" };

    List<string> GreenSalad = new List<string> { "2mass_lettuce", "greenSauce" };
    List<string> PurpleSalad = new List<string> { "2mass_lettuce", "purpleSauce" };

    List<string> RareSteak = new List<string> { "4Steak_Rare" };
    List<string> MediumSteak = new List<string> { "5Steak_medium" };
    List<string> WelldoneSteak = new List<string> { "6Steak_Welldone" };

    List<string> MiniBurger = new List<string> { "3BurgerBun_Bottom", "2Patty", "Cheese", "2BurgerBun_Top" };
    List<string> FullBurger = new List<string> { "3BurgerBun_Bottom", "2Patty", "Cheese", "1Hamburger_lettuce", "purpleSauce", "2BurgerBun_Top" };



    List<string> myfood = new List<string> { };
    public enum enumFood {
        none,       //0
        GreenToast,
        PurpleToast,
        GreenSalad,
        PurpleSalad,
        RareSteak,
        MediumSteak,
        WelldoneSteak,
        MiniBurger,
        FullBurger          //9
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

    bool CheckGreenSalad() {
        if (myfood.Count != GreenSalad.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != GreenSalad[i]) {
                return false;
            }
        }
        return true;
    }
    bool CheckPurpleSalad() {
        if (myfood.Count != PurpleSalad.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != PurpleSalad[i]) {
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
    bool CheckFullBurger() {
        if (myfood.Count != FullBurger.Count) {
            return false;
        }
        for (int i = 0; i < myfood.Count; i++) {
            if (myfood[i] != FullBurger[i]) {
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
            ////////////////////////////////
            else if (CheckGreenSalad()) {
                ef = enumFood.GreenSalad;
            }
            else if (CheckPurpleSalad()) {
                ef = enumFood.PurpleSalad;
            }
            //////////////////////////////////
            else if (CheckRareSteak()) {
                ef = enumFood.RareSteak;
            }
            else if (CheckMediumSteak()) {
                ef = enumFood.MediumSteak;
            }
            else if (CheckWelldoneSteak()) {
                ef = enumFood.WelldoneSteak;
            }
            //////////////////////////////////
            else if (CheckMiniBurger()) {
                ef = enumFood.MiniBurger;
            }
            else if (CheckFullBurger()) {
                ef = enumFood.FullBurger;
            }
            CheckFood checkFood = other.transform.gameObject.GetComponent<CheckFood>();
            checkFood.dishFoodName = ef.ToString();
        }
    }
}
