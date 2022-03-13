using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string Event;
    public bool PlayOnAwake;

    [FMODUnity.EventRef]
    public string ProjectileEvent;
    FMOD.Studio.EventInstance PE;
    FMOD.Studio.PLAYBACK_STATE PbState;

    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }

    public void Start()
    {
        if (PlayOnAwake)
            PlayOneShot();
    }

    void OnEnable()
    {
        PE = FMODUnity.RuntimeManager.CreateInstance(ProjectileEvent);
        PE.getPlaybackState(out PbState);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(PE, transform, GetComponent<Rigidbody2D>());
        PE.start();
        PE.release();
    }

    void OnDisable()
    {
        PE.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
