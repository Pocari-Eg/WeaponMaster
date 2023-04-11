using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SkyBlock : MonoBehaviour
{
    [SerializeField]
    GameObject GroundCol;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "HeadCheck")
        {
            GroundCol.SetActive(false);
        }
        if(collision.tag=="GroundCheck")
        {
            GroundCol.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GroundCol.SetActive(true);
        }
    }

}
