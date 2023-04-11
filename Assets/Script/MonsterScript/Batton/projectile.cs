using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Transform target; //플레이어의 위치

    public float speed = 5f;

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // 파괴 애니메이션 추가 예정
        if (collision.gameObject.tag =="Player"||collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "Ground") {
     
            Destroy(gameObject);
        }
     
    }


    public void SetTarget()
    {
        // 플레이어 방향 각도 구하기

        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = target.position - transform.position;
        

        float angle = Mathf.Atan2(dir.y+0.0f, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

      
    }
   
}
