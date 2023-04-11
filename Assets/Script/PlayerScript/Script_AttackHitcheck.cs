using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AttackHitcheck : MonoBehaviour
{

    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

   
        if (collision.gameObject.tag == "Ground"&&this.gameObject.name== "HammerBox")
        {
       
            Script_PlayerControl.instance.AttackShake();
            Player.GetComponent<Script_MainPlayer>().HitSoundPlay();
            Player.GetComponent<Script_MainPlayer>().Trigger = true;
            Debug.Log(Player.GetComponent<Script_MainPlayer>().Trigger);




        }
    }
}
