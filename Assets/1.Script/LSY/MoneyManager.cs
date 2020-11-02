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

    public int MyMoney { 
        get { return myMoney; } 
        set { myMoney = value; }
    }

    private void Awake()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
