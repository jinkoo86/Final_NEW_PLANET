﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ClickNextStage()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StageManager.instance.NextStage(1);
            print("오른쪽 키 입력");
        }
        
    }
    
    /*private void OnTriggerEnter(Collider other)
    {
        ClickNextStage();
        print("터치");
    }*/
    // Update is called once per frame
    void Update()
    {
        ClickNextStage();
    }
}
