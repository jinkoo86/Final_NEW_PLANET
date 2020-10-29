using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;

    string equipName;
    int equiplevel;
    Dictionary<string, int> dict;
    GameObject hammer;
    GameObject grill;
    GameObject knife;

    // Start is called before the first frame update
    void Start()
    {
        dict = new Dictionary<string, int>();
        hammer = GameObject.Find("Hammer");
        grill = GameObject.Find("Grill");
        knife = GameObject.Find("Knife");
        print(dict);
        SetDBPath();
        LoadEquipDB();
        PrintDict();

    }
    public void PrintDict()
    {
        foreach (string Key in dict.Keys)
        {
            Debug.Log(Key);
        }
        foreach (int value in dict.Values)
        {
            Debug.Log(value);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateEquip()//해당 장비의 특정 자식을 회전한다
    {
        hammer.GetComponentInChildren<GameObject>();
    }
    public void LoadEquipDB()//
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
                dict.Add(reader.GetString(0), reader.GetInt32(1));

                Debug.Log("equipName: " + equipName + "equiplevel: " + equiplevel);
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
