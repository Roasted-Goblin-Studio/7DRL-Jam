using System;
using System.Collections;
using UnityEngine;

public class Runes : MonoBehaviour
{
    [SerializeField] private MagicSeal _MagicSeal;
    [SerializeField] private GameObject _Rune;
    private bool _IsBroken = false;

    private Health _Health;

    private void Start()
    {
        _Health = GetComponent<Health>();
    }

    private void Update()
    {
        // better to not have a listener, but no time for delegates
        if (_IsBroken) return;
        if (_Health && _Health.CurrentHealth == 0) BreakRune();
    }

    private void BreakRune()
    {
        _IsBroken = true;
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Environment/Rune_Pickup", this.gameObject);
        _MagicSeal.DamageSeal();
        Destroy(_Rune);
    }
}