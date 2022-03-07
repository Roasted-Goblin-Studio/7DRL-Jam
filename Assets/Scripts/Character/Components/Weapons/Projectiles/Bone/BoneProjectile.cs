using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneProjectile : Projectile
{
    override protected void MoveProjectile(){
        _ProjectileMovement = Direction * _Speed * Time.deltaTime;
        _ProjectileRigidBody2D.MovePosition(_ProjectileRigidBody2D.position + _ProjectileMovement);
    }
}
