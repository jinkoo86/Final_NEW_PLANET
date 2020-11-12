using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject[] hammerInfo;
    public GameObject[] knifeInfo;
    public GameObject[] grillInfo;

    public GameObject pos_Heart;
    public GameObject pos_Timer;
    public GameObject pos_Hammer;
    public GameObject pos_Knife;
    public GameObject pos_Grill;

    GameObject[] heartUI = new GameObject[3];
    GameObject[] timerUI = new GameObject[3];
    GameObject[] hammerUI = new GameObject[4];
    GameObject[] knifeUI = new GameObject[4];
    GameObject[] grillUI = new GameObject[4];
    TextMeshProUGUI[] hammerInfoUI = new TextMeshProUGUI[3];
    TextMeshProUGUI[] knifeInfoUI = new TextMeshProUGUI[3];
    TextMeshProUGUI[] grillInfoUI = new TextMeshProUGUI[3];

    GameObject maxLevel;

    ParticleSystem partHeart;
    ParticleSystem partTimer;

    GameObject buyUI;

    //버튼
    Button buyBtnHeart;
    Button buyBtntimer;
    Button StartBtn;

    GameObject preBtn;
    GameObject nextBtn;
    // Start is called before the first frame update
    public void SetUI()
    {
        for(int i = 0; i < heartUI.Length; i++)//개수만큼 넣어주고 비활성화 시킨다
        {
            heartUI[i] = pos_Heart.transform.GetChild(i).gameObject;//info - buy - nomoney
            timerUI[i] = pos_Timer.transform.GetChild(i).gameObject;//info - buy - nomoney
            heartUI[i].SetActive(false);
            timerUI[i].SetActive(false);
        }
        for (int i = 0; i < hammerUI.Length; i++)//개수만큼 넣어주고 비활성화 시킨다
        {
            hammerUI[i] = pos_Hammer.transform.GetChild(i).gameObject;//info - upgrade - nomoney - maxlevel
            knifeUI[i] = pos_Knife.transform.GetChild(i).gameObject;//info - upgrade - nomoney - maxlevel
            grillUI[i] = pos_Grill.transform.GetChild(i).gameObject;//info - upgrade - nomoney - maxlevel
            if(i == 0)
            {
                hammerInfoUI = hammerUI[0].GetComponentsInChildren<TextMeshProUGUI>();//1-2-3
                knifeInfoUI = knifeUI[0].GetComponentsInChildren<TextMeshProUGUI>();//1-2-3
                grillInfoUI = grillUI[0].GetComponentsInChildren<TextMeshProUGUI>();//1-2-3
            }
            hammerUI[i].SetActive(false);
            knifeUI[i].SetActive(false);
            grillUI[i].SetActive(false);
        }
    }
    void Start()
    {
        SetUI();
        preBtn = GameObject.Find("Left_Btn");
        nextBtn = GameObject.Find("Right_Btn");

        buyBtnHeart = GameObject.Find("Buy_Heart_Btn").GetComponent<Button>();
        buyBtntimer = GameObject.Find("Buy_Timer_Btn").GetComponent<Button>();
        StartBtn = GameObject.Find("Start_Btn").GetComponent<Button>();

        partHeart = GameObject.Find("Buy_Heart_Btn").GetComponentInChildren<ParticleSystem>();
        partTimer = GameObject.Find("Buy_Timer_Btn").GetComponentInChildren<ParticleSystem>();

    }
    public void SetStageBtn(int stage)
    {
        switch (stage)
        {
            case 1:
                preBtn.SetActive(false);
                break;
            case 5:
                nextBtn.SetActive(false);
                break;
            default:
                preBtn.SetActive(true);
                nextBtn.SetActive(true);
                break;
        }
    }
    public void MaxLevelInfo(string name)//장비관련
    {
        switch (name)
        {
            case "Hammer":
                hammerUI[3].SetActive(true);
                Invoke("MaxLevelMsgOff", 2.0f);
                break;
            case "Knife":
                knifeUI[3].SetActive(true);
                Invoke("MaxLevelMsgOff", 2.0f);
                break;
            case "Grill":
                grillUI[3].SetActive(true);
                Invoke("MaxLevelMsgOff", 2.0f);
                break;
            default:
                break;
        }
    }
   
    public void InfoMsgOn(string name)//상세정보 알림켜짐
    {
        switch (name)
        {
            case "Heart":
                heartUI[0].SetActive(true);
                break;
            case "Timer":
                timerUI[0].SetActive(true);
                break;
            case "HammerPos":
                hammerUI[0].SetActive(true);
                switch (EquipManager.instance.equipList[0].level)
                {
                    case 1:
                        hammerInfoUI[0].enabled = true;
                        hammerInfoUI[1].enabled = false;
                        hammerInfoUI[2].enabled = false;
                        break;
                    case 2:
                        hammerInfoUI[0].enabled = false;
                        hammerInfoUI[1].enabled = true;
                        hammerInfoUI[2].enabled = false;
                        break;
                    case 3:
                        hammerInfoUI[0].enabled = false;
                        hammerInfoUI[1].enabled = false;
                        hammerInfoUI[2].enabled = true;
                        break;
                    default:
                        break;
                }
                break;
            case "KnifePos":
                knifeUI[0].SetActive(true);
                switch (EquipManager.instance.equipList[1].level)
                {
                    case 1:
                        knifeInfoUI[0].enabled = true;
                        knifeInfoUI[1].enabled = false;
                        knifeInfoUI[2].enabled = false;
                        break;
                    case 2:
                        knifeInfoUI[0].enabled = false;
                        knifeInfoUI[1].enabled = true;
                        knifeInfoUI[2].enabled = false;
                        break;
                    case 3:
                        knifeInfoUI[0].enabled = false;
                        knifeInfoUI[1].enabled = false;
                        knifeInfoUI[2].enabled = true;
                        break;
                    default:
                        break;
                }
                break;
            case "GrillPos":
                grillUI[0].SetActive(true);
                switch (EquipManager.instance.equipList[2].level)
                {
                    case 1:
                        grillInfoUI[0].enabled = true;
                        grillInfoUI[1].enabled = false;
                        grillInfoUI[2].enabled = false;
                        break;
                    case 2:
                        grillInfoUI[0].enabled = false;
                        grillInfoUI[1].enabled = true;
                        grillInfoUI[2].enabled = false;
                        break;
                    case 3:
                        grillInfoUI[0].enabled = false;
                        grillInfoUI[1].enabled = false;
                        grillInfoUI[2].enabled = true;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    public void InfoMsgOff()
    {
        heartUI[0].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        timerUI[0].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        hammerUI[0].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        knifeUI[0].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        grillUI[0].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
    }
    public void BuyMsgOff()
    {
        heartUI[1].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        timerUI[1].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        hammerUI[1].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        knifeUI[1].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        grillUI[1].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
    }
    public void NoMoneyMsgOff()
    {
        heartUI[2].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        timerUI[2].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        hammerUI[2].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        knifeUI[2].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        grillUI[2].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        //noMoney.SetActive(false);
    }
    public void MaxLevelMsgOff()
    {
        hammerUI[3].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        knifeUI[3].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
        grillUI[3].GetComponent<Animator>().SetTrigger("Close");//애니메이션 close(eventplay메소드 실행, SetActive(false)실행)
    }
    public void NoMoney(string name)//돈이 없다는 것을 표시 
    {
        switch (name)
        {
            case "heart" ://하트면
                heartUI[2].SetActive(true);
                Invoke("NoMoneyMsgOff", 2.0f);
                break;
            case "timer"://타이머면 
                timerUI[2].SetActive(true);
                Invoke("NoMoneyMsgOff", 2.0f);
                break;
            case "Hammer1":
            case "Hammer2":
            case "Hammer3":
                hammerUI[0].SetActive(false);
                hammerUI[2].SetActive(true);
                Invoke("NoMoneyMsgOff", 2.0f);
                break;
            case "Knife1":
            case "Knife2":
            case "Knife3":
                knifeUI[2].SetActive(true);
                Invoke("NoMoneyMsgOff", 2.0f);
                break;
            case "Grill1":
            case "Grill2":
            case "Grill3":
                grillUI[2].SetActive(true);
                Invoke("NoMoneyMsgOff", 2.0f);
                break;
        }
    }


    public void BtnItemCheck()//아이템 재고에 따른 버튼, 이펙트 조절
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
        }if(EquipManager.instance.equipList[0].level == 3)
        {

        }
    }

    public void BtnStart(int stage)
    {
        //처음에 로드한 스테이지의 lock정보를 가지고 있는 리스트의 값을 현재 눌린 스테이지의 값과 비교
        //열렸을 경우 스타트 버튼 활성화, 잠겼을 경우 스타트 버튼 비활성화
        //0 = 열림, 1 = 잠김
        if(StageManager.instance.stageLock[stage-1] == 0)
        {
            StartBtn.interactable = true;
        }
        else
        {
            StartBtn.interactable = false;
        }
    }
    public void UpgradeEquipUI(string name)
    {
        if (name.Contains("Hammer"))
        {
            hammerUI[1].SetActive(true);
            Invoke("BuyMsgOff", 2.0f);
        }
        if (name.Contains("Knife"))
        {
            knifeUI[1].SetActive(true);
            Invoke("BuyMsgOff", 2.0f);
        }
        if (name.Contains("Grill"))
        {
            grillUI[1].SetActive(true);
            Invoke("BuyMsgOff", 2.0f);
        }
    }
    public void BuyItemUI(string name)
    {
        switch (name)
        {
            case "heart":
                heartUI[1].SetActive(true);
                Invoke("BuyMsgOff", 2.0f);
                break;
            case "timer":
                timerUI[1].SetActive(true);
                Invoke("BuyMsgOff", 2.0f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BtnItemCheck();
    }
}
