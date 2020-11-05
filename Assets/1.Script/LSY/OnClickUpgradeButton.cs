using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickUpgradeButton : MonoBehaviour
{
    public void ClickUpgradeHammerBtn()//망치 업그레이드
    {
        if (ItemManager.instance.TimerStock == 0)
        {
            MoneyManager.instance.UseMoney("timer", ItemManager.instance.TimerPrice);
            print("타이머구매버튼 눌렸음");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
