using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance Walk;
    FMOD.Studio.EventInstance Melee_Swing;
    FMOD.Studio.EventInstance Melee_Impact;
    FMOD.Studio.EventInstance Ranged_Throw;
    FMOD.Studio.EventInstance Skull_Pop;
    FMOD.Studio.EventInstance Death;

    void Start()
    {
        Walk = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Footsteps");
        Melee_Swing = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Attack_Melee_Swing");
        Melee_Impact = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Attack_Melee_Impact");
        Ranged_Throw = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Attack_Throw_Bone");
        Death = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Death");
        Skull_Pop = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Skull_Pop");
    }

    void PlayerWalk()
    {
        Walk.start();
    }

    void MeleeSwing()
    {
        Melee_Swing.start();
    }

    void MeleeImpact()
    {
        Melee_Impact.start();
    }

    void Throw()
    {
        Ranged_Throw.start();
    }

    void OnDestroy()
    {
        Walk.release();
        Melee_Impact.release();
        Melee_Swing.release();
        Ranged_Throw.release();
    }
}
