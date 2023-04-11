using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerManager : MonoBehaviour
{
    int PlayerNum = 0;
    [SerializeField]
    GameObject PlayerSpawnPlace;
    [SerializeField]
    GameObject[] PlayerData;


    private void Awake()
    {
        PlayerCreate();
    }
    public void PlayerCreate()
    {

       
        Instantiate(PlayerData[PlayerNum], PlayerSpawnPlace.transform.position, Quaternion.identity);
    }



}
