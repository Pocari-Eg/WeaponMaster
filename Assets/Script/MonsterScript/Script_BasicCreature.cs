using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BasicCreature : Script_Pawn_Control
{
    public bool isBossMonster;
   public float thisMonSpeed=1.0f;
    bool isCounti = true;
 
     float MonsterSpeedLimit = 2.0f;

    // Start is called before the first frame updatezzz
    bool isleftMove = true;
     bool isRightMove = false;
  
    void Start()
    {
        SetGameObject(gameObject);
        SetMoveSpeed(thisMonSpeed);
        if (Script_3rdStageManager.instance != null)
        {
            isCounti = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isleftMove)
        {
            leftMove();
        }
        else if (isRightMove)
        {
            RightMove();
        }
     
    }

    private void FixedUpdate()
    {

        SetMoveSpeed(thisMonSpeed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Wall"||collision.gameObject.tag=="Trap")
        {
           
            Death();
        }
        if(collision.gameObject.tag=="platform")
        {
        
            if (isBossMonster)
            {
                if (thisMonSpeed < MonsterSpeedLimit)
                SetMoveSpeed(thisMonSpeed);
            }
        }
        if (collision.gameObject.tag == "Monster")
        {
            Death(); 
        }
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "AttackZone"&&!isBossMonster&&collision.gameObject.name=="HammerBox")
        {
            Debug.Log("È÷Æ®");
            Script_SceneManager.instance.SetHitMonster(this.gameObject);
            Debug.Log("Á×À½");
            Death();
        }

    }
    
 


    public override void Death()
    {

       
        if(isBossMonster==true)
        {
            
             Script_SceneManager.instance.BossMonsterClear = true;
        }
        if (isBossMonster == false && isCounti == true)
        {
            Script_SceneManager.instance.GetComponent<Script_MonsterManager>().monsterNum++;
            Script_SceneManager.instance.GetComponent<Script_MonsterManager>().MonsterSpawn();

        }
        
        base.Death();
        
    }
 public void Reverse()
    {
        isleftMove = false;
        isRightMove = true;
      
    }
}
