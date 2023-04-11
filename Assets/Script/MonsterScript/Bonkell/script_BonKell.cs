using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class script_BonKell : Script_Pawn_Control
{
    enum BulletType { Sting, Swing, Guard}


    public GameObject BreathGFX;
     Animator Breathanimator;

    [SerializeField]
    int Hp;
    public Transform Bullet;
    [SerializeField]
    float BulletSpeed;
    [SerializeField]
    BulletType week;
    [SerializeField]
    GameObject ShootArea;

    [SerializeField]
    GameObject APatton;
    [SerializeField]
    GameObject BPatton;
    enum Patton { a,b,c};

    [SerializeField]
    GameObject LSPawn;
    [SerializeField]
    GameObject RSPawn;
    [SerializeField]
    GameObject Grouptone;

    [SerializeField]
    GameObject Potal;

    [SerializeField]
    GameObject Hammer;
    [SerializeField]
    GameObject Rapier;
    [SerializeField]
    GameObject WeaponSpawn;

    [SerializeField]
    float AttackDelayMax = 2.5f;
    float curDleay;

    [SerializeField]
    GameObject hitBoxL;
    [SerializeField]
    GameObject hitBoxR;
    int attackcount = 0;
    int Randompatton;

    [SerializeField]
    GameObject[] Heart;
    [SerializeField]
    Sprite[] HpImage;
   
    // Start is called before the first frame update
    void Start()
    {
        curDleay = AttackDelayMax;
        Randompatton = Random.Range(0, 3);
      

        Breathanimator = BreathGFX.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp == 2)
        {
            Heart[0].GetComponent<Image>().sprite = HpImage[1];
            Heart[1].GetComponent<Image>().sprite = HpImage[1];

        }
        else if (Hp == 1)
        {
            Heart[0].GetComponent<Image>().sprite = HpImage[1];
            Heart[1].GetComponent<Image>().sprite = HpImage[0];

        }
    
    
        
    

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            hitBoxL.GetComponent<BoxCollider2D>().enabled = true;
            hitBoxR.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            hitBoxL.GetComponent<BoxCollider2D>().enabled = false;
            hitBoxR.GetComponent<BoxCollider2D>().enabled = false;

        }
        if (curDleay <= 0.0f)
        {
            RandomPatton();
        }
        else
        {
            curDleay -= Time.deltaTime;
        }
    }

   void RandomPatton()
    {
     
        if (attackcount == 2)
        {
            Randompatton = 3;
            attackcount = 0;
        }
        switch (Randompatton)
        {
            case 0:
                APattonAttack();
             
                break;
            case 1:
                BPattonAttack();
        
                break;
            case 2:
                CPattonAttack();
     
                break;
            case 3:
                DPattonAttack();
                break;

        }
    }

        void APattonAttack()
        {

        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.a") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f) || (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.a2") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f))
        {
            animator.SetTrigger("Idle");
          Randompatton = Random.Range(0, 3);
            curDleay = AttackDelayMax;
            APatton.SetActive(false);
            attackcount++;


        }
        else if ((animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.a") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.60f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.55f) ||
            (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.a2") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.60f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.55f))
        {
          
            APatton.SetActive(true);
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("a") && !animator.GetCurrentAnimatorStateInfo(0).IsName("a2"))
        {
            int Patton_num = Random.Range(1, 10);
            int num = Patton_num % 2;
         
            APatton.SetActive(false);
            switch (num)
            {
                case 0:
                    APatton.transform.rotation = new Quaternion(0, 0, 0, 1);
                    animator.SetTrigger("APattonR");
                    Script_ScriptBox.instance.SetBoxScript("움직이는 손 반대 방향으로 피하세요!");
                    break;
                case 1:
                    APatton.transform.rotation = new Quaternion(0, 1, 0, 0);
                    animator.SetTrigger("APattonL");
                    Script_ScriptBox.instance.SetBoxScript("움직이는 손 반대 방향으로 피하세요!");
                    break;
                default:
                    break;
            }

        }
        else
        {
            APatton.SetActive(false);
        }
    }

    void BPattonAttack()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.b") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
        {
         
            animator.SetTrigger("Idle");
           Randompatton = Random.Range(0, 3);
            curDleay = AttackDelayMax;
            BPatton.SetActive(false);
            attackcount++;
         

        }
        else     if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.b") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.75f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f)
        {
      
            BPatton.SetActive(true);
            Breathanimator.Rebind();
            Breathanimator.Play("Breath");
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("b"))
        {
            animator.SetTrigger("BPatton");
            Script_ScriptBox.instance.SetBoxScript("오른쪽 끝으로 피하세요!");
        }
    }

    void CPattonAttack()
    {

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.c") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
            {
               ProjectileShoot();
                animator.SetTrigger("Idle");
                Randompatton = Random.Range(0, 3);
                curDleay = AttackDelayMax;
            attackcount++;
            Instantiate(Rapier, WeaponSpawn.transform.position, Quaternion.identity);

        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("c"))
            {
                animator.SetTrigger("CPatton");
            Script_ScriptBox.instance.SetBoxScript("베기,찌르기,막기를 사용하세요!");

        }


    }

    void DPattonAttack()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.d") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.00f)
        {
            GameObject RGroup = Instantiate(Grouptone, RSPawn.transform.position, Quaternion.identity);
            GameObject LGroup = Instantiate(Grouptone, LSPawn.transform.position, Quaternion.identity);
            LGroup.GetComponent<Script_BasicCreature>().Reverse();
    
            animator.SetTrigger("Idle");
           Randompatton = Random.Range(0, 3);
            curDleay = AttackDelayMax;
            Instantiate(Hammer, WeaponSpawn.transform.position, Quaternion.identity);
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("d"))
        {
            animator.SetTrigger("DPatton");
            Script_ScriptBox.instance.SetBoxScript("망치를 이용하여 그룹톤을 처치하고 본켈의 손을 가격하세요!");

        }


    }


    void ProjectileShoot()
    {
        int Projectnum = 3;
        BulletType m_week=BulletType.Sting;

        for (int i = 0; i < Projectnum; i++)
        {
            int Patton_num = Random.Range(0, 3);
            switch (Patton_num)
            {
                case 0:
                    m_week = BulletType.Sting;
                    break;
                case 1:
                    m_week = BulletType.Swing;
                    break;
                case 2:
                    m_week = BulletType.Guard;
                    break;
                default:
                    break;
            }
            float ranx=Random.Range(-4, 4);
            float rany = Random.Range(0, 3);

            Bullet.GetComponent<Script_Projectile>().SetBulletSpeed(BulletSpeed);
            Bullet.GetComponent<Script_Projectile>().SetBulletType(m_week.ToString());
            Instantiate(Bullet, ShootArea.transform.position+new Vector3(ranx, rany, 0.0f), Quaternion.identity);
        }
    }
    public override void Death()
    {
        Heart[0].GetComponent<Image>().sprite = HpImage[0];
        Heart[1].GetComponent<Image>().sprite = HpImage[0];
        Potal.GetComponent<BoxCollider2D>().enabled = true;
        base.Death();
        

    }

    public int getHp()
    {
        return Hp;
    }
    public void setHp(int n)
    {
        Hp = n;
    }
}
