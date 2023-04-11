using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Script_PlayerControl : MonoBehaviour
{
    public static Script_PlayerControl instance;
    public    GameObject PlayerControl;

    public bool ContorlActive = false;

    Script_CameraResolution Camera;

    private void Start()
    {
        instance = this;
        PlayerControl = GameObject.FindGameObjectWithTag("Player");
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<Script_CameraResolution>();
    
    }


    private void Update()
    {
        if (PlayerControl != null)
        {
            if (ContorlActive == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    PlayerControl.GetComponent<Script_MainPlayer>().isLeftMove = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    PlayerControl.GetComponent<Script_MainPlayer>().isLeftMove = false;

                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    PlayerControl.GetComponent<Script_MainPlayer>().isRightMove = true;

                }
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    PlayerControl.GetComponent<Script_MainPlayer>().isRightMove = false;
                }
            }
        }
    }


    public void  AttackShake()
    {


        Camera.VibrateForTime(0.2f);

    }
    public void leftmove()
    {
        if (PlayerControl != null)
        {
        
            PlayerControl.GetComponent<Script_MainPlayer>().LeftMoveBtClick();
        }
    }
    public void rightMove()
    {
        if (PlayerControl != null)
        {
            PlayerControl.GetComponent<Script_MainPlayer>().RightMoveBtClick();
        }
    }
    public void jump()
    {
        if (PlayerControl.GetComponent<Script_MainPlayer>().On_Ground == true)
        {
            if (PlayerControl != null)
            {
                PlayerControl.GetComponent<Script_MainPlayer>().JumpBtClick();
            }
        }
    }


    public void Attack(GameObject button)
    {
        if (PlayerControl != null&&PlayerControl.GetComponent<Script_MainPlayer>().isAttack==false)
        {

            button.GetComponent<Script_AttackTypeCheck>().Check();
            PlayerControl.GetComponent<Script_MainPlayer>().Attack();    
        }
       
    }
    
  public void Skill()
    {
        if (PlayerControl != null)
        {
            
            PlayerControl.GetComponent<Script_MainPlayer>().useSkill();
        }
    }





}
