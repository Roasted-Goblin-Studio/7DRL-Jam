using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public LevelMusicManager end;

    FMOD.Studio.EventInstance Walk;
    FMOD.Studio.EventInstance Melee_Swing;
    FMOD.Studio.EventInstance Melee_Impact;
    FMOD.Studio.EventInstance Ranged_Throw;
    FMOD.Studio.EventInstance Skull_Pop;
    FMOD.Studio.EventInstance Death;
    FMOD.Studio.EventInstance Skull_Grow;
    FMOD.Studio.EventInstance Player_Hurt;
    FMOD.Studio.EventInstance Death_Scream;

    void Start()
    {
        Walk = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Footsteps");
        Melee_Swing = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Attack_Melee_Swing");
        Melee_Impact = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Attack_Melee_Impact");
        Ranged_Throw = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Attack_Throw_Bone");
        Death = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Death");
        Skull_Pop = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Skull_Pop");
        Skull_Grow = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Skull_Grow");
        Player_Hurt = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Hurt");
        Death_Scream = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Player_Die_Scream");
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

    void Pop()
    {
        Skull_Pop.start();
    }

    void Grow()
    {
        Skull_Grow.start();
    }

    void Die()
    {
        Death.start();
        end.StopMusic();
    }

    void Scream()
    {
        Death_Scream.start();
    }

    void Hurt()
    {
        Player_Hurt.start();
    }

    void OnDestroy()
    {
        Walk.release();
        Melee_Impact.release();
        Melee_Swing.release();
        Ranged_Throw.release();
        Skull_Grow.release();
        Skull_Pop.release();
        Death.release();
        Player_Hurt.release();
        Death_Scream.release();
    }
}
