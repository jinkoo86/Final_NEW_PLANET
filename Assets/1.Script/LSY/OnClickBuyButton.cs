using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickBuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
 
    public void ClickBuyHeartBtn()//하트 아이템 구매
    {
        if(ItemManager.instance.HeartStock == 0)
        {
            DBManager.instance.UseMoney("heart", ItemManager.instance.HeartPrice);
        }
        print("하트구매버튼 눌렸음");
    }
    public void ClickBuyTimerBtn()//타이머 아이템 구매
    {
        if (ItemManager.instance.TimerStock == 0)
        {
            DBManager.instance.UseMoney("timer", ItemManager.instance.TimerPrice);
            print("타이머구매버튼 눌렸음");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
