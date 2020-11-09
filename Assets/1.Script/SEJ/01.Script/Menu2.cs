using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    bool menuYN;
    public GameObject menu2;
    public GameObject uiHelpers;
    public GameObject pos;

    void Start()
    {
        menu2.SetActive(false);
    }

    void Update()
    {
        transform.position = pos.transform.position;
        if (SceneManager.GetActiveScene().name == "StageRoom")
        {
            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                //메뉴 UI가 false일 때 
                if (!menuYN)
                {
                    uiHelpers.GetComponent<LaserPointer>().enabled = true;
                    uiHelpers.GetComponent<LineRenderer>().enabled = true;
                    menu2.SetActive(true);
                    print("켜짐");
                    menuYN = true;
                }
                //메뉴 UI가 true일 때
                else
                {
                    uiHelpers.GetComponent<LaserPointer>().enabled = false;
                    uiHelpers.GetComponent<LineRenderer>().enabled = false;
                    menu2.SetActive(false);
                    print("꺼짐");
                    menuYN = false;
                }
            }
        }
    }
}
