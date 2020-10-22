using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//레이캐스트를 쏘아서 앞에 있는 물체의 이름을 알아내고싶다. 

public class RayCast_Hand : MonoBehaviour
{
    RaycastHit hitinfo;
    public GameObject soundManager;
    bool isPlay = false;
    public GameObject vibrationManager;
    bool isOn = false;
    public GameObject menu;

    void Start()
    {

    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hitinfo, 1.5f))
            {
                if (hitinfo.transform.gameObject.name == "Vol")
                {
                    if (isPlay == false)
                    {
                        soundManager.SetActive(true);
                        isPlay = true;
                    }
                    else
                    {
                        soundManager.SetActive(false);
                        isPlay = false;
                    }
                }
                if (hitinfo.transform.gameObject.name == "Vib")
                {
                    if (isOn == false)
                    {
                        vibrationManager.SetActive(true);
                        isOn = true;
                    }
                    else
                    {
                        vibrationManager.SetActive(false);
                        isOn = false;
                    }
                }
                if (hitinfo.transform.gameObject.name == "Close")
                {
                    menu.SetActive(false);
                }
                if (hitinfo.transform.gameObject.name == "Exit")
                {
                    SceneManager.LoadScene("WaitingRoom");
                }
            }
        }
        
    }
}
