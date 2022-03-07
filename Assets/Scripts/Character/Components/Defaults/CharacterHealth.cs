using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Health
{
    private Animator _Animator;

    protected override void Start(){
        base.Start();
        _Character = GetComponent<Character>();
        _Animator = GetComponentInChildren<Animator>();
    }

    public override void Die()
    {
        base.Die();

        if (!_Animator) return;

        _Animator.SetTrigger("die");
    }
}
