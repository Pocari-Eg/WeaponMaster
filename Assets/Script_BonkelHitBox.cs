using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BonkelHitBox : MonoBehaviour
{
    [SerializeField]
    GameObject Bonkel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackZone"&&collision.gameObject.name=="HammerBox")
        {
            if (Bonkel.GetComponent<script_BonKell>().getHp() > 0)
            {
                Bonkel.GetComponent<script_BonKell>().setHp(Bonkel.GetComponent<script_BonKell>().getHp() - 1);
                if (Bonkel.GetComponent<script_BonKell>().getHp() <= 0)
                {
                    Bonkel.GetComponent<script_BonKell>().Death();
                }
            }
        }
    }
    
}
