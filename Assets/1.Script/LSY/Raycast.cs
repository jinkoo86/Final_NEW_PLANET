using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    RaycastHit hitInfo;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Ray()
    {
        ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hitInfo, 10.0f))
        {
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Button":
                    if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
                    {
                        hitInfo.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    }
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Ray();
    }
}
