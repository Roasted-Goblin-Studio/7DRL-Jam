using System;
using System.Collections;
using UnityEngine;

public class MagicSeal : MonoBehaviour
{
    [SerializeField] private int _RunesRequired = 3;
    private int _RunesBroken = 0; 

    public void DamageSeal()
    {
        Debug.Log("BROKE A RUNE");
        _RunesBroken++;
        if (_RunesBroken >= _RunesRequired) DestroySeal();
    }

    private void DestroySeal()
    {
        // TODO: animate the seal breaking first
        Destroy(gameObject);
    }
}