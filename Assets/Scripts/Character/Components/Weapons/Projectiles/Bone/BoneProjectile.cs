using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneProjectile : Projectile
{
    [SerializeField] GameObject _Skull; 
    
    override protected void MoveProjectile(){
        _ProjectileMovement = Direction * _Speed * Time.deltaTime;
        _ProjectileRigidBody2D.MovePosition(_ProjectileRigidBody2D.position + _ProjectileMovement);
    }

    protected override void DestroyProjectile()
    {
        if (ProjectileType == ProjectileTypes.Skull)
        {
            if (_Skull) Instantiate(_Skull, gameObject.transform.position, Quaternion.identity);
        }
        base.DestroyProjectile();
    }
}
