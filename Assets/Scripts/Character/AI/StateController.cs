using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Brain of the AI
    [Header("State")]
    [SerializeField] private AIState _CurrentState;
    [SerializeField] private AIState _RemainInState;
    [SerializeField] private float _DetectArea = 3f;
    [SerializeField] private LayerMask _TargetMask;

    private CharacterMovement _CharacterMovement { get; set; }
    private CharacterAttack _CharacterAttack { get; set; }
    private Character _Character { get; set; }
    private CharacterHealth _CharacterHealth {get; set;}

    private Transform _Target;
    private Collider2D _Collider2D { get; set; }
    private Collider2D _TargetCollider { get; set; }
    private GameObject _GameObject {get; set;}

    private bool _TargetSet = false;
    private bool _IntroDone = false;
    private bool _Actionable = false;

    // public Path _Path { get; set; }
    // public Paths _Paths { get; set; }

    public CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }
    public CharacterAttack CharacterAttack { get => _CharacterAttack; set => _CharacterAttack = value; }
    public Character Character { get => _Character; set => _Character = value; }
    public CharacterHealth CharacterHealth { get => _CharacterHealth; set => _CharacterHealth = value; }
    
    public Transform Target { get => _Target; set => _Target = value; }
    public Collider2D Collider2D { get => _Collider2D; set => _Collider2D = value; }
    public GameObject GameObject {get => _GameObject; set => _GameObject = value;}
    
    public bool TargetSet { get => _TargetSet; set => _TargetSet = value; }
    public bool IntroDone { get => _IntroDone; set => _IntroDone = value; }
    public bool Actionable { get => _Actionable; set => _Actionable = value; }

    private void Awake()
    {
        Actionable = true;
        _CharacterMovement = GetComponent<CharacterMovement>();
        _CharacterHealth = GetComponent<CharacterHealth>();
        _CharacterAttack = GetComponent<CharacterAttack>();
        _Character = GetComponent<Character>();
        _Collider2D = GetComponent<Collider2D>();
        _GameObject = gameObject;
    }

    private void Update()
    {
        if(_CurrentState == null) return;
        DetectIfPlayerHasEnteredAggroRange();
        if (Actionable)
        {
            _CurrentState.EvaluateState(this);
        }
    }

    public void TransitionToState(AIState nextState)
    {
        if (nextState != _RemainInState)
        {
            _CurrentState = nextState;
        }
    }

    private void DetectIfPlayerHasEnteredAggroRange()
    {
        _TargetCollider = Physics2D.OverlapCircle(transform.position, _DetectArea, _TargetMask);
        if (_TargetCollider == null) return;
        if (Target != null) return;
        if(_TargetCollider.tag != "HitBox") return;
        Target = _TargetCollider.transform;
        TargetSet = true;
    }
}
