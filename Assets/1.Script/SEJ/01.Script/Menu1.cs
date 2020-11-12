using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour
{
    bool menuYN;
    public GameObject menu;
    public GameObject pos;
    public GameObject uiHelpers;

    void Start()
    {
        menu.SetActive(false);
        
    }

    void Update()
    {
        transform.position = pos.transform.position;
        if (SceneManager.GetActiveScene().name == "WaitingRoom_SEJ")
        {
            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                //메뉴 UI가 false일 때 
                if (!menuYN)
                {
                    uiHelpers.GetComponent<LaserPointer>().enabled = true;
                    uiHelpers.GetComponent<LineRenderer>().enabled = true;
                    menu.SetActive(true);
                    print("켜짐");
                    menuYN = true;
                }
                //메뉴 UI가 true일 때
                else
                {
                    uiHelpers.GetComponent<LaserPointer>().enabled = false;
                    uiHelpers.GetComponent<LineRenderer>().enabled = false;
                    menu.SetActive(false);
                    print("꺼짐");
                    menuYN = false;
                }
            }
        }
        
    }
}
