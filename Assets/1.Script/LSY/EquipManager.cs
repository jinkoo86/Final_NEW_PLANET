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
        instance = this;
    }
    /*string hammerName;
    string grillName;
    string knifeName;
    int equiplevel;*/

    public GameObject[] hammers;
    public GameObject[] grills;
    public GameObject[] knives;
    GameObject hammerPos;
    GameObject grillPos;
    GameObject knifePos;
    GameObject hammer;
    GameObject grill;
    GameObject knife;


    public struct Equip
    {
        public string name;
        public int level;
    }
    public List<Equip> equipList = new List<Equip>();

    // Start is called before the first frame update
    void Start()
    {
        hammerPos = GameObject.Find("HammerPos");
        grillPos = GameObject.Find("GrillPos");
        knifePos = GameObject.Find("KnifePos");
        PrintList();
        SetEquip();

    }
    public void SetEquip()
    {

        hammer = Instantiate(hammers[(equipList[0].level) - 1]);
        hammer.transform.SetParent(hammerPos.transform);
        //hammers[(equipList[0].level)-1].transform.position = hammerPos.transform.position;

        grill = Instantiate(grills[(equipList[1].level) - 1]);
        grill.transform.SetParent(grillPos.transform);
        //grills[(equipList[1].level) - 1].transform.position = grillPos.transform.position;

        knife = Instantiate(knives[(equipList[2].level) - 1]);
        knife.transform.SetParent(knifePos.transform);
        //knives[(equipList[2].level) - 1].transform.position = knifePos.transform.position;
    }
    
    public void PrintList()
    {
        for(int i = 0; i<equipList.Count; i++)
        {
            print(equipList[i].name + equipList[i].level);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddEquipData(string name, int level)//리스트에 데이터(장비이름, 장비레벨)을 넣어주기 위한 메소드
    {
        Equip data = new Equip();//변수 선언
        data.name = name;
        data.level = level;
        equipList.Add(data);
    }
}
