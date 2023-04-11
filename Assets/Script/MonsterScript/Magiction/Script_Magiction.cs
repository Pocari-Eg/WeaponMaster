using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

enum BulletType { Sting,Swing,Guard}

public class Script_Magiction : Script_Pawn_Control
{
   
   
    public Transform Bullet;
    [SerializeField]
    float BulletSpeed;
    [SerializeField]
    BulletType week;
    [SerializeField]
    GameObject ShootArea;

    bool isOneshot = false;

    [SerializeField]
    float WaitTime = 1.0f;
    [SerializeField]
     float AttackDelay = 3.0f;

    float[] random = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
   
    float m_attacDel;
    // Start is called before the first frame update
    void Start()
    {
       
        m_attacDel = AttackDelay;

        switch (week)
        {
            case BulletType.Sting:
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSkin("water");
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSlotsToSetupPose();
                GFX.GetComponent<SkeletonMecanim>().LateUpdate();
                break;
            case BulletType.Swing:
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSkin("fire");
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSlotsToSetupPose();
                GFX.GetComponent<SkeletonMecanim>().LateUpdate();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitTime > 0) {
            WaitTime -= Time.deltaTime;
         }
        else if(WaitTime < 0)
        {
            Attack();
        }


        
   

    }


   public override void  Attack()
    {
    

        if (m_attacDel > 0)
        {
            m_attacDel -= Time.deltaTime;
          
        }
        else if (m_attacDel < 0){
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
            {

                BulletType m_week;
                if (!WeekSet(Choose(random)))
                {
                    m_week = BulletType.Guard;

                }
                else
                {
                    m_week = week;
                    //    m_week = BulletType.Guard; 
                }
                Debug.Log(m_week.ToString());
                Bullet.GetComponent<Script_Projectile>().SetBulletSpeed(BulletSpeed);
                Bullet.GetComponent<Script_Projectile>().SetBulletType(m_week.ToString());

                Instantiate(Bullet, ShootArea.transform.position, Quaternion.identity);
                isOneshot = true;
                animator.SetTrigger("Idle");
                m_attacDel = AttackDelay;

            }
            else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack"))
            {
                animator.SetTrigger("Attack");

            }
          
        
        }
       
     
    }


    bool WeekSet(float f)
    {
        if (f <= 2)
        {

            return false;
        }
        else
            return true;
    }
    float Choose(float[] probs)
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.ToString() == week.ToString())
        {
            Death();
      }

    }

}


