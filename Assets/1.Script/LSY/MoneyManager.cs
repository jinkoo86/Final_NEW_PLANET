using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    GameObject textMoney;
    int myMoney;
    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
        //DBManager.instance.LoadMoneyDB();
    }
    public int MyMoney { 
        get { return myMoney; } 
        set { myMoney = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        textMoney = GameObject.Find("Money_Text");
        print("myMoney: " + myMoney);
    }
    public void CheckMoney(int money)
    {
        myMoney = money;
        textMoney.GetComponent<Text>().text = myMoney.ToString();
    }
  
    // Update is called once per frame
    void Update()
    {
        textMoney.GetComponent<Text>().text = myMoney.ToString();
    }
}
