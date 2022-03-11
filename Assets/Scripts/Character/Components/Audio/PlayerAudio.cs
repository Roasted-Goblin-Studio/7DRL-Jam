using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance Walk;

    void Start()
    {
        Walk = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Footsteps");
    }

    void PlayerWalk()
    {
        Walk.start();
    }

    void OnDestroy()
    {
        Walk.release();
    }
}
