using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static DBManager instance;
    private void Awake()
    {

        instance = this;
    }

    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;
    
    /*//장비
    Dictionary<string, int> dict;
    //돈
    int myMoney;
    //스테이지
    private int stageStar;
    private int myStage;
    //아이템
    int heartStock;
    int timerStock;
    int heartPrice;
    int timerPrice;
    public int MyMoney
    {
        get { return myMoney; }
        set { myMoney = value; }
    }
    public int StageStar {
        get { return StageStar; }
        set { StageStar = value; }
    }
    public int MyStage
    {
        get { return MyStage; }
        set { myStage = value; }
    }
    public int HeartStock
    {
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
    }*/

    
    // Start is called before the first frame update
    void Start()
    {
        //dict = new Dictionary<string, int>();
        SetDBPath();
        //아래 4가지는 처음 게임시작하면 데이터를 로드하는 역할
        LoadEquipDB();
        LoadItemDB();
        LoadMoneyDB();
        LoadStageDB();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NextStage(int stage)
    {
        if (StageManager.instance.MyStage < 5)
        {
            StageManager.instance.MyStage++;
            try
            {
                con.Open();
                print("업데이트 쪽 오픈성공");

                dbcmd = con.CreateCommand();
                sqlQuery = string.Empty;

                sqlQuery = "SELECT StageLevel, StageStar FROM Stage WHERE StageLevel =" + StageManager.instance.MyStage;//myStage+1인(다음스테이지) 스테이지 레벨을 가져온다 
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();

                while (reader.Read())//완료한 스테이지 번호를 가져온다
                {
                    StageManager.instance.MyStage = reader.GetInt32(0);
                    StageManager.instance.StageStar = reader.GetInt32(1);

                    //Debug.Log("myStage: " + myStage);
                }
                reader.Close();
                //
                con.Close();
                StageManager.instance.SetStageInfo();
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
        if (StageManager.instance.MyStage > 1)
        {
            StageManager.instance.MyStage--;
            try
            {
                con.Open();
                print("업데이트 쪽 오픈성공");

                dbcmd = con.CreateCommand();
                sqlQuery = string.Empty;

                sqlQuery = "SELECT StageLevel, StageStar FROM Stage WHERE StageLevel =" + StageManager.instance.MyStage;//myStage-1인(이전스테이지) 스테이지 레벨을 가져온다 
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();

                while (reader.Read())//완료한 스테이지 번호를 가져온다
                {
                    StageManager.instance.MyStage = reader.GetInt32(0);
                    StageManager.instance.StageStar = reader.GetInt32(1);

                    //Debug.Log("myStage: " + myStage);
                }
                reader.Close();
                //
                con.Close();
                StageManager.instance.SetStageInfo();
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
    public void UseMoney(string name, int money)//구매 버튼을 누르면 호출, 버튼이 비 활성화 되면 호출 안되어야 하는데 호출 된다
    {
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;
            int myMoney = MoneyManager.instance.MyMoney;
            if (myMoney < money || myMoney <= 0)//잔액이 부족한 경우: 내 돈이 0원보다 적거나 아이템보다 적은 돈이 있거나 
            {
                print("잔액 부족");
                print("money" + money);
                print(myMoney);
                UIManager.instance.NoMoney(name);
                con.Close();
            }
            else
            {
                int spentMoney = myMoney - money;//내돈-값을 받은 돈 을 소비  한 돈에 넣어준다
                sqlQuery = "UPDATE Money SET MyMoney = " + spentMoney;
                dbcmd.CommandText = sqlQuery;
                reader = dbcmd.ExecuteReader();
                reader.Close();
                //MoneyManager.instance.MyMoney = spentMoney;
                MoneyManager.instance.CheckMoney(spentMoney);
                con.Close();
                BuyItemDB(name, 1);
            }
        }
        catch (Exception e)
        {
            print(e);
        }
    }
    public void BuyItemDB(string name, int stock)//아이템 이름과 재고를 받아와서 재고를 변경해준다
    {//여기 수정할것 아이템 구매 부분 이 메소드에 넣응면 되지 않을까?
        try
        {            
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;

            sqlQuery = "UPDATE Item SET ItemStock = " + stock + " WHERE ItemName is '" + name + "'";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
            ItemManager.instance.AddItemName(name);//윗줄에서 받은 name을 기준으로 어느 아이템을 =1해줄건지 결정한다
            UIManager.instance.SetBuyUI(name);

            reader.Close();
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
    }
    public void LoadEquipDB()//장비 레벨과 정보를 가져온다
    {
        try
        {
            con.Open();
            dbcmd = con.CreateCommand();//여기부터 sql입력을 위한 코드 
            sqlQuery = string.Empty;

            sqlQuery = "SELECT EquipName, EquipLevel FROM MyEquip";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//완료한 스테이지 번호를 가져온다
            {
                print("while문 작동 한다 ");
                EquipManager.instance.AddEquipData(reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
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
                //print("2LoadDB while진입 성공");
                //MyMoney = reader.GetInt32(0);
                MoneyManager.instance.MyMoney = reader.GetInt32(0);

                //Debug.Log("myMoney: " + MyMoney);
            }
            reader.Close();
            con.Close();
        }
        catch (Exception e)
        {
            print(e);
        }

    }
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
                //myStage = reader.GetInt32(0);
                StageManager.instance.MyStage = reader.GetInt32(0);

                //Debug.Log("myStage: " + myStage);
            }
            reader.Close();

            sqlQuery = "SELECT StageStar FROM Stage WHERE StageLevel =" + StageManager.instance.MyStage;
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//위의 스테이지의 별점을 가져온다
            {
                //stageStar = reader.GetInt32(0);
                StageManager.instance.StageStar = reader.GetInt32(0);

                //Debug.Log("stageStar: " + stageStar);
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
                /*heartStock = reader.GetInt32(0);
                heartPrice = reader.GetInt32(1);*/
                ItemManager.instance.HeartStock = reader.GetInt32(0);
                ItemManager.instance.HeartPrice = reader.GetInt32(1);
                //print("heartStock: " + heartStock + "heartPrice: " + heartPrice);
            }
            reader.Close();

            sqlQuery = "SELECT ItemStock, ItemPrice FROM Item WHERE ItemName LIKE 'timer'";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            while (reader.Read())//timer의 재고를 가져온다
            {
                /*timerStock = reader.GetInt32(0);
                timerPrice = reader.GetInt32(1);*/
                ItemManager.instance.TimerStock = reader.GetInt32(0);
                ItemManager.instance.TimerPrice = reader.GetInt32(1);
                //print("timerStock: " + timerStock + "timerPrice: " + timerPrice);
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
