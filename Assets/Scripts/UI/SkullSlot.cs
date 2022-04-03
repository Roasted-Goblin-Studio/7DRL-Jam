using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSlot : HealthSlot
{
    private int currentHealth = 0;
    private int maxHealth = 0;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        if (animator.GetInteger("Health") != currentHealth)
        {
            animator.SetInteger("Health", currentHealth);
        }
    }

    public override void OnHeal()
    {
    }

    public override void OnDamage()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
