using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public static EquipManager instance;
    private void Awake()
    {
        //SetDBPath();
        //LoadEquipDB();
        instance = this;
    }
    string filepath;
    IDataReader reader;
    string temp_path;
    SqliteConnection con;
    IDbCommand dbcmd;
    string sqlQuery;

    string hammerName;
    string grillName;
    string knifeName;
    int equiplevel;

    Dictionary<string, int> dict;
    GameObject[] hammers;
    GameObject[] grills;
    GameObject[] knifes;
    GameObject grill;
    public struct Equip
    {
        public string name;
        public int level;
    }
    public List<Equip> equipList = new List<Equip>();
    // Start is called before the first frame update
    void Start()
    {
        dict = new Dictionary<string, int>();
        SetEquip();
    /*        dict.Add("temp", 1);
            int test;
            if(dict.TryGetValue("temp", out test))
            {
                print(test);
            }*/
        //hammers = GameObject.Find("Hammers").GetComponentsInChildren<GameObject>();

        //knifes = GameObject.Find("Knifes").GetComponentsInChildren<GameObject>();

        PrintDict();

    }
    public void SetEquip()
    {
        /*grills[0] = GameObject.Find("Grills");
        print(grills[0].name);*/
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

        //grills.GetComponentInChildren<GameObject>();
    }

    public void AddEquipData(string name, int level)//리스트에 데이터(장비이름, 장비레벨)을 넣어주기 위한 메소드
    {
        Equip data = new Equip();//변수 선언
        data.name = name;
        data.level = level;
        equipList.Add(data);
    }
}
