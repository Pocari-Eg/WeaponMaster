using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Script_ScriptBox : MonoBehaviour
{
    public static Script_ScriptBox instance;


  public  GameObject ScriptText;
    [SerializeField]
    public GameObject Bg;

    bool isScripton = false;
    [SerializeField]
    float ScriptOnTimeMax;
    float ScriptOnTime;

    bool timeon;
    string curstring;
    private void Start()
    {
        instance = this;

        ScriptOnTime = ScriptOnTimeMax;


    }
    private void Update()
    {
        if (timeon == true)
        {
            if (ScriptOnTime > 0)
            {
                ScriptOnTime -= Time.deltaTime;
            }
            else if (ScriptOnTime <= 0)
            {
                Bg.SetActive(false);
                timeon = false;
            }
        }
    }


        public void SetBoxScript(string Text)
    {
        curstring = Text;
        ScriptText.GetComponent<Text>().text = curstring;
        isScripton = true;
        timeon = true;
        ScriptOnTime = ScriptOnTimeMax;
        Bg.SetActive(true);
    }

    public bool GetActive()
    {
        return Bg.active;
    }
    public string CurScript()
    {
        return curstring;
    }
}
