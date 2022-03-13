using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //~~ COMPONENTS ~~\\
    // Used to contain metadata of the character state and attached Objects
    [SerializeField] protected CharacterTypes _CharacterType;
    [SerializeField] protected Collider2D _CharacterHitbox;
    protected CharacterInput _CharacterInput;
    protected CharacterMovement _CharacterMovement;

    protected Rigidbody2D _RigidBody2D;
    protected Camera _Camera;
    
    // Unity General
    public Rigidbody2D RigidBody2D { get => _RigidBody2D; set => _RigidBody2D = value; }
    public Collider2D CharacterHitbox { get => _CharacterHitbox; set => _CharacterHitbox = value; }
    public Camera Camera { get => _Camera; set => _Camera = value; }
    
    public CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }

    // Inputs
    public CharacterInput CharacterInput { get => _CharacterInput; }
    
    // Mouse
    private MouseCursor _MouseCursor;
    public MouseCursor MouseCursor { get => _MouseCursor; }

    // Global State Manager
    private GlobalStateManager _GlobalStateManager;

    // Collider Managers
    private LegColliderManager _LegColliderManager;
    public LegColliderManager LegColliderManager { get => _LegColliderManager; set => _LegColliderManager = value; }

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
        _CharacterMovement = GetComponent<CharacterMovement>();
    }

    protected virtual void Start() {
        GameObject GlobalStateManagerGameObject = GameObject.Find("GlobalStateManager");
        if(GlobalStateManagerGameObject != null) _GlobalStateManager = GlobalStateManagerGameObject.GetComponent<GlobalStateManager>();
        _LegColliderManager = GetComponentInChildren<LegColliderManager>();
    }

    private void Update() {
        HandlePauseInput();
        if(_GameIsPaused) GameIsPaused();
        HandleExitGame();
    }

    //~~ FLAGS ~~\\
    private bool _IsHitable = false;
    private bool _IsAlive = false;
    // TODO: manage these flags properly to ensure they are not unexptectedly tampered with by multiple components
    [SerializeField] private bool _IsActionable = true;
    [SerializeField] private bool _CanMove = true;

    public bool IsHitable { get => _IsHitable; set => _IsHitable = value; }
    public bool IsAlive { get => _IsAlive; set => _IsAlive = value; }
    public bool IsActionable { get => _IsActionable; set => _IsActionable = value; }
    public bool CanMove { get => _CanMove; set => _CanMove = value; }
    
    private bool _GameIsPaused = false;


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
        if(_GlobalStateManager.GameIsPaused && !_GameIsPaused){
            PauseGame();
            _GameIsPaused = true;
        }

        if(!_GlobalStateManager.GameIsPaused && _GameIsPaused){
            UnpauseGame();
            _GameIsPaused = false;
        }

        if(_GlobalStateManager == null || _CharacterInput == null) return;
        if (Input.GetKeyDown(_CharacterInput.PauseKeyCode) && !_GlobalStateManager.InPauseMenu){
            _GlobalStateManager.GameIsPaused = true;
            _GlobalStateManager.InPauseMenu = true;
        }
        else if(Input.GetKeyDown(_CharacterInput.PauseKeyCode) && _GlobalStateManager.InPauseMenu){
            _GlobalStateManager.GameIsPaused = false;
            _GlobalStateManager.InPauseMenu = false;
        }
    }

    private void PauseGame(){
        IsActionable = false;
        CanMove = false;
        GameIsPaused();
    }

    private void UnpauseGame(){
        IsActionable = true;
        CanMove = true;
    }

    private void GameIsPaused(){
        _CharacterMovement.ForceStopAllMovement();
    }

    private void HandleExitGame(){
        if (Input.GetKey(_CharacterInput.QuitKeyCode)) Debug.Log("Check");//Application.Quit();
    }
}
