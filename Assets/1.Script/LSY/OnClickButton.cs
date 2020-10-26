using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{
    GameObject leftBtn;
    GameObject rightBtn;

    // Start is called before the first frame update
    void Start()
    {
        leftBtn = GameObject.Find("Left_Btn");
        rightBtn = GameObject.Find("Left_Btn");
    }
    public void ClickLeftBtn()
    {
        print("왼쪽 버튼이 클릭 되었음");
        StageManager.instance.PreStage(1);
    }
    public void ClickRightBtn()
    {
        print("오른쪽 버튼이 클릭 되었음");
        StageManager.instance.NextStage(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
