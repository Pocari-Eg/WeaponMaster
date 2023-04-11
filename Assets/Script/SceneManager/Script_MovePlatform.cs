using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class Script_MovePlatform : MonoBehaviour
{
    [SerializeField]
    GameObject EndPoint;
    [SerializeField]
    float Speed = 1.0f;
    [SerializeField]
    bool isDestoryBlock = false;
    // Start is called before the first frame update
    public bool onMove = false;

    SoundManager m_soundManager;
    //sound
    FMOD.Studio.EventInstance S_ChainDown;
    FMOD.Studio.EventInstance S_PlatfromDown;
    

    //oneShotSound;
    [FMODUnity.EventRef]
     string S_PlatfromStop;
    [FMODUnity.EventRef]
     string S_PlatfromDest;
    // Update is called once per frame

    private void Start()
    {
         SoundSet();
        m_soundManager = this.gameObject.GetComponent<SoundManager>();
    }
    void Update()
    {
        if(onMove)
        {
            m_soundManager.SoundPlay(S_PlatfromDown);
            Vector3 newPos = Vector3.MoveTowards(transform.position, EndPoint.transform.position, Speed * Time.deltaTime);
            transform.position = newPos;
            if (transform.position == EndPoint.transform.position)
            {
                onMove = false;
                m_soundManager.SoundStop(S_PlatfromDown);
               m_soundManager.SoundOneShot(S_PlatfromStop);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if (collision.gameObject.GetComponent<Script_BasicCreature>() != null)
            {
                if (collision.gameObject.GetComponent<Script_BasicCreature>().isBossMonster && isDestoryBlock)
                {
                    m_soundManager.SoundOneShot(S_PlatfromDest);
                    Object.Destroy(this.gameObject);
                }
            }
        }
    }

    //skyºí·° ¿ë
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if (collision.gameObject.GetComponent<Script_BasicCreature>() != null)
            {
                if (collision.gameObject.GetComponent<Script_BasicCreature>().isBossMonster && isDestoryBlock)
                {
                    m_soundManager.SoundOneShot(S_PlatfromDest);
                    Object.Destroy(this.gameObject);
                }
            }
        }
    }
    void SoundSet()
    {
       // S_ChainDown = RuntimeManager.CreateInstance("event:/WeaponMaster/Stage/SFX/Sfx_ChainDown");
        S_PlatfromDown = RuntimeManager.CreateInstance("event:/WeaponMaster/Stage/SFX/Sfx_PlatformDown");

        //string
        S_PlatfromStop = "event:/WeaponMaster/Stage/SFX/Sfx_PlatformStop";
        S_PlatfromDest = "event:/WeaponMaster/Stage/SFX/Sfx_PlatformDestroy";



    }
}
