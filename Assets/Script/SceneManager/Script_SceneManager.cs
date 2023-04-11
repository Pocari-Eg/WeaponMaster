using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Script_SceneManager : MonoBehaviour
{

    public static Script_SceneManager instance;

   [SerializeField]
    GameObject Player;

    GameObject HitMonster;
 
  
    //[SerializeField]
    //GameObject ClearPotal;
    //[SerializeField]
    //Sprite PotalOpen;

    [SerializeField]
    GameObject SceneUI;

    [SerializeField]
    GameObject OptionUI;
    [SerializeField]
    GameObject SettingUI;

    [SerializeField]
    Text SceneText;

    FMOD.Studio.Bus StageSoundBus;
    public string R_name;

    public bool BossMonsterClear = false;
  
    public bool PlayerAlive = true;

    public bool SceneClear = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //ClearPotal.GetComponent<BoxCollider2D>().enabled = true;
        //ClearPotal.GetComponent<SpriteRenderer>().sprite = PotalOpen;
       StageSoundBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        StageSoundBus.setPaused(false);
    }
    private void FixedUpdate()
    {

        Player = GameObject.FindGameObjectWithTag("Player");




        if (!PlayerAlive)
        {

            SceneText.text = "Game Over";
            SceneUI.SetActive(true);
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Sound").SetActive(false);
         


        }
        if (SceneClear)
            {
                SceneText.text = "Game Clear";

                SceneUI.SetActive(true);
                Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Sound").SetActive(false);
           
     
        }

    }

   public void RerturnMenu()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("MenuScene");
        StageSoundBus.setPaused(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(R_name);
        StageSoundBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        StageSoundBus.setPaused(true);
    }

    public void OpenOption()
    {
        StageSoundBus.setPaused(true);
        Script_PlayerControl.instance.ContorlActive = false;
        Player.GetComponent<Script_MainPlayer>().isLeftMove = false;
        Player.GetComponent<Script_MainPlayer>().isRightMove = false;

       Time.timeScale = 0;
        OptionUI.SetActive(true);
    }
    public void CloseOption()
    {
        StageSoundBus.setPaused(false);
        Time.timeScale = 1;
        OptionUI.SetActive(false);
        Script_PlayerControl.instance.ContorlActive = true;
    }
    public void GameEnd()
    {
        Application.Quit();
    }
    public void SetHitMonster(GameObject m)
    {
        HitMonster = m;
    }

    public void SettingWindowOn()
    {

        CloseOption();
        StageSoundBus.setPaused(true);
        Time.timeScale = 0;
        Player.GetComponent<Script_MainPlayer>().isLeftMove = false;
        Player.GetComponent<Script_MainPlayer>().isRightMove = false;
        Script_PlayerControl.instance.ContorlActive = false;
        SettingUI.SetActive(true);
    }
    public void SettingWindowOff()
    {
        SettingUI.SetActive(false);
        Script_PlayerControl.instance.ContorlActive = true;
        StageSoundBus.setPaused(false);
        OpenOption();
  
    }

    public void WindowClose(GameObject window)
    {
        window.SetActive(false);

    }
    public void WindowOpen(GameObject window)
    {
        window.SetActive(true);

    }
}
