using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_InAttackZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
            this.gameObject.GetComponentInParent<Script_Creature_Batton>().CloseAttack = true;

            this.gameObject.GetComponentInParent<Script_Creature_Batton>().LongAttack = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<Script_Creature_Batton>().CloseAttack = false;

            this.gameObject.GetComponentInParent<Script_Creature_Batton>().LongAttack = true;
        }
    }



}
