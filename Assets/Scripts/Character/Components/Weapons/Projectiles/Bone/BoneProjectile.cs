using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneProjectile : Projectile
{
    override protected void MoveProjectile(){
        _ProjectileMovement = Direction * _Speed * Time.deltaTime;
        _ProjectileRigidBody2D.MovePosition(_ProjectileRigidBody2D.position + _ProjectileMovement);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"){
            CharacterHealth characterHealth = other.GetComponent<CharacterHealth>();
            characterHealth.Damage(_ProjectileDamage);
            _ReturnObjectToPool.DestroyObject();
        }
        
        foreach (var tag in _TagsToAvoid.TagsToAvoidStrings)
        {
            if(other.tag == tag){
                return;
            }
        }
        if(other.tag == "Non Hitable") {
            return;
        }

        _ReturnObjectToPool.DestroyObject();
    }
}
