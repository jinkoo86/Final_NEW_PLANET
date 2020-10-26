using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayCast_Hand : MonoBehaviour
{
    RaycastHit hitinfo;
    public GameObject soundManager;
    bool isPlay = false;
    public GameObject vibrationManager;
    bool isOn = false;
    public GameObject menu;
    public Text volText;
    public Text vibText;
    
    Ray ray;
    void Start()
    {

    }
    void Update()
    {
        MenuControll();

    }
    public void MenuControll()
    {
        ray = new Ray(transform.position, transform.forward); ;
        //Debug.Log("aa");

        if (Physics.Raycast(ray, out hitinfo, 100000f))
        {
            switch (hitinfo.transform.gameObject.name)
            {
                case "Vol":
                    Debug.Log("vol Hit switch");

                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
                    {
                        Debug.Log("vol down");

                        if (isPlay == false)
                        {
                            //soundManager.SetActive(true);
                            SoundManager.soundMN.GetComponent<AudioSource>().volume = 0.6f;
                            volText.text = "Volume On";
                            Debug.Log("vol On");
                            isPlay = true;
                        }
                        else
                        {
                            SoundManager.soundMN.GetComponent<AudioSource>().volume = 0;
                            volText.text = "Volume Off";
                            Debug.Log("vol Off");
                            isPlay = false;
                        }
                    }
                    break;
                case "Vib":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
                    {
                        if (isOn == false)
                        {
                            vibrationManager.SetActive(true);
                            vibText.text = "Viration On";
                            isOn = true;
                        }
                        else
                        {
                            vibrationManager.SetActive(false);
                            vibText.text = "Viration Off";
                            isOn = false;
                        }
                    }
                    break;
                case "Close":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
                    {
                        menu.SetActive(false);
                    }
                    break;
                case "Exit":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
                    {
                        SceneManager.LoadScene("WaitingRoom");
                    }
                    break;
            }
        }
    }
}

