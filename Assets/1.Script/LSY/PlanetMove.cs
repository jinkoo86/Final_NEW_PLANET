using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //위아래로 반복운동
        if (transform.position.y < 2.1f)
        {
            a = 1;
        }
        else if (transform.position.y > 2.2f)
        {
            a = -1;
        }
       transform.Translate(Vector3.up * 0.08f * Time.deltaTime * a);
    }
}
