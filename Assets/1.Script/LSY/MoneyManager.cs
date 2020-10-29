using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;

    GameObject textMoney;
    int myMoney;
    public static MoneyManager instance;
    private void Awake()
    {
        SetDBPath();
        LoadMoneyDB();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMoney = GameObject.Find("Money_Text");
        textMoney.GetComponent<Text>().text = myMoney.ToString();//게임오브젝트의 텍스트 컴포넌트를 가져와 최초로 돈을 가져와 표시한다

    }
    public void CheckMoney()
    {
        textMoney.GetComponent<Text>().text = myMoney.ToString();

    }
    public void UseMoney(string name, int money)//구매 버튼을 누르면 호출, 버튼이 비 활성화 되면 호출 안되어야 하는데 호출 된다
    {
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;
            if(myMoney < money || myMoney <= 0)//잔액이 부족한 경우: 내 돈이 0원보다 적거나 아이템보다 적은 돈이 있거나 
            {
                print("잔액 부족");
                print("money"+money);
                print(myMoney);
                UIManager.instance.NoMoney(name);
            }
            else
            {
                int temp = myMoney - money;
                sqlQuery = "UPDATE Money SET MyMoney = " + temp;
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();
                reader.Close();
                myMoney = temp;
                CheckMoney();
                ItemManager.instance.BuyItemDB(name, 1);
            }
            
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    public void LoadMoneyDB()
    {
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;
    
            sqlQuery = "UPDATE Money SET MyMoney = 1000";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
            reader.Close();

            sqlQuery = "SELECT MyMoney FROM Money";
            dbcmd.CommandText = sqlQuery;

            reader = dbcmd.ExecuteReader();

            while (reader.Read())//셀렉트
            {
                print("2LoadDB while진입 성공");
                myMoney = reader.GetInt32(0);

                Debug.Log("myMoney: " + myMoney);
            }
            reader.Close();
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
