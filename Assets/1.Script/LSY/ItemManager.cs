using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    private void Awake()
    {
        //디비정보를 넘겨 줘야 하기 때문에 awake에서 실행한다
        SetDBPath();
        LoadItemDB();
        instance = this;
    }

    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;

    int heartStock;
    int timerStock;
    int heartPrice;
    int timerPrice;

    // Start is called before the first frame update
    void Start()
    {
    }
    public int HeartStock {
        get { return heartStock; }
        set { heartStock = value; }
    }
    public int TimerStock
    {
        get { return timerStock; }
        set { timerStock = value; }
    }
    public int HeartPrice
    {
        get { return heartPrice; }
        set { heartPrice = value; }
    }
    public int TimerPrice
    {
        get { return timerPrice; }
        set { timerPrice = value; }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //BuyItemDB 에서 받은 이름을 기준으로 어느 아이템을 구입할건지 결정해 준다 
    public void AddItemName(string name)
    {
        switch (name)
        {
            case "heart":
                heartStock = 1;
                break;
            case "timer":
                timerStock = 1;
                break;
        }
    }
    public void BuyItemDB(string name, int stock)//아이템 이름과 재고를 받아와서 재고를 변경해준다
    {//여기 수정할것 아이템 구매 부분 이 메소드에 넣응면 되지 않을까?
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;

            sqlQuery = "UPDATE Item SET ItemStock = "+ stock +" WHERE ItemName is '"+ name + "'";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
            AddItemName(name);//윗줄에서 받은 name을 기준으로 어느 아이템을 =1해줄건지 결정한다
            UIManager.instance.SetBuyUI(name);

            reader.Close();
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
    }
    public void LoadItemDB()
    {
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;

            sqlQuery = "SELECT ItemStock, ItemPrice FROM Item WHERE ItemName LIKE 'heart'";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//heart의 재고를 가져온다
            {
                heartStock = reader.GetInt32(0);
                heartPrice = reader.GetInt32(1);
                print("heartStock: " + heartStock + "heartPrice: " + heartPrice);

            }
            reader.Close();

            sqlQuery = "SELECT ItemStock, ItemPrice FROM Item WHERE ItemName LIKE 'timer'";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//timer의 재고를 가져온다
            {
                timerStock = reader.GetInt32(0);
                timerPrice = reader.GetInt32(1);
                print("timerStock: " + timerStock + "timerPrice: " + timerPrice);

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
}
