using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Brain of the AI
    [Header("State")]
    [SerializeField] private AIState _StartingState;

    [SerializeField] private AIState _RemainInState;
    [SerializeField] private AIState _DeathState;
    private AIState _CurrentMacroState;

    [SerializeField] private float _DetectArea = 3f;
    [SerializeField] private LayerMask _TargetMask;

    [SerializeField] private bool _FollowPlayerMovement;

    private CharacterMovement _CharacterMovement;
    private CharacterMeleeAttack _CharacterMeleeAttack;
    private CharacterAttack _CharacterAttack;
    private Character _Character;
    private CharacterHealth _CharacterHealth;

    private Transform _Target;
    private Collider2D _TargetCollider;
    private GameObject _GameObject;

    private bool _TargetSet = false;
    private bool _IntroDone = false;
    private bool _Actionable = false;

    public CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }
    public CharacterMeleeAttack CharacterMeleeAttack { get => _CharacterMeleeAttack; set => _CharacterMeleeAttack = value; }
    public CharacterAttack CharacterAttack { get => _CharacterAttack; set => _CharacterAttack = value; }
    public Character Character { get => _Character; set => _Character = value; }
    public CharacterHealth CharacterHealth { get => _CharacterHealth; set => _CharacterHealth = value; }
    public AIState RemainInState { get => _RemainInState; set => _RemainInState = value; }

    public Transform Target { get => _Target; set => _Target = value; }
    public GameObject GameObject {get => _GameObject; set => _GameObject = value;}
    
    public bool TargetSet { get => _TargetSet; set => _TargetSet = value; }
    public bool IntroDone { get => _IntroDone; set => _IntroDone = value; }
    public bool Actionable { get => _Actionable; set => _Actionable = value; }

    // Sensors
    private MeleeSensor _MeleeSensor;
    public MeleeSensor MeleeSensor { get => _MeleeSensor; set => _MeleeSensor = value; }

    private void Awake()
    {
        // High level
        Actionable = true;

        // Classic sets
        _CharacterMovement = GetComponent<CharacterMovement>();
        _CharacterHealth = GetComponent<CharacterHealth>();
        _CharacterAttack = GetComponent<CharacterAttack>();
        _Character = GetComponent<Character>();
        _CharacterMeleeAttack = GetComponent<CharacterMeleeAttack>();

        // Sensors
        _MeleeSensor = GetComponentInChildren<MeleeSensor>();

        // Lower priority
        _GameObject = gameObject;
        _CurrentMacroState = _StartingState;
    }

    private void Update()
    {
        if(!HandleStates()) return;
        if (Actionable) {
            _CurrentMacroState.EvaluateState(this);
            if(_FollowPlayerMovement) FollowPlayerMovement();
        }
    }

    private void FixedUpdate() {
        if(Target == null) DetectIfPlayerHasEnteredAggroRange();
    }

    private bool HandleStates(){
        if(_CurrentMacroState == null) return false;
        // Handle Current Mirco Action
        return true;
    }

    public void TransitionToState(AIState nextState = null)
    {   
        if(!Character.IsAlive) _CurrentMacroState = _DeathState;
        else if (nextState != _RemainInState && nextState != null) _CurrentMacroState = nextState;
    }

    private void DetectIfPlayerHasEnteredAggroRange()
    {
        _TargetCollider = Physics2D.OverlapCircle(transform.position, _DetectArea, _TargetMask);
        if (_TargetCollider == null) return;
        Target = _TargetCollider.transform;
        TargetSet = true;
    }

    private void FollowPlayerMovement(){
        if(Target == null) return;
        if((Target.transform.position.x - transform.position.x) > 0 && !CharacterMovement.FacingRight) CharacterMovement.Flip();
        else if((Target.transform.position.x - transform.position.x) < 0 && CharacterMovement.FacingRight) CharacterMovement.Flip();
    }
}
