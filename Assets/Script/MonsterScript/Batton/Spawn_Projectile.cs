using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Projectile : MonoBehaviour
{
    public GameObject projectile; //ź���� ���� ������
   

    [SerializeField]
    private float rate = 3f; //ź�� ���� �ֱ�
    private float timeAfterSpawn; //ź�� ���� �� ���� �ð�
    
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
