using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class snowballBehavior : IWeaponBehavior
{
    public override void Shoot(Weapon weapon)
    {
        GameObject bullet_tmp = weapon.projectileInfo.createProjectile(transform.position + transform.forward + transform.up, Quaternion.identity);
        Rigidbody rb_bullet = bullet_tmp.GetComponent<Rigidbody>();
        rb_bullet.velocity = transform.forward * weapon.projectileSpeed;
    }
}
