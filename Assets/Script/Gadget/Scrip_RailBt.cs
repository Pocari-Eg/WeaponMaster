using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrip_RailBt : MonoBehaviour
{
    [SerializeField]
    GameObject Rail;
    [SerializeField]
    Sprite push_Sprite;
    // Start is called before the first frame update


    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackZone")
        {

     
            Script_SecondSceneObjectManager.instance.SetButton(this.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = push_Sprite;


        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackZone")
        {
          
            Script_SecondSceneObjectManager.instance.SetButton(null);

        }
    }
   public GameObject GetRail()
    {
        
        return Rail;
    } 
}
