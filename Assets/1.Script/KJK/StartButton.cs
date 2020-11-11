using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.activeSelf)
        {
        anim.Play("Door");

        }

    }
}
