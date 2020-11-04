using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickUpgradeButton : MonoBehaviour
{
    public void ClickUpgradeHammerBtn()//망치 업그레이드 버튼
    {
        print("버튼 클릭");
        if (EquipManager.instance.equipList[0].level < 3)
        {
            //업그레이드 비용을 지불한다
            //현재 장비의 다음 레벨의 가격
            DBManager.instance.UseMoney_Equip(EquipManager.instance.equipList[0].name, EquipManager.instance.equipList[0].price);
            EquipManager.instance.SetEquip();
        }
    }
    public void ClickUpgradeKnifeBtn()//망치 업그레이드 버튼
    {
        print("버튼 클릭");
        if (EquipManager.instance.equipList[1].level < 3)
        {
            //업그레이드 비용을 지불한다
            //현재 장비의 다음 레벨의 가격
            DBManager.instance.UseMoney_Equip(EquipManager.instance.equipList[1].name, EquipManager.instance.equipList[1].price);
            EquipManager.instance.SetEquip();
        }
    }
    public void ClickUpgradeGrillBtn()//망치 업그레이드 버튼
    {
        print("버튼 클릭");
        if (EquipManager.instance.equipList[2].level < 3)
        {
            //업그레이드 비용을 지불한다
            //현재 장비의 다음 레벨의 가격
            DBManager.instance.UseMoney_Equip(EquipManager.instance.equipList[2].name, EquipManager.instance.equipList[2].price);
            EquipManager.instance.SetEquip();
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
