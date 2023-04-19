using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeBehavior : IWeaponBehavior
{
    public override void Shoot(Weapon weapon)
    {
        GameObject bullet_tmp = Instantiate(weapon.projectile.gameObject, transform.position + transform.forward + transform.up, Quaternion.identity);
        Rigidbody rb_bullet = bullet_tmp.GetComponent<Rigidbody>();
        rb_bullet.useGravity = true;
        rb_bullet.velocity = (transform.forward + transform.up) * weapon.projectileSpeed / 2;
    }
}
