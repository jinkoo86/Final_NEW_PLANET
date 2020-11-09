using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//컴플레인, 플레이 타임, 강도 처치 수 , 총 수익

public class ResultUI : MonoBehaviour
{
    public static ResultUI instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject resultUI;
    public Text Profit;
    public Text robber;
    public Text complain;
    public Text playTime;
    public Text tips;
    float r; //robber
    float p; //playtime
    float complainScore;
    float playtimeScore;
    public Slider slider;

    void Start()
    {
        resultUI.SetActive(false);
    }

    void Update()
    {
        ResultData();
    }

    //Home으로 돌아가는 버튼
    public void OnClickHome()
    {
        SceneManager.LoadScene("WaitingRoom_SEJ");
    }

    //재시작하는 버튼  
    public void OnClickRestart()
    {
        SceneManager.LoadScene("StageRoom_SEJ");
    }

    public void ResultData()
    {
        //총 수익
        Profit.text = GameManager.Instance.Profit.ToString("F1");

        //컴플레인 수 : 컴플레인개수(50%)컴플레인1개->50% 컴플레인2개->40%, 컴플레인3개부터->30%
        switch (GameManager.Instance.Complain)
        {
            case 1:
                complainScore = 50;
                
                break;
            case 2:
                complainScore = 40;
                break;
            case 3:
                complainScore = 30;
                break;
        }
        complain.text = GameManager.Instance.Complain.ToString("F1");

        //강도 출현 수 : 강도처치여부(30%): 잡은강도수/전체강도수*30%
        r = (GameManager.Instance.KillRobberCount / GameManager.Instance.RobberCount) * (1 / 30);
        robber.text = GameManager.Instance.RobberCount.ToString("F0");

        // 플레이 시간 : 플레이타임비율계산(20%) = A : 게임중 발생한 주문음식의 총 시간계산 / B : 전체 플레이타임
        // B/A=0.7 ~ : 20% // B/A=0.8 ~ : 15% // B/A=0.9 ~ : 10%
        if (p>=0.7f&&p<0.8)
        {
            playtimeScore = 20;
        }
        else if(p>=0.8f && p<0.9f)
        {
            playtimeScore = 15f;
        }
        else if(p >= 0.9f && p < 1.0f)
        {
            playtimeScore = 10f;
        }
        playTime.text = p.ToString("F");
        
        //슬라이더 점수 매기는 부분 
        switch (complainScore + playtimeScore + r)
        {
            case 40:
                slider.value = 30;
                tips.text = "5000won";
                break;
            case 60:
                slider.value = 60;
                tips.text = "10000won";
                break;
            case 80:
                slider.value = 100;
                tips.text = "50000won";
                break;
        }
    }
           
}
