using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_WaitingRoom : MonoBehaviour
{
    RaycastHit hitinfo;
    bool isPlay;
    public GameObject soundManager;
    bool isOn;
    public GameObject vibrationManager;
    public GameObject menu;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hitinfo))
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
        }
    }
}
