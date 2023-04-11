using UnityEngine;
using System.Collections;
using Spine.Unity;
using System.Threading;
using FMODUnity;


public class Script_MainPlayer : Script_Pawn_Control
{
    //sound
    FMOD.Studio.EventInstance S_HammerAttack;
    FMOD.Studio.EventInstance LandSound;
    [FMODUnity.EventRef]
 public   string Hammerhit;
    string S_GetWeapon;

     bool isHammerGet = false;
     bool isRapierGet = false;

    [SerializeField]
    Script_PlayerData.PlayerData player;

    [SerializeField]
    Summon_Skill_OBject skill;

    [SerializeField]
    GameObject[] AttackZone;

    public bool Trigger;
   
    private bool m_IsJumpDown = false; //Á¡ÇÁ¸¦ ´­·¶´ÂÁö.


    private float jumpRimittime = 0.5f; //Á¡ÇÁ ÄðÅ¸ÀÓ
    private float jumpReadyTime = 0.0f;

 

    [HideInInspector]
    public bool isLeftMove = false; //¿ÞÂÊÀÌµ¿ ¹öÆ° ÀÔ·Â È®ÀÎ
    [HideInInspector]
    public bool isRightMove = false;//¿À¸¥ÂÊÀÌµ¿ ¹öÆ° ÀÔ·Â È®ÀÎ
    private bool isJumpBtOn = false;//Á¡ÇÁ ¹öÆ° ÀÔ·Â È®ÀÎ


    public bool On_Ground = false; //¶¥À§¿¡ ÀÖ´ÂÁö
    bool is_Fall = false;


    public bool SkillUse = false;
    [SerializeField]
    int WeaponCount = 0;

   public bool isAttack = false;

    int attacktype = 0;
    
   // float timer = 0.0f;
    private void Start()
    { 
        
        SetPlayerData();
        SoundSet();


    }
    private void Update()
    {
     
        



        Jump(ref m_IsJumpDown);
   
        jumpReadyTimeUp();

        StartCoroutine(Falling());

        MoveCheck();
    
        JumpCheck();


        AttackCheck();


        if (is_Fall == true)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale += Time.deltaTime*10.0f;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;

        }

   

    }


    // Start is called before the first frame update

    IEnumerator GetEffect()
    {

        Vector3 SpawnPos = this.gameObject.transform.position + new Vector3(0.0f, 2.0f, 0.0f);

        GameObject GetWeapon;
        GetWeapon = Resources.Load("GetWeapon") as GameObject;
        Instantiate(GetWeapon, SpawnPos, Quaternion.identity) ;

        //yield return new WaitForSeconds(0.2f);
        yield return new WaitForSeconds(10f);



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Potal")
        {
            Script_SceneManager.instance.SceneClear = true;
        }

        if (collision.gameObject.tag == "Weapon")
        {
            this.gameObject.GetComponent<SoundManager>().SoundOneShot(S_GetWeapon);
            player.SetWeaponData(collision.gameObject.GetComponent<Script_Weapon>().GetWeaponData());
           Script_WeaponManager.instance.SetWeaponUI(player.GetWeaponData().GetWeaponIndex());
         
           SetGFXNum( collision.gameObject.GetComponent<Script_Weapon>().GetPlayerGFX());
          
            GFXChange(GetGFXNum());
            WeaponCount = player.GetWeaponData().GetUseCount();
            player.SetAttckPower(collision.gameObject.GetComponent<Script_Weapon>().GetWeaponData().GetWeaponPower());
            player.SetAttackActive(true);
            Object.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
                if (collision.gameObject.tag == "Monster" 
            || collision.gameObject.tag == "Trap"
            ||collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Batton")
        {
           Death();
        }
    }

 




    void jumpReadyTimeUp()
    {
        if (On_Ground == true)
        {

            if (jumpReadyTime < jumpRimittime)
            {
             
                jumpReadyTime += Time.deltaTime;
            }

        }
    }


    IEnumerator Falling()
    {
       
        float oldY = this.transform.position.y;
      
        yield return new WaitForSeconds(0.1f);
       
        float CurY = this.transform.position.y;

        if (oldY - CurY > 0.1f)
        {
            is_Fall = true;
        }
        else
        {
            is_Fall = false;
        }
    }
    public Script_PlayerData.PlayerData GetPlayer() { return player; }

    //Ä³¸¯ÅÍ ÃÊ±âÈ­¿ë
    void SetPlayerData()
    {
     
        SetGameObject(gameObject);
        SetMoveSpeed(player.GetPlayerSpeed());
        SetJumpPower(player.GetPlayerJumpPower());
       SetGFXNum("1");

        skill = this.gameObject.GetComponent<Summon_Skill_OBject>();


    }



 
    public void LeftMoveBtClick()
    {
        if (isLeftMove == true)
        {
         
            isLeftMove = false;
          
           
        }
        else if (isLeftMove == false)
        {
           
            isLeftMove = true;
           
        }
    }

    public void RightMoveBtClick()
    {
        if (isRightMove == true)
        {
            animator.SetBool("move", false);

            isRightMove = false;
          

        }
        else if (isRightMove == false)
        {
            animator.SetBool("move", true);

            isRightMove = true;
         
        }
    }
    public void JumpBtClick()
    {
      
          isJumpBtOn = true;
    }
    public  override void Attack()
    {
        if (GetGFXNum() == "2")
        {
            if (isAttack == false && On_Ground == true && WeaponCount > 0)
            {

                if (Script_WeaponManager.instance.isInfinity == false)
                    WeaponCount -= 1;
                isAttack = true;
                animator.SetBool("Attack", true);
            }
        }
        else if (GetGFXNum() == "3")
        {

            if (isAttack == false && WeaponCount > 0)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle_Rapier")|| animator.GetCurrentAnimatorStateInfo(0).IsName("walk_Raiper"))
                {
               
                        WeaponCount -= 1;
                    isAttack = true;
                    animator.SetBool("Attack", true);
                }
            }
        }
    } 


    void AttackCheck()
    {
        if (GetGFXNum() == "2")
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack_Hammer") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
            {
                animator.SetBool("Attack", false);
                isAttack = false;
       
                if (WeaponCount <= 0)
                {
                    player.SetAttackActive(false);
                    Script_WeaponManager.instance.DeleteWeaponUi(player.GetWeaponData().GetWeaponIndex());
                    SetGFXNum("1");
                    GFXChange(GetGFXNum());
                }

            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack_Hammer") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.53f
           && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.38f)
            {
           
                AttackZone[0].SetActive(true);
            }
            else
            {
                AttackZone[0].SetActive(false);
            }
        }
        else if (GetGFXNum() == "3")
        {
            switch (attacktype) {
                case 0:
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stab_Rapier") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
                    {
                        SetAttackType(3);
                        animator.SetBool("Attack", false);
                        isAttack = false;
                        if (WeaponCount <= 0)
                        {
                            player.SetAttackActive(false);
                            Script_WeaponManager.instance.DeleteWeaponUi(player.GetWeaponData().GetWeaponIndex());
                            SetGFXNum("1");
                            GFXChange(GetGFXNum());
                        }
                    }
                    else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stab_Rapier") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <=0.9f
      && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.40f)
                    {

                        AttackZone[1].SetActive(true);
                        AttackZone[1].gameObject.name = "Sting";
                    }
                    else
                    {
                        AttackZone[1].SetActive(false);
                    }
                    break;
                case 1:
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Cut_Rapier") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
                    {
                        SetAttackType(3);
                        animator.SetBool("Attack", false);
                        isAttack = false;
                        if (WeaponCount <= 0)
                        {
                            player.SetAttackActive(false);
                            Script_WeaponManager.instance.DeleteWeaponUi(player.GetWeaponData().GetWeaponIndex());
                            SetGFXNum("1");
                            GFXChange(GetGFXNum());
                        }
                    }
                    else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Cut_Rapier") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.60f
     && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.40f)
                    {

                        AttackZone[1].SetActive(true);
                        AttackZone[1].gameObject.name = "Swing";
                    }
                    else
                    {
                        AttackZone[1].SetActive(false);
                    }
                    break;
          
                case 2:
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Guard_Rapier") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
                    {
                        SetAttackType(3);
                        animator.SetBool("Attack", false);
                        isAttack = false;
                        if (WeaponCount <= 0)
                        {
                            player.SetAttackActive(false);
                            Script_WeaponManager.instance.DeleteWeaponUi(player.GetWeaponData().GetWeaponIndex());
                            SetGFXNum("1");
                            GFXChange(GetGFXNum());
                        }
                    }
                    else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Guard_Rapier") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.80f
    && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.40f)
                    {
                        AttackZone[1].gameObject.name = "Guard";
                        AttackZone[1].SetActive(true);
                    }
                    else
                    {
                        AttackZone[1].SetActive(false);
                    }
                    break;
                default:
                    break;
            
            }

        }
    }
  
   
 
    void JumpCheck()
    {
        if (isJumpBtOn && On_Ground == true && is_Fall == false && isAttack == false)
        {


            m_IsJumpDown = true;
            On_Ground = false;
            isJumpBtOn = false;
            jumpReadyTime = 0.0f;

        }
    }

    void MoveCheck()
    {
        if (GetGFXNum() == "2")
        {
        if (isLeftMove && isAttack == false)//&& On_Ground)
        {

            if (On_Ground == true)
            {
              this.gameObject.GetComponent<SoundManager>().SoundPlay(MoveSoundEv);
            }
            animator.SetBool("move", true);
            leftMove();
        
        }
        else if (isRightMove && isAttack == false) //&& On_Ground)
        {
            if (On_Ground == true)
            {
                this.gameObject.GetComponent<SoundManager>().SoundPlay(MoveSoundEv);
            }
            animator.SetBool("move", true);
            RightMove();
          
        }
        else
        {
            animator.SetBool("move", false);
        }
        }
        if (GetGFXNum() == "3"||GetGFXNum()=="1")
        {
            if (isLeftMove )//&& On_Ground)
            {

                if (On_Ground == true)
                {
                    this.gameObject.GetComponent<SoundManager>().SoundPlay(MoveSoundEv);
                }
                animator.SetBool("move", true);
                leftMove();

            }
            else if (isRightMove) //&& On_Ground)
            {
                if (On_Ground == true)
                {
                    this.gameObject.GetComponent<SoundManager>().SoundPlay(MoveSoundEv);
                }
                animator.SetBool("move", true);
                RightMove();

            }
            else
            {
                animator.SetBool("move", false);
            }
        }
        
    }
    public void GFXChange(string num)
    {

        if (num == "2")
        {
            isHammerGet = true;
        }
        else if (num == "3")
        {
            isRapierGet = true;
        }
        GFX.GetComponent<SkeletonMecanim>().skeleton.SetSkin(num);
        GFX.GetComponent<SkeletonMecanim>().skeleton.SetSlotsToSetupPose();
        GFX.GetComponent<SkeletonMecanim>().LateUpdate();
 
        animator.SetInteger("CharacterCode", int.Parse(num));
       
        switch (int.Parse(num))
        {
            case 1:
                MoveSoundEv.setParameterByNameWithLabel("CharacterType", "Standard");
                LandSound.setParameterByNameWithLabel("CharacterType", "Standard");
                break;
            case 2:
                MoveSoundEv.setParameterByNameWithLabel("CharacterType", "Hammer");
                LandSound.setParameterByNameWithLabel("CharacterType", "Hammer");
                break;
            case 3:
                MoveSoundEv.setParameterByNameWithLabel("CharacterType", "Rapier");
                LandSound.setParameterByNameWithLabel("CharacterType", "Rapier");
                break;
            default:
                break;

        }
        StartCoroutine(GetEffect());
    }
    public bool GetisAttack() { return isAttack; }

   public void SetAttackType(int num)
    {
        animator.SetInteger("AttackType", num);
        attacktype = num;
        // attack 콜라이더 tag 수정
    }

  public override  void  Death()
    {
        base.Death();
        Script_SceneManager.instance.PlayerAlive=false;
  
   
    }

    public void useSkill()
    {
        if (On_Ground == true)
        {
            
            skill.On_Skill_Button();
        }
    }



    void SoundSet()
    {
      MoveSoundEv = RuntimeManager.CreateInstance("event:/WeaponMaster/Character/general/Sfx_CharacterMove");
      S_HammerAttack = RuntimeManager.CreateInstance("event:/WeaponMaster/Character/Hammer/Sfx_HammerAttack");
        LandSound= RuntimeManager.CreateInstance("event:/WeaponMaster/Character/general/Sfx_CharacterLand");
        S_GetWeapon = "event:/WeaponMaster/Stage/SFX/Sfx_GetWeapon";
    }

    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }

    public void HitSoundPlay()
    {

        FMODUnity.RuntimeManager.PlayOneShot(Hammerhit);
    }
    public void LandSoundPlay()
    {

        this.gameObject.GetComponent<SoundManager>().SoundPlay(LandSound);
    }

    public int GetWeaponCount() { return WeaponCount; }

    public bool GetHammer() { return isHammerGet; }
    public void SetHammer(bool on) {  isHammerGet=on; }
    public bool GetRapier() { return isRapierGet; }
    public void SetRapier(bool on) { isRapierGet=on; }
}
