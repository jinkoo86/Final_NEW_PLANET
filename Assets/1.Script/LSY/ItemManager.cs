﻿using Mono.Data.Sqlite;
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
        instance = this;
        //DBManager.instance.LoadItemDB();
    }

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

}
