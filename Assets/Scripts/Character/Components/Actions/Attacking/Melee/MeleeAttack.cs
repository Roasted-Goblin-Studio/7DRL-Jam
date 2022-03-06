using System.Collections;
using UnityEngine;

public class MeleeAttack : CharacterComponent 
{
    [SerializeField] private Transform _AttackPoint;
    [SerializeField] private float _AttackRange = 0.5f;
    [SerializeField] private LayerMask _EnemyLayers;
    [SerializeField] private float _AttackTime = 0.2f;

    private float _TimeUntilCharacterCanAttack = 0f;
    private float _TimeSinceLastAttack = 0f;
    private float _AttackCooldown = 0.5f;

    private Animator _Animator;


    protected override void Start()
    {
        base.Start();

        _Animator = GetComponent<Animator>();
    }

    protected override void HandleBasicComponentFunction()
    {
        _TimeSinceLastAttack += Time.deltaTime;
    }

    protected override bool HandlePlayerInput()
    {
        if (!base.HandlePlayerInput()) return false;

        if (DecideIfCharacterCanAttack()) Attack();

        return true;
    }

    protected override bool HandleAIInput()
    {
        return base.HandleAIInput();

    }

    private void Attack()
    {
        _TimeSinceLastAttack = 0f;
        // attacking

        _TimeUntilCharacterCanAttack = Time.time + _AttackTime;

        if (_Animator)
        {
            _Animator.SetTrigger("attack");
        }

        if (!_AttackPoint) return;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_AttackPoint.position, _AttackRange, _EnemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (!_AttackPoint) return;

        Gizmos.DrawWireSphere(_AttackPoint.position, _AttackRange);
    }

    private bool DecideIfCharacterCanAttack()
    {
        return AttackInput() && Time.time >= _TimeUntilCharacterCanAttack;
    }

    private bool AttackInput()
    {
        // TODO: remap to "character inputs" once ready
        return (Input.GetKeyDown(KeyCode.Space));
    }
}
