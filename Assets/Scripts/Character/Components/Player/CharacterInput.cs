using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    // Movement
    [SerializeField] private KeyCode _MovementLeftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode _MovementRightKeyCode = KeyCode.D;
    public KeyCode MovementLeftKeyCode {get => _MovementLeftKeyCode; set => _MovementLeftKeyCode = value;}
    public KeyCode MovementRightKeyCode {get => _MovementRightKeyCode; set => _MovementRightKeyCode = value;}

    [SerializeField] private KeyCode _MovementUpKeyCode = KeyCode.W;
    [SerializeField] private KeyCode _MovementDownKeyCode = KeyCode.S;
    public KeyCode MovementUpKeyCode {get => _MovementUpKeyCode; set => _MovementUpKeyCode = value;}
    public KeyCode MovementDownKeyCode {get => _MovementDownKeyCode; set => _MovementDownKeyCode = value;}
}