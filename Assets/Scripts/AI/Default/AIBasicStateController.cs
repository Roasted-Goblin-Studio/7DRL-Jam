using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicStateController : BaseStateController
{
    /*Notes
        - The BaseStateController macro option will be used for movement.     
        - New State added; Death State
    */
    
    [Header("DeathState")]
    [SerializeField] protected BaseState _DeathState;

    // SAVE FOR LATER
    [Header("Target Detection")]
    [SerializeField] protected float _DetectArea = 1f;
    [SerializeField] protected LayerMask _TargetMask;
    protected Transform _Target;
    protected Collider2D _TargetCollider;
    protected GameObject _TargetGameObject;


    [Header("Character Components")]
    protected CharacterMovement _CharacterMovement;
    protected Character _Character;
    protected CharacterHealth _CharacterHealth;


    [Header("AI State Flags")]
    protected bool _TargetSet = false;

    // #~#~# PUBLIC #~#~#
    public CharacterMovement CharacterMovement { get => _CharacterMovement; set => _CharacterMovement = value; }
    public Character Character { get => _Character; set => _Character = value; }
    public CharacterHealth CharacterHealth { get => _CharacterHealth; set => _CharacterHealth = value; }
   
    public BaseState RemainInState { get => _RemainInState; set => _RemainInState = value; }
    
    public Transform Target { get => _Target; set => _Target = value; }
    public GameObject TagetGameObject { get => _TargetGameObject; set => _TargetGameObject = value; }

    public bool TargetSet { get => _TargetSet; set => _TargetSet = value; }


    protected override void HandleAwakeTasks()
    {
        _CharacterMovement = GetComponent<CharacterMovement>();
        _CharacterHealth = GetComponent<CharacterHealth>();
        _Character = GetComponent<Character>();
    }

    protected override void HandleLowPriorityTasks()
    {
        base.HandleLowPriorityTasks();
        DetectIfPlayerHasEnteredAggroRange();
        FollowPlayerMovementWithFlip();
    }

    protected void DetectIfPlayerHasEnteredAggroRange()
    {
        _TargetCollider = Physics2D.OverlapCircle(transform.position, _DetectArea, _TargetMask);
        if (_TargetCollider == null) return;
        Target = _TargetCollider.transform;
        TargetSet = true;
    }

    protected void FollowPlayerMovementWithFlip(){
        if(Target == null) return;
        if((Target.transform.position.x - transform.position.x) > 0 && !CharacterMovement.FacingRight) CharacterMovement.Flip();
        else if((Target.transform.position.x - transform.position.x) < 0 && CharacterMovement.FacingRight) CharacterMovement.Flip();
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.transform.position, _DetectArea);
    }
}
