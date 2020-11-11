using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickBuyButton : MonoBehaviour
{
    public Text a;
    public Text b;
    public Text c;
    // Start is called before the first frame update
    void Start()
    {

    }
 
    public void ClickBuyHeartBtn()//하트 아이템 구매
    {
        if(ItemManager.instance.HeartStock == 0)
        {
            a.text = "하트구매메소드 실행";
            DBManager.instance.UseMoney_Item("heart", ItemManager.instance.HeartPrice);
        }
        print("하트구매버튼 눌렸음");
    }
    public void ClickBuyTimerBtn()//타이머 아이템 구매
    {
        if (ItemManager.instance.TimerStock == 0)
        {
            a.text = "타이머 메소드 실행";
            DBManager.instance.UseMoney_Item("timer", ItemManager.instance.TimerPrice);
            print("타이머구매버튼 눌렸음");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
