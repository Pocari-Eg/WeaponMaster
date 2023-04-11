using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Spine.Unity;
public class Script_Projectile : MonoBehaviour
{


    [SerializeField]
    float BulletSpeed;
    [SerializeField]
    string BulletType = null;
    [SerializeField]
    GameObject target;
    private NavMeshAgent agent;
    [SerializeField]
    GameObject GFX;

    
    bool targetLock = false;
    void Start()
    {
        switch (BulletType)
        {
            case "Sting":
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSkin("blue");
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSlotsToSetupPose();
                GFX.GetComponent<SkeletonMecanim>().LateUpdate();

                break;
            case "Swing":
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSkin("red");
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSlotsToSetupPose();
                GFX.GetComponent<SkeletonMecanim>().LateUpdate();

                break;
            case "Guard":
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSkin("yellow");
                GFX.GetComponent<SkeletonMecanim>().skeleton.SetSlotsToSetupPose();
                GFX.GetComponent<SkeletonMecanim>().LateUpdate();

                break;
        }

        target = GameObject.FindGameObjectWithTag("Player"); ;

        agent = GetComponent<NavMeshAgent>();
       
        agent.speed = BulletSpeed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        targetLock = true;
    }
    void Update()
    {
       
        if (targetLock == true || target != null)
        {


            if (target != null)
            {
                agent.SetDestination(target.transform.position);

            }
     
        
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Object.Destroy(this.gameObject);
        }
      


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        
            if (collision.gameObject.name.ToString() == BulletType.ToString())
            {
                Object.Destroy(gameObject);
            }
      
    }

    public void SetBulletType(string s)
    {
        BulletType = s;
    }
    public void SetBulletSpeed(float s)
    {
        BulletSpeed = s;
    }
  

  
}

