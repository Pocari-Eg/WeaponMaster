using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Transform[] Waypos;
    [SerializeField]
    float speed = 5f;
    int WayNum = 0;
    public bool On = false;
    // Start is called before the first frame update
    FMOD.Studio.EventInstance S_RailSound;
    SoundManager m_SoundManager;
    void Start()
    {
        transform.position = Waypos[WayNum].transform.position;
        m_SoundManager = this.gameObject.GetComponent<SoundManager>();
        S_RailSound= FMODUnity.RuntimeManager.CreateInstance("event:/WeaponMaster/Stage/SFX/Sfx_RailPlatform");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
         
            collision.transform.SetParent(transform);
          
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (On == true)
        {
            m_SoundManager.SoundPlay(S_RailSound);
            MovePath();
        }
    }

    void MovePath()
    {
        
        transform.position = Vector3.MoveTowards
            (transform.position, Waypos[WayNum].transform.position, speed * Time.deltaTime);

        if (transform.position == Waypos[WayNum].transform.position)
            WayNum++;

        if (WayNum == Waypos.Length)
            WayNum = 0;
    }
 public   void SetSpeed(float m)
    {
        speed = m;
    }
}
