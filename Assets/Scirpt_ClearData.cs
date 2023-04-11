using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scirpt_ClearData : MonoBehaviour
{
  public static Scirpt_ClearData instance;


public    GameObject[] StageButtons;
    public GameObject[] Lock;
    public bool[] StageClear;
    
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update


    private void Start()
    {
  
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
   
            StageButtons[i] = GameObject.Find("Stage" + (i + 2).ToString());
            Lock[i] = GameObject.Find("Lock" + (i + 2).ToString());
        }
        for (int i = 0; i < StageButtons.Length; i++)
        {
            if (StageClear[i])
            {
                if (StageButtons[i] != null)
                {
                    StageButtons[i].GetComponent<Button>().interactable = true;
                    Lock[i].SetActive(false);
                }
            }
        }
        
    }
    public void AllClear()
    {
        for(int i=0;i< StageClear.Length; i++)
        {
            StageClear[i] = true;
        }
    }
}
