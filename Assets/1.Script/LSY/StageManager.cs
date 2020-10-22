using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    private void Awake()
    {
        instance = this;
    }

    int stageNum;
    int stageStar;
    bool stageLock;
    int myStage;
    GameObject textStage;
    GameObject[] stars;
    // Start is called before the first frame update
    void Start()
    {
        DB();
        textStage = GameObject.Find("StageInfo");
        textStage.GetComponent<Text>().text += myStage.ToString();
        stars = new GameObject[3];
        
    }
    public void NextStage(int stage)
    {
        if (myStage < 5)
        {
            myStage++;
        }
        
    }
    public void SetStars()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");
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
    void Update()
    {
        SetStars();
    }
    public void DB()
    {
        string filepath = string.Empty;
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
            //filepath = Application.persistentDataPath + "/DB.db";
            string temp_path = "URI=file:" + filepath;
            SqliteConnection con = new SqliteConnection(temp_path);
            con.Open();

            print("업데이트 쪽 오픈성공");

            IDbCommand dbcmd = con.CreateCommand();
            string sqlQuery = string.Empty;
            IDataReader reader;

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

            while (reader.Read())//현재 스테이지의 별점을 가져온다
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
}
