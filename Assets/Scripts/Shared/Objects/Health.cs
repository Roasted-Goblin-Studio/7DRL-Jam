using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Private

    // Protected
    protected Animator _Animator;
    protected float _OriginalMaxHealth;

    // Serialized
    // [SerializeField] protected Slider _HealthIndicatorBar;  // Put the slider object here
    [SerializeField] protected float _CurrentHealth;
    [SerializeField] protected float _MaxHealth;

    // Public
    public float CurrentHealth => _CurrentHealth; //READONLY

    // Start is called before the first frame update
    protected virtual void Start()
    {  
        _Animator = GetComponentInChildren<Animator>();
        _CurrentHealth = _MaxHealth;
        _OriginalMaxHealth = _MaxHealth;
    }

    // Health indicator controller
    public virtual void SetHealth(float Health)
    {
        _CurrentHealth = Health;
    }

    public virtual void IncreaseMaxHealth(float Amount){
        _MaxHealth += Amount;
    }

    public virtual void IncreaseMaxHealthAndHeal(float Amount){
        _MaxHealth += Amount;
        _CurrentHealth += Amount;
    }

    public virtual void Heal(float amount){
        float newHealth = _CurrentHealth + amount;

        if (newHealth > _MaxHealth)
        {
            _CurrentHealth = _MaxHealth;
        }
        else
        {
            _CurrentHealth += amount;
        }
    }

    public virtual void Damage(float amount){

        if (_CurrentHealth <= 0) return;

        float newHealth = _CurrentHealth - amount;

        if (newHealth <= 0)
        {
            _CurrentHealth = 0;
            Die();
        }
        else
        {
            _CurrentHealth -= amount;
        }
    }

    public virtual void Die(){ }

    // Add DoT
}
