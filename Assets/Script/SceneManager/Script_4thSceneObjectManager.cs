using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_4thSceneObjectManager : MonoBehaviour
{
    public static Script_4thSceneObjectManager instance;

    [SerializeField]
    GameObject[] platformData;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject ScriptBox;


    bool PlatformMove = false;
    private void Awake()
    {
        instance = this;
      
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptBox.GetComponent<Script_ScriptBox>().SetBoxScript("�ű� ���� '�����Ǿ�'�� �߰��Ǿ����ϴ�. ������ ���� ������ �۵���Ű����");
        
    }

 
    private void Update()
    {

       if(Player != null)
        {
            if (Player.GetComponent<Script_MainPlayer>().Trigger && PlatformMove == false)
            {
                MovePlatform();
            }

        }
        if (Player.GetComponent<Script_MainPlayer>().GetRapier() == true)
        {
            Script_ScriptBox.instance.ScriptText.SetActive(true);
            Script_ScriptBox.instance.Bg.SetActive(true);

            Script_ScriptBox.instance.SetBoxScript("�����Ǿ� ���� Z-�ֵθ��� X-��� C-���� / (if �����: ��ư ��ġ)");
            Debug.Log("��ũ��Ʈ ���");
            Player.GetComponent<Script_MainPlayer>().SetRapier(false);
        }
      else   if (Script_ScriptBox.instance.GetActive() == false)
        {
            if (Script_ScriptBox.instance.CurScript() == "�����Ǿ� ���� Z-�ֵθ��� X-��� C-���� / (if �����: ��ư ��ġ)")
            {
                Debug.Log("��ũ��Ʈ ���");
                Script_ScriptBox.instance.SetBoxScript("���� ������ ù°(������)�� Ư�� ����ü�� ���� ������ �� �ֽ��ϴ�.");

            }
            else if (Script_ScriptBox.instance.CurScript() == "���� ������ ù°(������)�� Ư�� ����ü�� ���� ������ �� �ֽ��ϴ�.")
            {
                Debug.Log("��ũ��Ʈ ���");
                Script_ScriptBox.instance.SetBoxScript("���� ������ ��°(�Ķ���)�� Ư�� ����ü�� ����� ������ �� �ֽ��ϴ�.");
            }
        }


       
        
        if (Script_SceneManager.instance.SceneClear == true)
        {
            GameObject.FindGameObjectWithTag("Clear").GetComponent<Scirpt_ClearData>().StageClear[3] = true;
        }
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
