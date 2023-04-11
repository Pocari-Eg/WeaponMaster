using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Creature_Batton : Script_Pawn_Control
{
    [SerializeField]
    int HP = 2;

  public  bool CloseAttack = false;
   public bool LongAttack = true;

    [SerializeField]
    float WaitTime;

   

    public float ChangeDelay = 0.0f;

    [SerializeField]
    GameObject Projectile_zone;
    public GameObject projectile;
    bool Shoot = true;
    [SerializeField]
    GameObject AttackZone;
  


 
    float m_attacDel;


    [SerializeField]
    float AttackTimeMax;
    float Attacktime;
    bool isattack = false;
        // Start is called before the first frame update
    void Start()
    {

        Attacktime = AttackTimeMax;
        m_attacDel = WaitTime;
        LongAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (isattack==false)
        {

            m_attacDel -= Time.deltaTime;
        }
       else   if (isattack == true)
         {

            Attack();
        }
       if (m_attacDel <= 0)
        {
            isattack = true;
            m_attacDel = WaitTime;
            animator.Rebind();
            animator.Play("long");

        }

       if(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Object.Destroy(this.gameObject);
        }

    }


    public override void Attack()
    {
        if (LongAttack)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.short") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.Rebind();
                animator.Play("long");
                Shoot = true;
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.long") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.70f)
            {
                if (Shoot == true)
                {
                    Instantiate(projectile, Projectile_zone.transform.position, transform.rotation);
                    Shoot = false;
                }


            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.long") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.Rebind();
                animator.Play("long");
                Shoot = true;

            }


        }
        else if (CloseAttack)
        {


            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.long") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                animator.Rebind();
                animator.Play("short");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.short") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.55f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.60f)
            {

                AttackZone.SetActive(true);

            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.short") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.Rebind();
                animator.Play("short");
            }
            else
            {
                AttackZone.SetActive(false);
            }


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
           
            this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackZone")
        {
          
            HP--;
            if (HP <= 0)
            {
                animator.Play("dead");
            }
          

        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Script_MainPlayer>().Death();
        }
    }


}
