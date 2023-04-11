using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MonsterManager : MonoBehaviour
{

   public int monsterNum = 0;
    [SerializeField]
    GameObject MonsterSpawnPlace;
    [SerializeField]
    GameObject[] MonsterData;

    [SerializeField]
    bool is_MonsterSpawn;
    private void Start()
    {
        
    }
    public void MonsterSpawn()
    {
        if (is_MonsterSpawn)
        {
           Instantiate(MonsterData[monsterNum], MonsterSpawnPlace.transform.position, Quaternion.identity);
        }
    }
}
