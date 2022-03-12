using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : CharacterComponent
{
    [SerializeField] protected Transform _WeaponPosition;
    [SerializeField] private Weapon _PrimaryWeapon;

    public Transform WeaponPosition { get => _WeaponPosition; set => _WeaponPosition = value; }

    protected override void Start()
    {
        base.Start();
        _PrimaryWeapon = Instantiate(_PrimaryWeapon, WeaponPosition);
        _PrimaryWeapon.WeaponOwner = _Character;
    }

    protected override void HandlePlayerInput()
    {   
        if(!_Character.IsActionable) return;
        if(Input.GetMouseButtonDown(_Character.CharacterInput.MousePrimaryKeyCode)) _PrimaryWeapon.InitiateUseWeapon();
    }

    public void AIInitiateWeapon(Transform _TargetPosition){
        _PrimaryWeapon.AIInitiateUseWeapon(_TargetPosition);
    }

    public void AttackAnimation()
    {
        if (_Animator) _Animator.SetTrigger("rangedAttack");
    }
}
