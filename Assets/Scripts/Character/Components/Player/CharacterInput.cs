using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    // Movement
    //~~ Horizoizontal
    [SerializeField] private KeyCode _MovementLeftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode _MovementRightKeyCode = KeyCode.D;
    public KeyCode MovementLeftKeyCode  {get => _MovementLeftKeyCode; set => _MovementLeftKeyCode = value;}
    public KeyCode MovementRightKeyCode {get => _MovementRightKeyCode; set => _MovementRightKeyCode = value;}

    //~~ Vertical
    [SerializeField] private KeyCode _MovementUpKeyCode = KeyCode.W;
    [SerializeField] private KeyCode _MovementDownKeyCode = KeyCode.S;
    public KeyCode MovementUpKeyCode    {get => _MovementUpKeyCode; set => _MovementUpKeyCode = value;}
    public KeyCode MovementDownKeyCode  {get => _MovementDownKeyCode; set => _MovementDownKeyCode = value;}

    // Weapons
    private int _MousePrimaryKeyCode = 0;       // LEFT CLICK
    private int _MouseSecondaryKeyCode = 1;     // RIGHT CLICK 
    private int _MouseScrollKeyCode = 2;        // SCROLL WHEEL CLICK
    public int MousePrimaryKeyCode      { get => _MousePrimaryKeyCode; }
    public int MouseSecondaryKeyCode    { get => _MouseSecondaryKeyCode; }
    public int MouseScrollKeyCode       { get => _MouseScrollKeyCode; }

    // Pause
    [SerializeField] private KeyCode _PauseKeyCode = KeyCode.Backspace;
    public KeyCode PauseKeyCode  {get => _PauseKeyCode; set => _PauseKeyCode = value;}

    // Interact with Object
    [SerializeField] private KeyCode _InteractKeyCode = KeyCode.E;
    public KeyCode InteractKeyCode  {get => _InteractKeyCode; set => _InteractKeyCode = value;}

    // Quit
    [SerializeField] private KeyCode _QuitKeyCode = KeyCode.Escape;
    public KeyCode QuitKeyCode  {get => _QuitKeyCode; set => _QuitKeyCode = value;}
}