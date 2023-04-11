using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GroundCheck : MonoBehaviour
{

    bool firstTouch = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponentInParent<Script_MainPlayer>().On_Ground = true;
            this.gameObject.GetComponentInParent<Script_MainPlayer>().SetMoveSpeed(this.gameObject.GetComponentInParent<Script_MainPlayer>().GetPlayer().GetPlayerSpeed());

            if (firstTouch == false)
            {
                this.gameObject.GetComponentInParent<Script_MainPlayer>().LandSoundPlay();
            }
            else if (firstTouch == true)
            {
                firstTouch = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Ground")
        {
          
            //this.gameObject.GetComponentInParent<Script_MainPlayer>().On_Ground = false;
            
        }
            
    
    }
}
