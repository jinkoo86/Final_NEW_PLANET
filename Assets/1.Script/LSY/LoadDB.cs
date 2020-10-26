using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadDB : MonoBehaviour
{
    GameObject textMoney;
    int myMoney;

    // Start is called before the first frame update
    void Start()
    {
        DB();
        textMoney = GameObject.Find("Money_Text");
        textMoney.GetComponent<Text>().text = myMoney.ToString();//게임오브젝트의 텍스트 컴포넌트를 가져와 최초로 돈을 가져와 표시한다

    }
    public void DB() { 
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

            string sqlQuery = "UPDATE Money SET MyMoney = 500";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Close();

            sqlQuery = "SELECT MyMoney, DailyMoney FROM Money";
            dbcmd.CommandText = sqlQuery;

            reader = dbcmd.ExecuteReader();

            while (reader.Read())//셀렉트
            {
                print("2LoadDB while진입 성공");
                myMoney = reader.GetInt32(0);
                int dailyMoney = reader.GetInt32(1);

                Debug.Log("myMoney: " + myMoney + "dailyMoney: " + dailyMoney);
            }
            reader.Close();

            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
