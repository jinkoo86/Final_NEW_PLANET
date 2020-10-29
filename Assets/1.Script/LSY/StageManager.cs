using Mono.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    //시작하면 한번 스테이지의 정보를 가져온다
    //스테이지 번호, 스테이지 별점-> LoadDB()
    //화살표를 통해 스테이지를 조절하면 그에 맞게 스테이지 정보를 변경한다
    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;

    public static StageManager instance;
    private void Awake()
    {
        SetDBPath();//디비 path설정
        LoadStageDB();//최초 스테이지 넘버, 별점을 가져온다
        SetStageInfo();
        instance = this;
    }
    private int stageStar;
    private bool stageLock;
    private int myStage;
    public int GetMyStage()
    {
        return myStage;
    }
    GameObject textStage;
    GameObject[] stars;
    GameObject tempStars;
    StageNum stageNum;
    GameObject pos;

    public List<GameObject> planetList;

    // Start is called before the first frame update
    void Start()
    {

        //stars = GameObject.FindGameObjectsWithTag("Star");// star태그로 검색해 starts에 배열저장

    }
    void Update()
    {
        
    }

    public void SetStageInfo()//update에서 스테이지 정보 갱신
    {
        textStage = GameObject.Find("Planet_Text");
        textStage.GetComponent<Text>().text = "PLANET: " + myStage.ToString();//스테이지 넘버 입력
        SetStars();

    }
    public void NextStage(int stage)
    {
        if (myStage < 5)
        {
            myStage++;
            try
            {
                con.Open();
                print("업데이트 쪽 오픈성공");

                dbcmd = con.CreateCommand();
                sqlQuery = string.Empty;

                sqlQuery = "SELECT StageLevel, StageStar FROM Stage WHERE StageLevel =" + myStage;//myStage+1인(다음스테이지) 스테이지 레벨을 가져온다 
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();

                while (reader.Read())//완료한 스테이지 번호를 가져온다
                {
                    myStage = reader.GetInt32(0);
                    stageStar = reader.GetInt32(1);

                    Debug.Log("myStage: " + myStage);
                }
                reader.Close();
                //
                con.Close();
                SetStageInfo();
            }
            catch (Exception e)
            {
                print(e);
            }
        }
        else
        {
            print("입력 종료");
        }
        
    }
    public void PreStage(int stage)
    {
        if (myStage > 1)
        {
            myStage--;
            try
            {
                con.Open();
                print("업데이트 쪽 오픈성공");

                dbcmd = con.CreateCommand();
                sqlQuery = string.Empty;

                sqlQuery = "SELECT StageLevel, StageStar FROM Stage WHERE StageLevel =" + myStage;//myStage+1인(다음스테이지) 스테이지 레벨을 가져온다 
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();

                while (reader.Read())//완료한 스테이지 번호를 가져온다
                {
                    myStage = reader.GetInt32(0);
                    stageStar = reader.GetInt32(1);

                    Debug.Log("myStage: " + myStage);
                }
                reader.Close();
                //
                con.Close();
                SetStageInfo();
            }
            catch (Exception e)
            {
                print(e);
            }
        }
        else
        {
            print("입력 종료");
        }

    }
    public void SetStars()
    {
        stars = new GameObject[3];
        tempStars = GameObject.Find("Stars_Img");
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i] = tempStars.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < stageStar; i++)//별개수 만큼 별이미지 활성화
        {
            stars[i].GetComponent<Image>().enabled = true;
        }
        for (int i = stageStar; i < stars.Length; i++) //별개수 제외하고 별 이미지 비활성화
        {
            stars[i].GetComponent<Image>().enabled = false;
        }
        
    }
    // Update is called once per frame

    public void LoadStageDB()
    {
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;

            sqlQuery = "SELECT MyStage FROM MyStage";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//완료한 스테이지 번호를 가져온다
            {
                myStage = reader.GetInt32(0);

                Debug.Log("myStage: " + myStage);
            }
            reader.Close();

            sqlQuery = "SELECT StageStar FROM Stage WHERE StageLevel =" + myStage;
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//위의 스테이지의 별점을 가져온다
            {
                stageStar = reader.GetInt32(0);

                Debug.Log("stageStar: " + stageStar);
            }
            reader.Close();
            //
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }

    }
    public void SetDBPath()
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
            

        }catch(Exception e)
        {
            print(e);
        }
    }
}
