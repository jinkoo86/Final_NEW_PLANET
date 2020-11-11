using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour
{
    public static Menu1 instance;
    private void Awake()
    {
        instance = this;
    }

    public bool menuYN;
    public GameObject menu;
    public GameObject pos;
    
    void Start()
    {
        menu.SetActive(false);
        
    }

    void Update()
    {
        transform.position = pos.transform.position;
        if (SceneManager.GetActiveScene().name == "WaitingRoom")
        {
            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                //메뉴 UI가 false일 때 
                if (!menuYN)
                {
                    menu.SetActive(true);
                    print("켜짐");
                    menuYN = true;
                }
                //메뉴 UI가 true일 때
                else
                {
                    menu.SetActive(false);
                    print("꺼짐");
                    menuYN = false;
                }
            }
        }
        
    }
}
