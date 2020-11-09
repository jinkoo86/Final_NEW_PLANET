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
    GameObject posHeart;
    GameObject posTimer;
    GameObject itemBuy_Heart;
    GameObject itemBuy_Timer;
    GameObject noMoney;
    GameObject itemInfo_Heart;
    GameObject itemInfo_Timer;
    ParticleSystem partHeart;
    ParticleSystem partTimer;
    GameObject posHammer;
    GameObject posKnife;
    GameObject posGrill;
    GameObject equipInfo_Hammer;
    GameObject equipInfo_Knife;
    GameObject equipInfo_Grill;

    GameObject buyUI;

    Button buyBtnHeart;
    Button buyBtntimer;
    // Start is called before the first frame update
    void Start()
    {
        //아이템관련
        posHeart = GameObject.Find("Pos_Heart");//위치 정보
        posTimer = GameObject.Find("Pos_Timer");//위치 정보
        itemBuy_Heart = GameObject.Find("Pos_Heart/Heart_Buy_UI");//구매 UI
        itemBuy_Timer = GameObject.Find("Pos_Timer/Timer_Buy_UI");//구매 UI
        itemInfo_Heart = GameObject.Find("Pos_Heart/Heart_Detail_UI");//상세정보 UI
        itemInfo_Timer = GameObject.Find("Pos_Timer/Timer_Detail_UI");//상세정보 UI
        //장비관련
        posHammer = GameObject.Find("Pos_Hammer"); //위치 정보
        posKnife = GameObject.Find("Pos_Knife"); //위치 정보
        posGrill = GameObject.Find("Pos_Grill"); //위치 정보
        equipInfo_Hammer = GameObject.Find("Pos_Hammer/Hammer_detail_UI");//상세정보 UI
        equipInfo_Knife = GameObject.Find("Pos_Knife/Knife_detail_UI");//상세정보 UI
        equipInfo_Grill = GameObject.Find("Pos_Grill/Grill_detail_UI");//상세정보 UI

        //처음 구매완료 ui는 비 활성화 시킨다
        itemBuy_Heart.SetActive(false);
        itemBuy_Timer.SetActive(false);
        itemInfo_Heart.SetActive(false);
        itemInfo_Timer.SetActive(false);
        equipInfo_Hammer.SetActive(false);
        equipInfo_Knife.SetActive(false);
        equipInfo_Grill.SetActive(false);

        noMoney = GameObject.Find("NoMoney_img");
        noMoney.SetActive(false);

        buyBtnHeart = GameObject.Find("Buy_Heart_Btn").GetComponent<Button>();
        buyBtntimer = GameObject.Find("Buy_Timer_Btn").GetComponent<Button>();

        partHeart = GameObject.Find("Buy_Heart_Btn").GetComponentInChildren<ParticleSystem>();
        partTimer = GameObject.Find("Buy_Timer_Btn").GetComponentInChildren<ParticleSystem>();
    }

    public void InfoMsgOn(string name)
    {//애니메이션 구현 다시 할 것
        switch (name)
        {
            case "Heart":
                itemInfo_Heart.SetActive(true);
                itemInfo_Heart.GetComponent<Animator>().SetTrigger("Open");
                break;
            case "Timer":
                itemInfo_Timer.SetActive(true);
                itemInfo_Timer.GetComponent<Animator>().SetTrigger("Open");

                break;
            case "Hammer":
                equipInfo_Hammer.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void InfoMsgOff()
    {
        itemInfo_Heart.SetActive(false);
        itemInfo_Heart.GetComponent<Animator>().SetTrigger("Close");
       itemInfo_Timer.SetActive(false);
        itemInfo_Timer.GetComponent<Animator>().SetTrigger("Close");


        /*switch (name)
        {
            case "Heart":
                itemInfo_Heart.SetActive(false);
                break;
            case "Timer":
                itemInfo_Timer.SetActive(false);
                break;
            default:
                break;
        }*/
    }
    public void NoMoney(string name)//돈이 없다는 것을 표시 
    {
        switch (name)
        {
            case "heart" ://하트면
                noMoney.transform.position = posHeart.transform.position;
                Invoke("NoMoneyMsgOff", 2.0f);
                noMoney.SetActive(true);
                break;
            case "timer"://타이머면 
                noMoney.transform.position = posTimer.transform.position;
                Invoke("NoMoneyMsgOff", 2.0f);
                noMoney.SetActive(true);
                break;
            case "Hammer1":
            case "Hammer2":
            case "Hammer3":
                //해당 위치에 돈 없다는 것 표시
                noMoney.transform.position = posHammer.transform.position;
                Invoke("NoMoneyMsgOff", 2.0f);
                noMoney.SetActive(true);
                break;
            case "Knife1":
            case "Knife2":
            case "Knife3":
                //해당 위치에 돈 없다는 것 표시
                noMoney.transform.position = posKnife.transform.position; 
                Invoke("NoMoneyMsgOff", 2.0f);
                noMoney.SetActive(true);
                break;
            case "Grill1":
            case "Grill2":
            case "Grill3":
                //해당 위치에 돈 없다는 것 표시
                noMoney.transform.position = posGrill.transform.position;
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
        itemBuy_Heart.SetActive(false);
    }
    public void BuyMsgOff_Timer()
    {
        itemBuy_Timer.SetActive(false);
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
                    noMoney.transform.position = posHeart.transform.position;
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
                    noMoney.transform.position = posTimer.transform.position;
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
                itemBuy_Heart.SetActive(true);
                Invoke("BuyMsgOff_Heart", 2.0f);
                break;
            case "timer":
                itemBuy_Timer.SetActive(true);
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
