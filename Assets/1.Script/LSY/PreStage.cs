using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ClickPreStage()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StageManager.instance.PreStage(1);
            print("왼쪽 키 입력");
        }

    }
    // Update is called once per frame
    void Update()
    {
        ClickPreStage();
    }
}
