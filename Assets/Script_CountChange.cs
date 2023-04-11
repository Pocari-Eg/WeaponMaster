using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Script_CountChange : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        
        if (Player.GetComponent<Script_MainPlayer>().GetGFXNum() == "2")
        {
            if (Script_WeaponManager.instance.isInfinity == true)
            {
                this.gameObject.GetComponent<Text>().text = "¡Ä";
            }
            else
            {
                this.gameObject.GetComponent<Text>().text = Player.GetComponent<Script_MainPlayer>().GetWeaponCount().ToString();
            }
        }
        else if (Player.GetComponent<Script_MainPlayer>().GetGFXNum() == "3")
        {
            this.gameObject.GetComponent<Text>().text = "¡Ä";
        }
    }
}
