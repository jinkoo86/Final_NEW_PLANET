using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    public GameObject effect;

    // private float currentTime;
    // public float createTime = 3.0f;
    // Start is called before the first frame update
 

    private void OnParticleTrigger(GameObject collision)
    {
        //currentTime += Time.deltaTime;
        // if (currentTime > createTime)
        // {

        GameObject e = Instantiate(effect) as GameObject;
        e.transform.position = transform.position;
            Debug.Log("닿았다");


        //     currentTime = 0;
        // }
    }

}
