using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;



public class Script_SoundBox : MonoBehaviour
{
    [SerializeField]
    public GameObject AMBSound;
    [SerializeField]
    public GameObject AMBVolum;

    [SerializeField]
    public GameObject UISound;
    [SerializeField]
    public GameObject UIVolum;

    [SerializeField]
    public GameObject SFXSound;
    [SerializeField]
    public GameObject SFXVolum;

    [SerializeField]
    public GameObject BGMSound;
    [SerializeField]
    public GameObject BGMVolum;

    FMOD.Studio.Bus UIBus;
    FMOD.Studio.Bus BGMBus;
    FMOD.Studio.Bus SFXBus;
    FMOD.Studio.Bus AMBBUS;
    // Start is called before the first frame update


    float AmbVol = 1.0f;
    float UIVol = 1.0f;
    float SfxVol = 1.0f;
    float BgmVol = 1.0f;

    void Start()
    {
        SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        UIBus = FMODUnity.RuntimeManager.GetBus("bus:/UI");
        BGMBus = FMODUnity.RuntimeManager.GetBus("bus:/BGM");
        AMBBUS = FMODUnity.RuntimeManager.GetBus("bus:/AMB");

        AMBBUS.getVolume(out AmbVol);
        BGMBus.getVolume(out BgmVol);
        SFXBus.getVolume(out SfxVol);
        UIBus.getVolume(out UIVol);

        AMBSound.GetComponent<Slider>().value = AmbVol;
        UISound.GetComponent<Slider>().value = UIVol;
        SFXSound.GetComponent<Slider>().value = SfxVol;
        BGMSound.GetComponent<Slider>().value = BgmVol;
    }

    private void FixedUpdate()
    {

        SetAMBVol();
        SetBGMVol();
        SetUIVol();
        SetSFXVol();
    }
    // Update is called once per frame
    public void SetAMBVol()
    {
   
        AMBBUS.setVolume(AMBSound.GetComponent<Slider>().value);
        AMBVolum.GetComponent<Text>().text = ((int)(AMBSound.GetComponent<Slider>().value * 100)).ToString();
    }
    public void SetSFXVol()
    {
      
        SFXBus.setVolume(SFXSound.GetComponent<Slider>().value);
        SFXVolum.GetComponent<Text>().text = ((int)(SFXSound.GetComponent<Slider>().value * 100)).ToString();
    }
    public void SetUIVol()
    {
      
        UIBus.setVolume(UISound.GetComponent<Slider>().value);
        UIVolum.GetComponent<Text>().text = ((int)(UISound.GetComponent<Slider>().value * 100)).ToString();
    }
    public void SetBGMVol()
    {
    
        BGMBus.setVolume(BGMSound.GetComponent<Slider>().value);
        BGMVolum.GetComponent<Text>().text = ((int)(BGMSound.GetComponent<Slider>().value * 100)).ToString();
    }
}
