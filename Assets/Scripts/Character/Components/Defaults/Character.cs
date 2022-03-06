using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //~~ COMPONENTS ~~ \\
    // Used to contain metadata of the character state and attached Objects
    [SerializeField] protected CharacterTypes _CharacterType;
    protected CharacterInput _CharacterInput;

    protected Rigidbody2D _RigidBody2D;
    protected Camera _Camera;
    
    // Unity General
    public Rigidbody2D RigidBody2D { get => _RigidBody2D; set => _RigidBody2D = value; }
    public Camera Camera { get => _Camera; set => _Camera = value; }

    // Inputs
    public CharacterInput CharacterInput { get => _CharacterInput; }
    
    // Mouse
    private MouseCursor _MouseCursor;
    public MouseCursor MouseCursor { get => _MouseCursor; }


    // Customs
    public CharacterTypes CharacterType { get => _CharacterType; set => _CharacterType = value; }
    public enum CharacterTypes {
        Inactive,
        Player,
        AI
    }

    protected virtual void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        _CharacterInput = GetComponent<CharacterInput>();
        _MouseCursor = GetComponent<MouseCursor>();
    }

    protected virtual void Start() {
        
    }

    //~~ FLAGS ~~\\
    private bool _IsHitable = false;
    private bool _IsAlive = false;

    public bool IsHitable { get => _IsHitable; set => _IsHitable = value; }
    public bool IsAlive { get => _IsAlive; set => _IsAlive = value; }

}
