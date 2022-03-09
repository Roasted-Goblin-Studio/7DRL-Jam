using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    [SerializeField] private bool _RoomIsActive = false;
    public bool RoomIsActive { get => _RoomIsActive; set => _RoomIsActive = value; }

}
