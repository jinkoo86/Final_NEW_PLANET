using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnClickButton : MonoBehaviour
{
    GameObject g_stageNum;
    StageNum sNum;

    // Start is called before the first frame update
    void Start()
    {

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
    public void ClickBuyHeartBtn()//하트 아이템 구매
    {
        if(ItemManager.instance.HeartStock == 0)
        {
            MoneyManager.instance.UseMoney("heart", ItemManager.instance.HeartPrice);
        }
        
        
        print("하트구매버튼 눌렸음");
    }
    public void ClickBuyTimerBtn()//타이머 아이템 구매
    {
        if (ItemManager.instance.TimerStock == 0)
        {
            MoneyManager.instance.UseMoney("timer", ItemManager.instance.TimerPrice);
            print("타이머구매버튼 눌렸음");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
