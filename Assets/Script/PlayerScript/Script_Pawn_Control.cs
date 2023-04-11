using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Spine;
using Spine.Unity;
public class Script_Pawn_Control : MonoBehaviour
{
    private GameObject Pawn; // ÀÌµ¿ÇÒ Pawn
    private float m_JumpPower = 0.1f; //Á¡ÇÁ Å©±â
    private float m_MoveSpeed = 0.1f; //ÀÌµ¿ ¼Óµµ
    private float m_inertia = 0.0f;

    public GameObject GFX;
    public Animator animator;

    [SerializeField]
     string GFXNum;

  public  FMOD.Studio.EventInstance MoveSoundEv;

    void Awake()
    {
        if(GFX!=null)
        animator = GFX.GetComponent<Animator>();

    }

    public void leftMove()
    {
        Pawn.transform.position -= new Vector3(m_MoveSpeed*Time.deltaTime, 0.0f);
        Pawn.GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

    }
  public  void RightMove()
    {
        Pawn.transform.position += new Vector3(m_MoveSpeed * Time.deltaTime, 0.0f);
        Pawn.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Jump(ref bool jump)
    {

        if (!jump)
            return;

        //m_MoveSpeed = m_MoveSpeed / 2.5f;
        Pawn.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    
        Vector3 JumpVelo = new Vector3(m_MoveSpeed* m_inertia, m_JumpPower);
        
        Pawn.GetComponent<Rigidbody2D>().AddForce(JumpVelo, ForceMode2D.Impulse);
      
        jump = false;
        SetInertia(0.0f);
       
    }


    public virtual  void Moving() { }
    public virtual void Attack() { }
    public virtual void Death() { Object.Destroy(this.gameObject); }

    public GameObject GetGameObject() { return Pawn; }

    public float GetMoveSpeed() { return m_MoveSpeed; }
    public void SetMoveSpeed(float speed) { m_MoveSpeed = speed; }

    public void SetGameObject(GameObject m_gameObject) { Pawn = m_gameObject; }

    public void SetJumpPower(float power) { m_JumpPower = power; }
    public void SetInertia(float inertia) { m_inertia = inertia; }

    public string GetGFXNum() { return GFXNum; }
    public void SetGFXNum(string n) { GFXNum = n; }

    //sound



}
