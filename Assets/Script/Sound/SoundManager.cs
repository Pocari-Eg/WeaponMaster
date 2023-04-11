using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class SoundManager : MonoBehaviour
{
 


    public void SoundPlay(FMOD.Studio.EventInstance eventInstance)
    {
        if (FMOD.Studio.PLAYBACK_STATE.PLAYING != PlaybackState(eventInstance))
        {

            eventInstance.start();
        }
    }
    public void SoundStop(FMOD.Studio.EventInstance eventInstance)
    {
        if (FMOD.Studio.PLAYBACK_STATE.PLAYING == PlaybackState(eventInstance))
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
    public void SoundOneShot(string SoundPath)
    {
        FMODUnity.RuntimeManager.PlayOneShot(SoundPath);
    }
    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
}
