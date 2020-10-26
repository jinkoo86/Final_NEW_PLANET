using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickButton : MonoBehaviour
{
    /*GameObject leftBtn;
    GameObject rightBtn;*/
    GameObject g_stageNum;
    StageNum sNum;
    // Start is called before the first frame update
    void Start()
    {
/*        leftBtn = GameObject.Find("Left_Btn");
        print(leftBtn.name);
        rightBtn = GameObject.Find("Right_Btn");
        print(rightBtn.name);*/
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

    public void SetStageNum()//현재의 스테이지 넘버를 DontDestroyOnLoad 하기 위해 저장한다
    {
        g_stageNum = GameObject.Find("StageNum");
        sNum = g_stageNum.GetComponent<StageNum>();
        sNum.StageNumber = StageManager.instance.GetMyStage();
    }
    public void ClickStartBtn()//스테이지를 시작한다
    {
        SetStageNum();
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(g_stageNum);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
