using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Hitbox and Colliders")]
    [SerializeField] protected Collider2D _CharacterHitbox;
    protected Rigidbody2D _RigidBody2D;
    // private LegColliderManager _LegColliderManager;

    [Header("Camera")]
    protected Camera _Camera;
    
    [Header("Character Components")]
    protected CharacterInput _CharacterInput;
    protected CharacterMovement _CharacterMovement;

    [Header("General")]
    [SerializeField] protected CharacterTypes _CharacterType;

    [Header("Mouse Cursor")]
    private MouseCursor _MouseCursor;

    [Header("Global State Manager")]
    private GlobalStateManager _GlobalStateManager;

    [Header("Flags")]
    private bool _IsHitable = false;
    private bool _IsAlive = false;
    private bool _IsActionable = true;
    private bool _CanMove = true;
    
    // Public
    public Rigidbody2D RigidBody2D { get => _RigidBody2D; set => _RigidBody2D = value; }
    public Collider2D CharacterHitbox { get => _CharacterHitbox; set => _CharacterHitbox = value; }
    public Camera Camera { get => _Camera; set => _Camera = value; }
    
    public CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }

    public MouseCursor MouseCursor { get => _MouseCursor; }

    // Inputs
    public CharacterInput CharacterInput { get => _CharacterInput; }

    // public LegColliderManager LegColliderManager { get => _LegColliderManager; set => _LegColliderManager = value; }

    // Customs
    public CharacterTypes CharacterType { get => _CharacterType; set => _CharacterType = value; }
    public enum CharacterTypes {
        Inactive,
        Player,
        AI
    }

    public bool IsHitable { get => _IsHitable; set => _IsHitable = value; }
    public bool IsAlive { get => _IsAlive; set => _IsAlive = value; }
    public bool IsActionable { get => _IsActionable; set => _IsActionable = value; }
    public bool CanMove { get => _CanMove; set => _CanMove = value; }

    protected virtual void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        _CharacterMovement = GetComponent<CharacterMovement>();

        if(_CharacterType == CharacterTypes.Player){
            GameObject CameraGameObject = GameObject.Find("Main Camera");
            if(CameraGameObject != null) CameraGameObject.GetComponent<Camera>();

            _CharacterInput = GetComponent<CharacterInput>();
            _MouseCursor = GetComponent<MouseCursor>();
        }
    }

    protected virtual void Start() {
        GameObject GlobalStateManagerGameObject = GameObject.Find("GlobalStateManager");
        if(GlobalStateManagerGameObject != null) _GlobalStateManager = GlobalStateManagerGameObject.GetComponent<GlobalStateManager>();
        
    }

    private void Update() {

        // HandleExitGame();
        if(_CharacterType == CharacterTypes.Player){
            if (Input.GetKeyDown(_CharacterInput.PauseKeyCode)) HandlePauseInput();
        }
        if(_GlobalStateManager.GameIsPaused) GameIsPaused();
    }

    public void Lock(){
        _IsActionable = false;
        _CanMove = false;
    }

    public void Unlock(){
        _IsActionable = true;
        _CanMove = true;
    }

    public void FaceRight(){
        if(!CharacterMovement.FacingRight) CharacterMovement.Flip();
    }

    public void FaceLeft(){
        if(CharacterMovement.FacingRight) CharacterMovement.Flip();
    }

    private void HandlePauseInput(){
        if(_GlobalStateManager == null) return;
        
        if(!_GlobalStateManager.GameIsPaused){
            PauseGame();
        }
        else if(_GlobalStateManager.GameIsPaused){
            UnpauseGame();
        }
    }

    private void PauseGame(){
        Lock();
        _GlobalStateManager.GameIsPaused = true;
    }

    private void UnpauseGame(){
        Unlock();
        _GlobalStateManager.GameIsPaused = false;
    }

    private void GameIsPaused(){
        _CharacterMovement.ForceStopAllMovement();
    }

    // private void HandleExitGame(){
    //     if (Input.GetKey(_CharacterInput.QuitKeyCode)) Debug.Log("Check");//Application.Quit();
    // }
}
