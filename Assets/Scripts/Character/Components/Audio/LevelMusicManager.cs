using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicManager : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;

    [FMODUnity.EventRef]
    [SerializeField]
    private string musicEvent;

    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        Music.start();
        Music.release();
        DontDestroyOnLoad(this.gameObject);
    }

    public void StopMusic()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
