using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallRangedWeapon : Weapon
{
    private int _Damage = 1;

    protected override void UseWeaponWithTarget(Transform targetPosition)
    {
        base.UseWeaponWithTarget(targetPosition);
        SpawnProjectile(targetPosition);
    }

    private GameObject SpawnProjectile(Transform targetPosition){
        GameObject pooledProjectile = _ObjectPooler.GetGameObjectFromPool();

        pooledProjectile.transform.position = _ProjectileSpawnPosition.position;
        pooledProjectile.SetActive(true);

        // NewDirection should be towards the player
        Vector2 newDirection = (targetPosition.position - _WeaponOwner.transform.position);
        newDirection.x = Mathf.Clamp(newDirection.x, -1, 1);
        newDirection.y = Mathf.Clamp(newDirection.y, -1, 1);
        
        Projectile projectile = pooledProjectile.GetComponent<Projectile>();
        projectile.SetDirection(newDirection, transform.rotation, true);

        return pooledProjectile;
    }
}
