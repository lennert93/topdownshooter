using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public IWeaponBehavior behavior; //implements the shooting
    public bool isAutomatic = false; //if the Weapon shoots on its own
    public ProjectileInfo projectile; //The Projectile this weapon shoots
    public float firerate = 0.5f; //shots per second
    public float projectileSpeed = 1000f; //how fast the projectile travels
    public float scattershot = 0; //shoot multiple projectiles at once
    public float multishot = 0; //shoot multiple projectiles directly after each other

    private bool shootIsOnCooldown = false;
    public Animator animator;
    public virtual void Start()
    {
        behavior = gameObject.GetComponent<IWeaponBehavior>();
        animator = transform.parent.GetComponent<Animator>();
    }

    public virtual void Shoot()
    {
        if (shootIsOnCooldown) return;
        
        behavior.Shoot(this);
        StartCoroutine(waitForShootCooldown());
        StartCoroutine(animateShot());
    }
    public IEnumerator waitForShootCooldown()
    {
        shootIsOnCooldown = true;
        yield return new WaitForSeconds(firerate);
        shootIsOnCooldown = false;
    }
    public abstract IEnumerator animateShot();
}
