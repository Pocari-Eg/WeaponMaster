using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SecondSceneObjectManager : MonoBehaviour
{
    public static Script_SecondSceneObjectManager instance;


    [SerializeField]
    float RailSpeed = 3.0f;

    [SerializeField]
    GameObject button;
    GameObject Player;
    

    [SerializeField]
    GameObject Flatform;
    // Start is called before the first frame update


    [SerializeField]
    Script_MonsterManager monsterManager;
    private void Awake()
    {
        instance = this;
        monsterManager = this.gameObject.GetComponent<Script_MonsterManager>();
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Player.GetComponent<Script_MainPlayer>().GetHammer() == true)
            {
  
                Script_ScriptBox.instance.SetBoxScript("��ư ������ '����' ��ư�� �̿��Ͽ� �۵���ų �� �ֽ��ϴ�.");
                Player.GetComponent<Script_MainPlayer>().SetHammer(false);
          }
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Script_MainPlayer>().Trigger)
            {
                Flatform.GetComponent<Script_MovePlatform>().onMove = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Script_MainPlayer>().Trigger = false;
            }
        }
        
        
        if (button != null)
            {
             
                RailOn(button.gameObject.GetComponent<Scrip_RailBt>().GetRail());

                
          
            }
        if (Script_SceneManager.instance.SceneClear == true)
        {
            GameObject.FindGameObjectWithTag("Clear").GetComponent<Scirpt_ClearData>().StageClear[1] = true;
        }
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Script_ScriptBox.instance.SetBoxScript("��Ͽ� �������� ���ӿ����� �Ǵ� �����ϼ���.");
        monsterManager.MonsterSpawn();
    }
    public  void RailOn(GameObject rail)
    {
 
        rail.gameObject.GetComponent<Movement>().On = true;
        rail.gameObject.GetComponent<Movement>().SetSpeed(RailSpeed);
    }
 
  public  void SetButton(GameObject b)
    {
        button = b;
    }
}
