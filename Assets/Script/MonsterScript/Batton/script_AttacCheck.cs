using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_AttacCheck : MonoBehaviour
{

    [SerializeField]
    string Weakness;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackZone")
        {
         
            if (collision.gameObject.name==Weakness){
                Object.Destroy(gameObject);
            }
        }
    }
}
