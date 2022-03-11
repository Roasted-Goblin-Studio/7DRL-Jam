using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneThrow : Weapon
{
    private int _SelfDamage = 1;

    protected override void UseWeapon()
    {
        base.UseWeapon();
        var characterAnimator = _WeaponOwner.GetComponentInChildren<Animator>();
        var throwerHP = WeaponOwner.GetComponent<Health>();

        if (!characterAnimator || !throwerHP) return;

        if (throwerHP.CurrentHealth > 1)
        {
            throwerHP.Damage(_SelfDamage);
            characterAnimator.SetTrigger("rangedAttack");
            SpawnProjectile();
        }
        else
        {
            var head = SpawnProjectile();
            head.GetComponent<Animator>().SetBool("headSpin", true);
            characterAnimator.SetTrigger("headToss");
        }

    }

    private GameObject SpawnProjectile(){

        GameObject pooledProjectile = _ObjectPooler.GetGameObjectFromPool();

        pooledProjectile.transform.position = _ProjectileSpawnPosition.position;
        pooledProjectile.SetActive(true);

        // NewDirection should be towards the mouse cursor position
        Vector2 newDirection = _WeaponOwner.MouseCursor.GetClampedDirectionofMouse();

        Projectile projectile = pooledProjectile.GetComponent<Projectile>();
        projectile.SetDirection(newDirection, transform.rotation, true);

        return pooledProjectile;
    }
}
