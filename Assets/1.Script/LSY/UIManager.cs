using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    GameObject PosHeart;
    GameObject PosTimer;
    GameObject noMoney;
    GameObject itemInfo_Heart;
    GameObject itemInfo_Timer;
    ParticleSystem partHeart;
    ParticleSystem partTimer;

    GameObject buyUI;

    Button buyBtnHeart;
    Button buyBtntimer;
    // Start is called before the first frame update
    void Start()
    {
        PosHeart = GameObject.Find("Pos_Heart/Buy_Img");
        PosTimer = GameObject.Find("Pos_Timer/Buy_Img");
        itemInfo_Heart = GameObject.Find("Pos_Heart/HeartInfo_Img");
        itemInfo_Timer = GameObject.Find("Pos_Timer/TimerInfo_Img");

        //처음 구매완료 ui는 비 활성화 시킨다
        PosHeart.SetActive(false);
        PosTimer.SetActive(false);
        itemInfo_Heart.SetActive(false);
        itemInfo_Timer.SetActive(false);

        noMoney = GameObject.Find("NoMoney_img");
        noMoney.SetActive(false);

        buyBtnHeart = GameObject.Find("Buy_Heart_Btn").GetComponent<Button>();
        buyBtntimer = GameObject.Find("Buy_Timer_Btn").GetComponent<Button>();

        partHeart = GameObject.Find("Buy_Heart_Btn").GetComponentInChildren<ParticleSystem>();
        partTimer = GameObject.Find("Buy_Timer_Btn").GetComponentInChildren<ParticleSystem>();

    }
    public void InfoMsgOn(string name)
    {
        switch (name)
        {
            case "Heart":
                itemInfo_Heart.SetActive(true); 
                break;
            case "Timer":
                itemInfo_Timer.SetActive(true); 
                break;
            default:
                break;
        }
    }
    public void InfoMsgOff(string name)
    {
        switch (name)
        {
            case "Heart":
                itemInfo_Heart.SetActive(false);
                break;
            case "Timer":
                itemInfo_Timer.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void NoMoney(string name)//돈이 없다는 것을 표시 
    {
        switch (name)
        {
            case "heart" ://하트면
                noMoney.transform.position = PosHeart.transform.position;
                Invoke("NoMoneyMsgOff", 2.0f);
                noMoney.SetActive(true);
                break;
            case "timer"://타이머면 
                noMoney.transform.position = PosTimer.transform.position;
                Invoke("NoMoneyMsgOff", 2.0f);
                noMoney.SetActive(true);
                break;
        }
    }
    public void NoMoneyMsgOff()
    {
        noMoney.SetActive(false);
    }
    public void BuyMsgOff_Heart()
    {
        PosHeart.SetActive(false);
    }
    public void BuyMsgOff_Timer()
    {
        PosTimer.SetActive(false);
    }
    public void BtnItem()
    {
        if (ItemManager.instance.HeartStock == 1)
        {
            buyBtnHeart.interactable = false;
            partHeart.Stop();
        }
        if(ItemManager.instance.TimerStock == 1)
        {
            buyBtntimer.interactable = false;
            partTimer.Stop();
        }
        if (ItemManager.instance.HeartStock == 0)
        {
            buyBtnHeart.interactable = true;
            partHeart.Play();
        }
        if (ItemManager.instance.TimerStock == 0)
        {
            buyBtntimer.interactable = true;
            partTimer.Play();
        }
    }
    public void BtnCheck(string name)
    {
        switch (name)
        {
            case "heart":
                if (ItemManager.instance.HeartStock == 1)
                {
                    buyBtnHeart.interactable = false;
                }
                if (ItemManager.instance.HeartStock == 0)
                {
                    buyBtnHeart.interactable = true;
                    noMoney.transform.position = PosHeart.transform.position;
                    Invoke("NoMoneyMsgOff", 2.0f);
                    noMoney.SetActive(true);
                }
                break;
            case "timer":
                if (ItemManager.instance.TimerStock == 1)
                {
                    buyBtnHeart.interactable = false;
                }
                if (ItemManager.instance.TimerStock == 0)
                {
                    buyBtntimer.interactable = false;
                    noMoney.transform.position = PosTimer.transform.position;
                    Invoke("NoMoneyMsgOff", 2.0f);
                    noMoney.SetActive(true);
                }
                break;
        }
    }
    public void SetBuyItemUI(string name)
    {
        switch (name)
        {
            case "heart":
                PosHeart.SetActive(true);
                Invoke("BuyMsgOff_Heart", 2.0f);
                break;
            case "timer":
                PosTimer.SetActive(true);
                Invoke("BuyMsgOff_Timer", 2.0f);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        BtnItem();
    }
}
