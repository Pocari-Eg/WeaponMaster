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
                Debug.Log("����on");
                MovePlatform();
            }

        }
        if (TimeOn==true && time > 0)
        {
       
            time -= Time.deltaTime;
        }
        else if (time <= 0)
        {
            Script_ScriptBox.instance.SetBoxScript("���� ���� �ⱸ�� ���ϸ� ���������� Ŭ���� �˴ϴ�.");
        }
        else
        {



            if (GameObject.Find("Creature_Skull_L(Clone)") == true && isBossOn == false)
            {
                Script_ScriptBox.instance.SetBoxScript("ū �׷����� �����մϴ�! �ִ��� ���� ������ �̵��ϼ���!");
                isBossOn = true;
                TimeOn = true;
            }



     
            if (Script_SceneManager.instance.SceneClear == true)
            {
                GameObject.FindGameObjectWithTag("Clear").GetComponent<Scirpt_ClearData>().StageClear[0] = true;
            }

            if (Player.GetComponent<Script_MainPlayer>().GetHammer() == true)
            {
                
                Script_ScriptBox.instance.SetBoxScript("�ظ� ����: Z-����");
                Player.GetComponent<Script_MainPlayer>().SetHammer(false);
            }
            else if (Script_ScriptBox.instance.GetActive() == false)
            {
                if (Script_ScriptBox.instance.CurScript() == "�⺻ ����: �¿� �̵�(Ű���� ����,������), ����(Ű���� ����)")
                {
                    Script_ScriptBox.instance.SetBoxScript("�տ� �ִ� ��ġ�� �ٰ����� �ڵ����� ����˴ϴ�.");

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
        Script_ScriptBox.instance.SetBoxScript("�⺻ ����: �¿� �̵�(Ű���� ����,������), ����(Ű���� ����)");
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
