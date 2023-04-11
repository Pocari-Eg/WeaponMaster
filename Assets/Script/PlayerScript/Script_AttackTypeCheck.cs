using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_AttackTypeCheck : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Check()
    {
        switch (this.gameObject.name)
        {
     
            case "Sting":
                {

                    Player.GetComponent<Script_MainPlayer>().SetAttackType(0);

                    break;
                }
            case "Swing":
                {

                    Player.GetComponent<Script_MainPlayer>().SetAttackType(1);


                    break;
                }
            case "Guard":
                {
                  
                    Player.GetComponent<Script_MainPlayer>().SetAttackType(2);


                    break;
                }
            default:
                break;

        }

    }
}
