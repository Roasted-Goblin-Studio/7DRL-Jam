using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [SerializeField] private bool _DebugMode;

    protected Character _Character;
    protected Animator _Animator;
    protected CharacterAchievements _CharacterAchievements;
    protected CharacterInput _CharacterInput;
    protected CharacterMovement _CharacterMovement;

    public CharacterAchievements CharacterAchievements { get => _CharacterAchievements; set => _CharacterAchievements = value; }
    public CharacterInput CharacterInput { get => _CharacterInput; set => _CharacterInput = value; }
    public CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }
    public bool DebugMode { get => _DebugMode; set => _DebugMode = value; }


    protected virtual void Awake(){
        _Character = GetComponent<Character>();
        _Animator = GetComponentInChildren<Animator>();
        CharacterAchievements = GetComponent<CharacterAchievements>();
        CharacterInput = GetComponent<CharacterInput>();
        CharacterMovement = GetComponent<CharacterMovement>();
    }

    protected virtual void Start(){

    }

    protected virtual void Update(){
        HandleInput();
        HandleBasicComponentFunction();
    }

    protected virtual void FixedUpdate(){
        HandlePhysicsComponentFunction();
    }

    protected virtual void HandleInput(){
        if(_Character.CharacterType == Character.CharacterTypes.Player) HandlePlayerInput();
        if(_Character.CharacterType == Character.CharacterTypes.AI) HandleAIInput();
    }

    protected virtual void HandlePlayerInput(){

    }

    protected virtual void HandleAIInput(StateController controller = null){

    }

    protected virtual void HandleBasicComponentFunction(){

    }

    protected virtual void HandlePhysicsComponentFunction(){

    }

    protected virtual bool IsPlayer(){
        return _Character.CharacterType == Character.CharacterTypes.Player;
    }

    protected virtual bool IsAI(){
        return _Character.CharacterType == Character.CharacterTypes.AI;
    }
}
