using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_OneRail : MonoBehaviour
{
    [SerializeField]
    GameObject Rail;
    [SerializeField]
    Sprite push_Sprite;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "AttackZone")
        {
            Rail.GetComponent<Movement>().SetSpeed(3.0f);
            Rail.GetComponent<Movement>().On = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = push_Sprite;
        }
    }
 
}
