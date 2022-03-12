using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    // Room control
    [SerializeField] private bool _RoomIsActive = false;
    public bool RoomIsActive { get => _RoomIsActive; set => _RoomIsActive = value; }

    // Start up

    private void Start() {
        
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
