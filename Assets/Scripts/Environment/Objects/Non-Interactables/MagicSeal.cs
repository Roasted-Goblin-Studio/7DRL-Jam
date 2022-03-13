using System;
using System.Collections;
using UnityEngine;

public class MagicSeal : MonoBehaviour
{
    [SerializeField] private int _RunesRequired = 3;
    private int _RunesBroken = 0;

    FMOD.Studio.EventInstance PortalLoop;

    void Start()
    {
        PortalLoop = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Environment/Portal/Portal_Loop");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(PortalLoop, transform, GetComponent<Rigidbody2D>());
        PortalLoop.start();
        PortalLoop.release();
    }

    public void DamageSeal()
    {
        _RunesBroken++;
        if (_RunesBroken >= _RunesRequired) DestroySeal();
    }

    private void DestroySeal()
    {
        // TODO: animate the seal breaking first
        PortalLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Destroy(gameObject);
    }
}