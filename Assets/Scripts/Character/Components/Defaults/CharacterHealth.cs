using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Health
{
    private Character _Character;

    // Events
    public delegate void OnDamage(int amount);
    public static event OnDamage onDamage;

    public delegate void OnHeal(int amount);
    public static event OnHeal onHeal;

    public delegate void OnMaxHealthIncrease(int amount, bool heal);
    public static event OnMaxHealthIncrease onMaxHealthIncrease;

    public delegate void OnDeath();
    public static event OnDeath onDeath;
    // ******* //

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
        onDamage?.Invoke((int) amount);
    }

    public override void IncreaseMaxHealth(float amount)
    {
        base.IncreaseMaxHealth(amount);
        onMaxHealthIncrease?.Invoke((int) amount, false);
    }

    public override void IncreaseMaxHealthAndHeal(float amount)
    {
        base.IncreaseMaxHealth(amount);
        onMaxHealthIncrease?.Invoke((int) amount, true);
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
        onHeal?.Invoke((int) amount);
    }

    public override void Die()
    {
        base.Die();
        onDeath?.Invoke();

        _CurrentHealth = 0;
        if (_Character) _Character.IsAlive = false;
        if (_Animator) _Animator.SetTrigger("die");
    }
}
