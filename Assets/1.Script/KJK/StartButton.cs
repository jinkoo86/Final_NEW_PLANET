using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("othername:" + collision.transform.name);


        anim.enabled = true;
        Destroy(gameObject, 30);

    }
}
