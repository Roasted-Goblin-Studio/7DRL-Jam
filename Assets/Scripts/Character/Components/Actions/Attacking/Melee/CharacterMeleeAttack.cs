using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeleeAttack : CharacterComponent
{
    [SerializeField] private Transform _AttackPoint;
    [SerializeField] private float _AttackRange = 0.5f;
    [SerializeField] private float _AttackCooldown = 0.5f;
    [SerializeField] private float _AttackStartup = 0f;
    [SerializeField] private float _AttackTime = 0.5f;
    [SerializeField] private int _AttackDamage = 1;
    [SerializeField] private LayerMask _EnemyLayers;
    [SerializeField] private string _TargetTag;

    private float _TimeUntilCharacterCanAttack = 0f;
    private float _FirstAttackFrameTime = 0f;
    private float _LastAttackFrameTime = 0f;

    protected override void Start()
    {
        base.Start();
        _Animator = GetComponentInChildren<Animator>();
    }

    private bool CheckIfAttacking()
    {
        return (Time.time >= _FirstAttackFrameTime && Time.time <= _LastAttackFrameTime);
    }

    protected override void HandlePlayerInput()
    {
        if (!_AttackPoint) return;
        if (Input.GetMouseButtonDown(_Character.CharacterInput.MouseSecondaryKeyCode)) Attack();
    }

    public void Attack()
    {
        if(Time.time < _TimeUntilCharacterCanAttack) return;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_AttackPoint.position, _AttackRange, _EnemyLayers);
        _FirstAttackFrameTime = Time.time + _AttackStartup;
        _LastAttackFrameTime = Time.time + _AttackStartup + _AttackTime;
        _TimeUntilCharacterCanAttack = Time.time + _AttackCooldown;
        if (_Animator) _Animator.SetTrigger("meleeAttack");

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag != _TargetTag) return;
            var enemyHP = enemy.GetComponentInParent<Health>();
            if (enemyHP) enemyHP.Damage(_AttackDamage);
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
        return (Input.GetMouseButtonDown(_Character.CharacterInput.MouseSecondaryKeyCode));
    }
}
