﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCRobber : MonoBehaviour {
    enum State {
        Search,
        Move,
        Avoid,
        Run,
        Die
    }
    State state;
    public Animator anim;

    GameObject targetObject;

    // - 현재체력
    int curHP;
    // - 최대체력
    public int maxHP;

    public int HP {
        get { return curHP; }
        set {
            curHP = Mathf.Max(0, value);
            //sliderHP.value = curHP;
        }
    }
    //Avoid용
    float rightMax = 3.0f; //좌로 이동가능한 (x)최대값
    float leftMax = -3.0f; //우로 이동가능한 (x)최대값
    float currentPosition; //현재 위치(x) 저장
    float direction = 3.0f; //이동속도+방향

    public float speed = 10.0f;  //이동속도(public이라 인스펙터에서 적절한값으로 수정)
    Vector3 dir;                //이동할 방향

    public float runTime = 0.6f; //10초뒤 도망
    float currentTime; //증감시킬값


    // Start is called before the first frame update
    void Start() {
        maxHP = 3;
        state = State.Search;

        curHP = maxHP;
        //sliderHP.maxValue = maxHP;
        //sliderHP.value = curHP;
    }

    // Update is called once per frame
    void Update() {
        if (curHP <= 0) {
            state = State.Die;
        }
        switch (state) {
            case State.Search: UpdateSearch(); break;
            case State.Move: UpdateMove(); break;
            case State.Avoid: UpdateAvoid(); break;
            case State.Run: UpdateRun(); break;
            case State.Die: UpdateDie(); break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "ROBBERSPOT") {//ROBBERSPOT에 닿으면(도착하면) Avoid 상태로 전이
            //Debug.Log(other.name);
            currentPosition = transform.position.x;
            state = State.Avoid;
        }
        if (other.transform.tag == "EXIT") {
            //print("exit 진입");
            for (int i = 0; i < NPCSpawnManager.Instance.emptyTableList.Count; i++) {
                NPCSpawnManager.Instance.emptyTableList[i] = true;
            }
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {

        if (other.transform.tag == "CUP" || other.transform.tag == "DISH") {

            //맞는 애니메이션 필요
            Destroy(other.gameObject, 0);
            HP -= 1;
        }
    }

    private void UpdateSearch() {
        targetObject = GameObject.Find("RobberSpot");
        //타겟이 null이 아니면
        if (targetObject != null) {
            //이동상태로 전이
            state = State.Move;
        }
    }
    private void UpdateMove() {//포탈에서 입장하는거
        dir = targetObject.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }
    private void UpdateAvoid() { //입장하고나서 좌우로 피하는거
        currentPosition += speed * Time.deltaTime * direction;
        if (currentPosition >= rightMax) {
            direction *= -1;
            currentPosition = rightMax;
        }
        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정
        else if (currentPosition <= leftMax) {
            direction *= -1;
            currentPosition = leftMax;
        }
        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        currentTime += Time.deltaTime;
        if (currentTime > runTime) {
            state = State.Run;
            currentTime = 0;
        }
    }
    private void UpdateRun() {
        targetObject = GameObject.Find("EXIT");
        //GameManager.Instance.Profit 감소
        GameManager.Instance.Profit -= 500;
        //GameManager.Instance.Complain 감소
        GameManager.Instance.Complain--;
        if (GameManager.Instance.Complain <= 0) {
            GameManager.Instance.GameOver();
        }
        if (targetObject != null) {
            state = State.Move;
        }
    }
    private void UpdateDie() {
        for (int i = 0; i < NPCSpawnManager.Instance.emptyTableList.Count; i++) {
            NPCSpawnManager.Instance.emptyTableList[i] = true;
        }
        Destroy(gameObject, 0);
        GameManager.Instance.KillRobberCount++;
        //연출필요
        //돈 빵빵터져야함
        //GameManager.Instance.Profit 증가
        GameManager.Instance.Profit += 500;
    }
}
