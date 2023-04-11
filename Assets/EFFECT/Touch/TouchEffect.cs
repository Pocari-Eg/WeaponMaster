using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    public GameObject Prefab;
    float spawnTime;
    public float defalutTime = 0.05f;

    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                // Create a particle if hit
                StartCreatEffect();
                spawnTime = 0;
            }
        }



        spawnTime += Time.deltaTime;
        
    }

    public void StartCreatEffect()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        Instantiate(Prefab, mPos, Quaternion.identity);

    }
}
