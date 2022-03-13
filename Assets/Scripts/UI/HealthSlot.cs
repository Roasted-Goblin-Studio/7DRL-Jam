using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSlot : MonoBehaviour
{
    protected Animator animator;
    private IPanelComponent slotComponent;
    bool isFull = true;

    public void SetState(bool state)
    {
        isFull = state;
    }

    public virtual void OnDamage() 
    {
        animator.Play("Bone Damage");
    }

    public virtual void OnHeal()
    {
        animator.Play("Bone Heal");
    }

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (isFull)
        {
            animator.Play("Bone Static");
        } else
        {
            animator.Play("Bone Empty");
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
