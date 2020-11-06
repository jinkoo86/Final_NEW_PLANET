using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;


public class FoodScript : MonoBehaviour {
    float curHP;
    string myname;
    bool knifeEnter = false;
    bool HammerEnter = false;
    bool GrillEnter = false;
    Rigidbody myRigidbody;
    BoxCollider myCollider;
    bool inDish;


    //빵은 FoodType0, 고기는 FoodType1, 상추는 FoodType2
    public float HP {          //싱글톤 안쓰는이유 : enemy는 하나가 아니기때문
        get { return curHP; } // enemy.HP = enemy.HP -1 -> enemy.HP(set), enemy.HP(get)
        set {
            curHP = Mathf.Max(0, value);
        }
    }
    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<BoxCollider>();
        myname = transform.name;
        curHP = 1f;
    }

    // Update is called once per frame
    void Update() {
        if (GrillEnter) {
            Debug.Log("나의 이름: " + myname + ", 현재 HP: " + curHP);
        }

        switch (myname) {
            case "SquareStoneBread":
                //case myname.Contains("SquareStoneBread"):
                if (HammerEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "RoundStone", 0);
                    }
                }
                else if (knifeEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "SquareBread", 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "SquareBread", 0);
                    }
                }
                else if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            case "RoundStone":
                if (HammerEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "HamburgerBreadUp", 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "HamburgerBreadDown", 0);
                    }
                    else if (GrillEnter) {
                        if (curHP <= 0) {
                            Destroy(gameObject, 0);
                            IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                        }
                    }
                }
                break;
            case "SquareBread":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "ToastBread", 0);
                    }
                }
                break;
            case "ToastBread":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;

            /////////////////////////////////////////////////////////////////////////////////////////////////

            case "FreshMeat":
                if (HammerEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "MincedMeat", 1);
                    }
                }
                else if (knifeEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "SteakMeat", 1);
                    }
                }
                else if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            case "MincedMeat":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "HamburgerPatty", 1);
                    }
                }
                break;
            case "HamburgerPatty":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            case "SteakMeat":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "RareSteak", 1);
                    }
                }
                break;
            case "RareSteak":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "MediumSteak", 1);
                    }
                }
                break;
            case "MediumSteak":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "WelldoneSteak", 1);
                    }
                }
                break;
            case "WelldoneSteak":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            case "Lettuce":
                if (HammerEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "HamburgerLet", 2);
                    }
                }
                else if (knifeEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position, "SaladLet", 2);
                    }
                }
                else if (GrillEnter) {
                    if(curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            case "HamburgerLet":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            case "SaladLet":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;
            case "Cheese":
                if (GrillEnter) {
                    if (curHP <= 0) {
                        Destroy(gameObject, 0);
                        IngredientsSpawnManager.Instance.FoodPrepping(transform.position + new Vector3(0, 0.3f, 0), "Burned", 4);
                    }
                }
                break;

            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision other) {

        if (other.transform.tag == "TOOL" && !other.transform.name.Contains("Grill")) {
            myRigidbody.isKinematic = true;
            myRigidbody.useGravity = false;
            myCollider.isTrigger = true;
            //Debug.Log(gameObject.name+"이 "+other.gameObject.name+"과 충돌, 생명력:" + curHP);
            if (other.transform.name.Contains("Hammer")) {
                HammerEnter = true;
                knifeEnter = false;
                GrillEnter = false;
            }
            if (other.transform.name.Contains("Knife")) {
                HammerEnter = false;
                knifeEnter = true;
                GrillEnter = false;
            }
            //if (other.transform.name.Contains("Grill")) {
            //    HammerEnter = false;
            //    knifeEnter = false;
            //    GrillEnter = true;
            //}
        }
        else if (other.transform.name.Contains("Grill")) {
            //Debug.Log(gameObject.name + "이 " + other.gameObject.name + "과 충돌, 생명력:" + curHP);
            HammerEnter = false;
            knifeEnter = false;
            GrillEnter = true;
        }
        if (other.transform.tag == "DISH") {
            transform.SetParent(other.transform);
            //접시에 올라간뒤로는 플레이어가 오브젝트를 따로 잡을수 없도록,
            //DistanceGrabbable 끄는걸로 했는데도 잡혀서 layer를 0로 변경하는방식으로 진행
            //transform.GetComponent<DistanceGrabbable>().enabled = false;
            gameObject.layer = 0;

            myCollider.isTrigger = true;
            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;

            Debug.Log("내 형제번호:" + transform.GetSiblingIndex());
            inDish = true;


            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localPosition = new Vector3(0, transform.GetSiblingIndex() + 1, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionExit(Collision other) {
        HammerEnter = false;
        knifeEnter = false;
        GrillEnter = false;
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "TOOL") {
            myRigidbody.isKinematic = false;
            myRigidbody.useGravity = true;
            myCollider.isTrigger = false;

            HammerEnter = false;
            knifeEnter = false;
            GrillEnter = false;
        }
    }

    //private void OnTriggerEnter(Collision other) {
    //    //이름으로 호출하는거는 느려서? 태그로 호출하는게 빠르다함 나중에 바꿔야징
    //    if (other.transform.name.Contains("Hammer")) {
    //        HammerEnter = true;
    //        knifeEnter = false;
    //    }

    //    if (other.transform.name.Contains("Knife")) {
    //        HammerEnter = false;
    //        knifeEnter = true;
    //    }
    //    if (other.transform.name.Contains("Grill")) {

    //    }
    //}
}
