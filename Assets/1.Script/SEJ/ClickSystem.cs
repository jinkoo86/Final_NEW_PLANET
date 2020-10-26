using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSystem : MonoBehaviour
{
    bool isPlay;
    bool isOn;
    public GameObject vibrationManager;
    public Text volText;
    public Text vibText;

    void Start()
    {

    }

    void Update()
    {

    }
    //볼륨 버튼 제어하는 부분 
    public void OnClickMenu()
    {
        //태그가 Vol인 경우 
        if (gameObject.tag == "Vol")
        {
            
        }
        //태그가 Vib인 경우 
        else if (gameObject.tag == "Vib")
        {

        }
        //태그가 Close인 경우 
        else if (gameObject.tag == "Close")
        {

        }
        //태그가 Exit인 경우 
        else if (gameObject.tag == "Exit")
        {

        }
    }
}
