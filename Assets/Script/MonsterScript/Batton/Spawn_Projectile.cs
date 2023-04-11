using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Projectile : MonoBehaviour
{
    public GameObject projectile; //탄알의 원본 프리팹
   

    [SerializeField]
    private float rate = 3f; //탄알 생성 주기
    private float timeAfterSpawn; //탄알 생성 후 지난 시간
    
    void Start()
    {
        timeAfterSpawn = 0f;
    }

    
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn > rate)
        {
            timeAfterSpawn = 0f;

           
        }

    }
    
}
