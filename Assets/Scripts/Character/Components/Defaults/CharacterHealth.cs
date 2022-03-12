using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Health
{
    private Character _Character;

    protected override void Start(){
        base.Start();
        _Character = GetComponent<Character>();
        _Character.IsAlive = true;
        _Character.IsHitable = true;
    }

    public override void Damage(float amount, bool playHurtAnim = true)
    {
        if(_Character && !_Character.IsHitable) return;
        base.Damage(amount, playHurtAnim);
    }

    public override void Die()
    {
        base.Die();

        if (_Character) _Character.IsAlive = false;

        if (_Animator) _Animator.SetTrigger("die");
    }
}
