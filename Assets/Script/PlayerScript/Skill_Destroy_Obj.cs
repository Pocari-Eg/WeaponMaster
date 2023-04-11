using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Destroy_Obj : MonoBehaviour
{
    // 파괴 되는 시간
    [SerializeField]
    private float Destory_time;

    [SerializeField]
    GameObject StopPos;

    [SerializeField]
    GameObject Effect;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    GameObject SkillObject;


 
    // 3초가 지나면 삭제
    private void Update()
    {

        this.transform.position = Vector3.MoveTowards(transform.position, StopPos.transform.position, moveSpeed);

        Destory_time += Time.deltaTime;

        if(Effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Skill")&& Effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Effect.SetActive(false);
        }
        if (Destory_time >= 5f)
        {            
            Object.Destroy(SkillObject);
        }
    }

    

    // 찬영님이 정하신 몬스터 태그인 enemy 또는 Monster 등에 따라 "enemy"부분을 수정해주시면 됩니다.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Object.Destroy(SkillObject);
        }
    }
}
