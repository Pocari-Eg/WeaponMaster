using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BattonCloseAttack : MonoBehaviour
{
    public float KnockBackPower;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-KnockBackPower, 0.0f, 0.0f);
        }
    }
}
