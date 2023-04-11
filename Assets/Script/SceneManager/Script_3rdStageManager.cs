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

            Script_ScriptBox.instance.SetBoxScript("맨 우측 스킬 아이콘을 터치하면 적의 원거리 공격을 방어할 수 있는 돌덩이를 소환합니다.");
            Player.GetComponent<Script_MainPlayer>().SetHammer(false);
        }

        if (Script_ScriptBox.instance.GetActive() == false)
        {
            if (Script_ScriptBox.instance.CurScript() == "맨 우측 스킬 아이콘을 터치하면 적의 원거리 공격을 방어할 수 있는 돌덩이를 소환합니다.")
            {
                Script_ScriptBox.instance.SetBoxScript("공격 횟수는 무제한으로 변경되었습니다.");
            }
           
        }
        if (Skillfrist == false && Player.GetComponent<Script_MainPlayer>().SkillUse == true)
        {
            Script_ScriptBox.instance.SetBoxScript("바톤은 캐릭터가 2칸 내로 접근할 시 근접공격을 합니다. 주의하세요.");
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
