using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
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
    public float score;
    int tip;

    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;

    void Start()
    {
        resultUI.SetActive(false);
        SetDBPath();
        ResultData();
        //SliderValueChange();
        //DB.instance.DailyMoney = GameManager.Instance.Profit + tip;
    }

    void Update()
    {
       
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
        Profit.text = GameManager.Instance.Profit.ToString();


        //컴플레인 수 : 컴플레인개수(50%)컴플레인1개->50% 컴플레인2개->40%, 컴플레인3개부터->30%
        //GameManager.Instance.Complain
        switch (GameManager.Instance.Complain)
        {
            case 1:
                complainScore = 50;

                break;
            case 2:
                complainScore = 40;
                break;
            default:
                complainScore = 30;
                break;
        }
        complain.text = GameManager.Instance.Complain.ToString("F1");

        //강도 출현 수 : 강도처치여부(30%): 잡은강도수/전체강도수*30%
        //r = (GameManager.Instance.KillRobberCount / GameManager.Instance.RobberCount) * (1 / 30);
        //위에거 주석 풀어야함
        r = 10;
        robber.text = GameManager.Instance.RobberCount.ToString("F0");

        // 플레이 시간 : 플레이타임비율계산(20%) = A : 게임중 발생한 주문음식의 총 시간계산 / B : 전체 플레이타임
        // B/A=0.7 ~ : 20% // B/A=0.8 ~ : 15% // B/A=0.9 ~ : 10%
        p = GameManager.Instance.RemainOrderTime / GameManager.Instance.playTime;

        if (p >= 0.7f && p < 0.8)
        {
            playtimeScore = 20;
        }
        else if (p >= 0.8f && p < 0.9f)
        {
            playtimeScore = 15f;
        }
        else if (p >= 0.9f && p < 1.0f)
        {
            playtimeScore = 10f;
        }
        playTime.text = p.ToString("F");

        //슬라이더 점수 매기는 부분 
        //score = complainScore + playtimeScore + r;
        score = 60;
        /*switch (score)
        {
            case 40:
                slider.value = 0.3f;
                tips.text = "5000won";
                break;
            case 60:
                slider.value = 0.6f;
                tips.text = "10000won";
                break;
            case 80:
                slider.value = 1.0f;
                tips.text = "50000won";
                break;
        }*/
        if (score >= 90)
        {
            tips.text = "50000won";
            tip = 5000;
        }
        else if (score >= 65)
        {
            tips.text = "10000won";
            tip = 10000;
        }
        else
        {
            tips.text = "5000won";
            tip = 5000;
        }
        SliderValueChange();

    }
    
    int i = 0;
    public void SliderValueChange()
    {
        if (i == 0 )
        {
            //slider.value = score;
            //print("들어오나");
            //전체점수 40%~ : 별한개
            //전체점수 65 % ~ : 별한개
            //전체점수 90 % ~ : 별한개
            if (score >= 90)
            {
                slider.value = 1.0f;
            }
            else if (score >= 65)
            {
                slider.value = 0.6f;
            }
            else
            {
                slider.value = 0.3f;
            }
            /*i++;
            Debug.Log(i)*/;
        }
        
    }
    //DB
    public void UpdateSystemDB(string MyMoney, int a) //디비 오픈하고 쿼리문으로 제어하는 곳
    {
        try
        {
            con.Open(); //DB접속
            dbcmd = con.CreateCommand(); //여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty; //내가 입력할 명령어를 위한 값 = 비운다

            //sqlQuery = "SELECT Volume, Vibration FROM SystemOption";//aa를 조회한다 ㅇㅇ에서 //내가 건들 곳
            sqlQuery = "UPDATE Money SET " + MyMoney + " = " + a;//aa를 한다 ㅇㅇ에서 //내가 건들 곳
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            reader.Close();

            //
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
        DB.instance.DailyMoney = GameManager.Instance.Profit + tip;
    }

    public void SetDBPath()//디비 경로 잡아주는 곳
    {
        filepath = string.Empty;
        if (Application.platform == RuntimePlatform.Android)//실행플랫폼이 안드로이드일 경우
        {
            //안드로이드 일 경우
            filepath = Application.persistentDataPath + "/DB.db";
            if (!File.Exists(filepath))
            {
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/DB.db");
                loadDB.bytesDownloaded.ToString();
                while (!loadDB.isDone) { }
                File.WriteAllBytes(filepath, loadDB.bytes);
            }
        }
        else
        {
            //윈도우 일 경우
            filepath = Application.dataPath + "/StreamingAssets/DB.db";
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/DB.db", filepath);
                //print(filepath);
            }
        }
        try
        {
            temp_path = "URI=file:" + filepath;
            con = new SqliteConnection(temp_path);


        }
        catch (Exception e)
        {
            print(e);
        }
    }
}
