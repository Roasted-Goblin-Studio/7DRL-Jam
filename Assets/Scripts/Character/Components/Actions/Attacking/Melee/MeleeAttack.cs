using System;
using System.Collections;
using UnityEngine;

public class MeleeAttack : CharacterComponent 
{
    [SerializeField] private Transform _AttackPoint;
    [SerializeField] private float _AttackRange = 0.5f;
    [SerializeField] private float _AttackCooldown = 0.5f;
    [SerializeField] private float _AttackStartup = 0f;
    [SerializeField] private float _AttackTime = 0.5f;
    [SerializeField] private int _AttackDamage = 1;
    [SerializeField] private LayerMask _EnemyLayers;

    private Animator _Animator;
    private float _TimeUntilCharacterCanAttack = 0f;
    private float _FirstAttackFrameTime = 0f;
    private float _LastAttackFrameTime = 0f;

    protected override void Start()
    {
        base.Start();

        _Animator = GetComponentInChildren<Animator>();
    }

    protected override void HandleBasicComponentFunction()
    {
        base.HandleBasicComponentFunction();

        if (CheckIfAttacking())
        {
            if (!_AttackPoint) return;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_AttackPoint.position, _AttackRange, _EnemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag != "HitBox") break;
                _LastAttackFrameTime = Time.deltaTime;

                var enemyHP = enemy.GetComponentInParent<Health>();

                if (enemyHP)
                {
                    enemyHP.Damage(_AttackDamage);
                }
                else
                {
                    Debug.LogError("No Health Component found on Enemy");
                }
            }
        }
    }

    private bool CheckIfAttacking()
    {
        return (Time.time >= _FirstAttackFrameTime && Time.time <= _LastAttackFrameTime);
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
        _TimeUntilCharacterCanAttack = Time.time + _AttackCooldown;
        _FirstAttackFrameTime = Time.time + _AttackStartup;
        _LastAttackFrameTime = Time.time + _AttackStartup + _AttackTime;

        if (_Animator)
        {
            _Animator.SetTrigger("meleeAttack");
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
