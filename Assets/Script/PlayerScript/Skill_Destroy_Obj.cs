using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Destroy_Obj : MonoBehaviour
{
    // �ı� �Ǵ� �ð�
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


 
    // 3�ʰ� ������ ����
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

    

    // �������� ���Ͻ� ���� �±��� enemy �Ǵ� Monster � ���� "enemy"�κ��� �������ֽø� �˴ϴ�.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Object.Destroy(SkillObject);
        }
    }
}
