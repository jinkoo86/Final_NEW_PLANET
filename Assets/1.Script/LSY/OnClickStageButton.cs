using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickStageButton : MonoBehaviour
{
    GameObject g_stageNum;
    StageNum sNum;

    public void ClickLeftBtn()
    {
        print("왼쪽 버튼이 클릭 되었음");
        StageManager.instance.PreStage();
    }
    public void ClickRightBtn()
    {
        print("오른쪽 버튼이 클릭 되었음");
        StageManager.instance.NextStage();
    }

    public void SetStageNum()//현재의 스테이지 넘버를 DontDestroyOnLoad 하기 위해 저장한다
    {
        g_stageNum = GameObject.Find("StageNum");
        sNum = g_stageNum.GetComponent<StageNum>();
        sNum.StageNumber = StageManager.instance.MyStage;
    }
    public void ClickStartBtn()//스테이지를 시작한다
    {
        if (StageManager.instance.stageLock[StageManager.instance.MyStage - 1] == 0)//현재 스테이지의 잠금이 해제된 상태일 경우만 시작 가능
        {
            SetStageNum();
            SceneManager.LoadScene(1);
            DontDestroyOnLoad(g_stageNum);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
