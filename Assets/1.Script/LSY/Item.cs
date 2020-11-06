using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameObject itemOff;
    GameObject itemOn;
    // Start is called before the first frame update
    void Start()
    {
        //자식 오브젝트 들을 가져와서 on, off에 넣어준다
        itemOff = transform.GetChild(0).gameObject;//꺼진 아이템 저장
        itemOn = transform.GetChild(1).gameObject;//켜진 아이템 저장
        //오브젝들을 처음에 비활성화 시킨다
        itemOn.SetActive(false);
        itemOff.SetActive(false);
    }
    /*private void OnTriggerStay(Collider other)//여기 수정해야함
    {
        *//*switch (other.gameObject.name)
        {
            case "Heart":
                UIManager.instance.InfoMsgOn("Heart");
                break;
            case "Timer":
                UIManager.instance.InfoMsgOn("Timer");
                break;
            default:
                break;
        }*//*
        if (other.gameObject.name.Equals("Ray"))
        {
            print("레이 닿았음");
        }
    }*/

    public void SetItem()//씬 start하면 디비에 있는 아이템정보를 가져와서 해당 조건에 맞게 세팅해준다
    {
        switch (gameObject.name)
        {
            case "Heart"://Heart오브젝트라면
                print(ItemManager.instance.HeartStock);
                switch (ItemManager.instance.HeartStock)
                {
                    case 0://아이템의 재고가 없으면
                        itemOff.SetActive(true);
                        itemOn.SetActive(false);

                        break;
                    case 1://아이템의 재고가 있으면
                        itemOff.SetActive(false);
                        itemOn.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case "Timer"://Timer오브젝트 라면
                switch (ItemManager.instance.TimerStock)
                {
                    case 0://아이템의 재고가 없으면
                        itemOff.SetActive(true);
                        itemOn.SetActive(false);

                        break;
                    case 1://아이템의 재고가 있으면
                        itemOff.SetActive(false);
                        itemOn.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        SetItem();
    }
}
