using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Brain of the AI
    [Header("State")]
    [SerializeField] private AIState CurrentState;
    [SerializeField] private AIState RemainInState;

    private CharacterMovement _CharacterMovement { get; set; }
    private CharacterAttack _CharacterAttack { get; set; }
    private Character _Character { get; set; }
    private CharacterHealth _CharacterHealth {get; set;}

    private Transform _Target { get; set; }
    private Collider2D _Collider2D { get; set; }
    private GameObject _GameObject {get; set;}

    private bool _TargetSet = false;
    private bool _IntroDone = false;
    private bool _Actionable = false;

    // public Path _Path { get; set; }
    // public Paths _Paths { get; set; }

    private CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }
    private CharacterAttack CharacterAttack { get => _CharacterAttack; set => _CharacterAttack = value; }
    private Character Character { get => _Character; set => _Character = value; }
    private CharacterHealth CharacterHealth { get => _CharacterHealth; set => _CharacterHealth = value; }
    
    private Transform Target { get => _Target; set => _Target = value; }
    private Collider2D Collider2D { get => _Collider2D; set => _Collider2D = value; }
    private GameObject GameObject {get => _GameObject; set => _GameObject = value;}
    
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
        if (Actionable)
        {
            CurrentState.EvaluateState(this);
        }
    }

    public void TransitionToState(AIState nextState)
    {
        if (nextState != RemainInState)
        {
            CurrentState = nextState;
        }
    }
}
