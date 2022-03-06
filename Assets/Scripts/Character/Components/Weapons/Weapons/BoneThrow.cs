using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneThrow : Weapon
{   

    protected override void UseWeapon()
    {
        base.UseWeapon();
        SpawnProjectile();
    }

    private void SpawnProjectile(){
        GameObject pooledProjectile = _ObjectPooler.GetGameObjectFromPool();

        pooledProjectile.transform.position = _ProjectileSpawnPosition.position;
        pooledProjectile.SetActive(true);

        // NewDirection should be towards the mouse cursor position
        Vector2 newDirection = _WeaponOwner.MouseCursor.GetClampedDirectionofMouse();

        Projectile projectile = pooledProjectile.GetComponent<Projectile>();
        projectile.SetDirection(newDirection, transform.rotation, true);
    }
}
