﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserTest : MonoBehaviour
{
    private LineRenderer layser;        // 레이저
    private RaycastHit hitInfo; // 충돌된 객체
    private GameObject currentObject;   // 가장 최근에 충돌한 객체를 저장하기 위한 객체
    Ray ray;
    public float raycastDistance = 10.0f; // 레이저 포인터 감지 거리

    // Start is called before the first frame update
    void Start()
    {
        layser = GetComponent<LineRenderer>();
        /*return;
        // 스크립트가 포함된 객체에 라인 렌더러라는 컴포넌트를 넣고있다.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // 라인이 가지개될 색상 표현
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(1, 0, 0, 1);
        layser.material = material;
        // 레이저의 꼭지점은 2개가 필요 더 많이 넣으면 곡선도 표현 할 수 있다.
        layser.positionCount = 2;
        // 레이저 굵기 표현
        layser.startWidth = 0.01f;
        layser.endWidth = 0.01f;*/
    }

    // Update is called once per frame\

    void Update()
    {
        layser.SetPosition(0, transform.position); // 첫번째 시작점 위치
                                                   // 업데이트에 넣어 줌으로써, 플레이어가 이동하면 이동을 따라가게 된다.
                                                   //  선 만들기(충돌 감지를 위한)                                                   
        
        //Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);
        ray = new Ray(transform.position, transform.forward);
        // 충돌 감지 시
        int layer = 1 << LayerMask.NameToLayer("Ignore Raycast");
        if (Physics.Raycast(ray, out hitInfo, 100, ~layer))
        {
            layser.enabled = true;//충돌 잇으면 켜지게
            layser.SetPosition(1, hitInfo.point);

            //return;
            // 오큘러스 퀘스트 트리거 누를 경우
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))//오른손 검지 트리거
            {
                // 충돌 객체의 태그가 Button인 경우
                if (hitInfo.collider.gameObject.CompareTag("Button"))
                {
                    // 버튼에 등록된 onClick 메소드를 실행한다.
                    hitInfo.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }

           

            switch (hitInfo.collider.gameObject.name)
            {
                case "Heart":
                    Debug.Log("heart on");
                    UIManager.instance.InfoMsgOn(hitInfo.collider.gameObject.name);
                    break;
                case "Timer":
                    UIManager.instance.InfoMsgOn(hitInfo.collider.gameObject.name);
                    break;
                case "HammerPos":
                    UIManager.instance.InfoMsgOn(hitInfo.collider.gameObject.name);
                    break;
                case "KnifePos":
                    UIManager.instance.InfoMsgOn(hitInfo.collider.gameObject.name);
                    break;
                case "GrillPos":
                    UIManager.instance.InfoMsgOn(hitInfo.collider.gameObject.name);
                    break;
                default:
                    UIManager.instance.InfoMsgOff();
                    break;
            }
            
        }

        else
        {
            //UIManager.instance.InfoMsgOff();

            layser.enabled = false;//충돌 없으면 꺼지게
         
            /*//UIManager.instance.InfoMsgOff();
            //return;
            // 레이저에 감지된 것이 없기 때문에 레이저 초기 설정 길이만큼 길게 만든다.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            // 최근 감지된 오브젝트가 Button인 경우
            // 버튼은 현재 눌려있는 상태이므로 이것을 풀어준다.
            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }*/

        }

    }

    private void LateUpdate()
    {
        /*// 버튼을 누를 경우        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            layser.material.color = new Color(255, 255, 255, 0.5f);
        }

        // 버튼을 뗄 경우          
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            layser.material.color = new Color(0, 195, 255, 0.5f);
        }*/
    }
   
}
