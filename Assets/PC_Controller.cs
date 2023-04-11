using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PC_Controller : MonoBehaviour
{


    public  GameObject HammerButton;
    public GameObject skillButton;
    public GameObject JumpButton;

    public GameObject RapierCutButton;
    public GameObject RapierStabButton;
    public GameObject RapierGuradButton;

    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            if (Player.GetComponent<Script_MainPlayer>().isAttack == true)
            {
                JumpButton.GetComponent<Button>().enabled = false;
            }
            else if (Player.GetComponent<Script_MainPlayer>().isAttack == false)
            {
                JumpButton.GetComponent<Button>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(HammerButton.active==true && HammerButton != null)
                HammerButton.GetComponent<Button>().onClick.Invoke();
            else if (RapierCutButton.active == true && RapierCutButton != null)
                RapierCutButton.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (skillButton.active == true && skillButton != null)
            {
                skillButton.GetComponent<Button>().onClick.Invoke();
            }
            else if (RapierStabButton.active == true && RapierStabButton != null)
            {
                RapierStabButton.GetComponent<Button>().onClick.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (RapierGuradButton.active == true&& RapierGuradButton != null)
                RapierGuradButton.GetComponent<Button>().onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (JumpButton.GetComponent<Button>().enabled == true && JumpButton != null)
                JumpButton.GetComponent<Button>().onClick.Invoke();
          
        }

    }
}
