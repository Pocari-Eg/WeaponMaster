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
        ScriptBox.GetComponent<Script_ScriptBox>().SetBoxScript("신규 무기 '레이피어'가 추가되었습니다. 습득을 위해 발판을 작동시키세요");
        
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

            Script_ScriptBox.instance.SetBoxScript("레이피어 조작 Z-휘두르기 X-찌르기 C-막기 / (if 모바일: 버튼 터치)");
            Debug.Log("스크립트 출력");
            Player.GetComponent<Script_MainPlayer>().SetRapier(false);
        }
      else   if (Script_ScriptBox.instance.GetActive() == false)
        {
            if (Script_ScriptBox.instance.CurScript() == "레이피어 조작 Z-휘두르기 X-찌르기 C-막기 / (if 모바일: 버튼 터치)")
            {
                Debug.Log("스크립트 출력");
                Script_ScriptBox.instance.SetBoxScript("정령 마법사 첫째(빨간색)의 특수 투사체는 찌르기로 파훼할 수 있습니다.");

            }
            else if (Script_ScriptBox.instance.CurScript() == "정령 마법사 첫째(빨간색)의 특수 투사체는 찌르기로 파훼할 수 있습니다.")
            {
                Debug.Log("스크립트 출력");
                Script_ScriptBox.instance.SetBoxScript("정령 마법사 둘째(파란색)의 특수 투사체는 베기로 파훼할 수 있습니다.");
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
