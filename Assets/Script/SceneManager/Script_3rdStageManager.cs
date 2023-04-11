using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_3rdStageManager : MonoBehaviour
{
    public static Script_3rdStageManager instance;
    float SpawnTime = 3.0f;
    GameObject Player;
    int spawncount = 0;

    bool Skillfrist = false;
    [SerializeField]
    Script_MonsterManager monsterManager;
    private void Awake()
    {
        instance = this;
        monsterManager = this.gameObject.GetComponent<Script_MonsterManager>();
    }
    // Start is called before the first frame update

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Player.name);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Player.GetComponent<Script_MainPlayer>().GetHammer() == true)
        {

            Script_ScriptBox.instance.SetBoxScript("�� ���� ��ų �������� ��ġ�ϸ� ���� ���Ÿ� ������ ����� �� �ִ� �����̸� ��ȯ�մϴ�.");
            Player.GetComponent<Script_MainPlayer>().SetHammer(false);
        }

        if (Script_ScriptBox.instance.GetActive() == false)
        {
            if (Script_ScriptBox.instance.CurScript() == "�� ���� ��ų �������� ��ġ�ϸ� ���� ���Ÿ� ������ ����� �� �ִ� �����̸� ��ȯ�մϴ�.")
            {
                Script_ScriptBox.instance.SetBoxScript("���� Ƚ���� ���������� ����Ǿ����ϴ�.");
            }
           
        }
        if (Skillfrist == false && Player.GetComponent<Script_MainPlayer>().SkillUse == true)
        {
            Script_ScriptBox.instance.SetBoxScript("������ ĳ���Ͱ� 2ĭ ���� ������ �� ���������� �մϴ�. �����ϼ���.");
            Skillfrist = true;
        }

         if (SpawnTime > 0)
        {
            SpawnTime -= Time.deltaTime;
        }
        else if (SpawnTime <= 0)
        {
            if (spawncount < 6)
            {

                spawncount++;
                monsterManager.MonsterSpawn();
                SpawnTime = 6.0f;
            }
            else if (spawncount >= 6)
            {

            }

        }
        if (Script_SceneManager.instance.SceneClear == true)
        {
            GameObject.FindGameObjectWithTag("Clear").GetComponent<Scirpt_ClearData>().StageClear[2] = true;
        }

      
    }
  
}
