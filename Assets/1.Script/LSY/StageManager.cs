using Mono.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    //시작하면 한번 스테이지의 정보를 가져온다
    //스테이지 번호, 스테이지 별점-> LoadDB()
    //화살표를 통해 스테이지를 조절하면 그에 맞게 스테이지 정보를 변경한다

    public static StageManager instance;
    private void Awake()
    {

        instance = this;
    }
    private int stageStar;
    private bool stageLock;
    private int myStage;
    /*public int GetMyStage()
    {
        return myStage;
    }*/
    public int StageStar
    {
        get { return stageStar; }
        set { stageStar = value; }
    }
    public int MyStage
    {
        get{ return myStage; }
        set{ myStage = value; }
    }
    GameObject textStage;
    GameObject[] stars;
    GameObject tempStars;
    GameObject[] planets;
    GameObject tempPlanets;
    StageNum stageNum;
    GameObject pos;

    public List<GameObject> planetList;

    // Start is called before the first frame update
    void Start()
    {
        SetStageInfo();
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlanets()
    {
        planets = new GameObject[5];
        tempPlanets = GameObject.Find("Planets");
        for(int i= 0; i< planets.Length; i++)//행성 정보를 넣어준다
        {
            planets[i] = tempPlanets.transform.GetChild(i).gameObject;
            planets[i].SetActive(false);
        }

        for (int j = 0; j < myStage; j++)//현재 스테이지의 행성을 활성화해준다
        {
            planets[j].SetActive(true);
        }
        for(int j = myStage; j<planets.Length; j++)//현재 스테이지를 제외하고 앞뒤로 검색해 행성을 비활성화 해준다
        {
            planets[j].SetActive(false);
        }
        //if(myStage > 1)
        //{
        for (int j = myStage - 2; j >= 0; j--)//현재 스테이지를 제외하고 앞뒤로 검색해 행성을 비활성화 해준다
        {
            planets[j].SetActive(false);
        }
        //}

    }
    public void SetStageInfo()//스테이지 정보 갱신
    {
        textStage = GameObject.Find("Planet_Text");
        textStage.GetComponent<Text>().text = "PLANET: " + myStage.ToString();//스테이지 넘버 입력
        SetStars();
        SetPlanets();
    }
    
    public void SetStars()
    {
        stars = new GameObject[3];
        tempStars = GameObject.Find("Stars_Img");
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i] = tempStars.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < stageStar; i++)//별개수 만큼 별이미지 활성화
        {
            stars[i].GetComponent<Image>().enabled = true;
        }
        for (int i = stageStar; i < stars.Length; i++) //별개수 제외하고 별 이미지 비활성화
        {
            stars[i].GetComponent<Image>().enabled = false;
        }
    }

}
