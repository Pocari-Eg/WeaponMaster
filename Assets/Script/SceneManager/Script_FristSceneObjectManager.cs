using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FristSceneObjectManager : MonoBehaviour
{
    public static Script_FristSceneObjectManager instance;
    public bool isGetWeapon;
    bool isBossOn = false;
    float time = 5.0f;
    [SerializeField]
    GameObject[] platformData;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    Script_MonsterManager monsterManager;



    bool TimeOn;
    [SerializeField]
    bool PlatformMove = false;
    private void Awake()
    {
        instance = this;
        monsterManager = this.gameObject.GetComponent<Script_MonsterManager>();
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Debug.Log(Player.GetComponent<Script_MainPlayer>().Trigger);
            Debug.Log(PlatformMove);
                if (Player.GetComponent<Script_MainPlayer>().Trigger && PlatformMove == false)
            {
                Debug.Log("발판on");
                MovePlatform();
            }

        }
        if (TimeOn==true && time > 0)
        {
       
            time -= Time.deltaTime;
        }
        else if (time <= 0)
        {
            Script_ScriptBox.instance.SetBoxScript("우측 끝의 출구로 향하면 스테이지가 클리어 됩니다.");
        }
        else
        {



            if (GameObject.Find("Creature_Skull_L(Clone)") == true && isBossOn == false)
            {
                Script_ScriptBox.instance.SetBoxScript("큰 그룹톤은 위험합니다! 최대한 높은 곳까지 이동하세요!");
                isBossOn = true;
                TimeOn = true;
            }



     
            if (Script_SceneManager.instance.SceneClear == true)
            {
                GameObject.FindGameObjectWithTag("Clear").GetComponent<Scirpt_ClearData>().StageClear[0] = true;
            }

            if (Player.GetComponent<Script_MainPlayer>().GetHammer() == true)
            {
                
                Script_ScriptBox.instance.SetBoxScript("해머 조작: Z-공격");
                Player.GetComponent<Script_MainPlayer>().SetHammer(false);
            }
            else if (Script_ScriptBox.instance.GetActive() == false)
            {
                if (Script_ScriptBox.instance.CurScript() == "기본 조작: 좌우 이동(키보드 왼쪽,오른쪽), 점프(키보드 윗쪽)")
                {
                    Script_ScriptBox.instance.SetBoxScript("앞에 있는 망치에 다가가면 자동으로 습득됩니다.");

                }
             
            }
        }
    }

   void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        monsterManager.MonsterSpawn();
        Script_ScriptBox.instance.ScriptText.SetActive(true);
        Script_ScriptBox.instance.Bg.SetActive(true);
        Script_ScriptBox.instance.SetBoxScript("기본 조작: 좌우 이동(키보드 왼쪽,오른쪽), 점프(키보드 윗쪽)");
    }
  public  void MovePlatform()
    {
        if (platformData != null)
        {
            for (int i = 0; i < platformData.Length; i++)
            {
                platformData[i].GetComponent<Script_MovePlatform>().onMove = true;

            }
            PlatformMove = true;
        }
    }
    

}
