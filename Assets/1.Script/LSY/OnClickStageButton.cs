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
        DBManager.instance.PreStage(1);
    }
    public void ClickRightBtn()
    {
        print("오른쪽 버튼이 클릭 되었음");
        DBManager.instance.NextStage(1);
    }

    public void SetStageNum()//현재의 스테이지 넘버를 DontDestroyOnLoad 하기 위해 저장한다
    {
        g_stageNum = GameObject.Find("StageNum");
        sNum = g_stageNum.GetComponent<StageNum>();
        sNum.StageNumber = StageManager.instance.MyStage;
    }
    public void ClickStartBtn()//스테이지를 시작한다
    {
        SetStageNum();
        SceneManager.LoadScene(2);
        DontDestroyOnLoad(g_stageNum);
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
