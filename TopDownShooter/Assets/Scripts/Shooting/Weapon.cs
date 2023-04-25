using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public IWeaponBehavior behavior; //implements the shooting
    public bool isAutomatic = false; //if the Weapon shoots on its own
    public ProjectileInfo projectileInfo; //The Projectile this weapon shoots
    public float firerate = 0.5f; //shots per second
    public float projectileSpeed = 20f; //how fast the projectile travels
    public float scattershot = 0; //shoot multiple projectiles at once
    public float multishot = 0; //shoot multiple projectiles directly after each other

    private bool shootIsOnCooldown = false;
    public Animator animator;
    public virtual void Start()
    {
        behavior = gameObject.GetComponent<IWeaponBehavior>();
        animator = transform.parent.GetComponent<Animator>();
        projectileInfo = gameObject.GetComponent<ProjectileInfo>();
    }

    public virtual void Shoot()
    {
        if (shootIsOnCooldown) return;
        
        StartCoroutine(Multishot());
    }

    private IEnumerator Multishot()
    {
        shootIsOnCooldown = true;
        for (int i = 0; i <= multishot; i++)
        {
            shootEvent();
            behavior.Shoot(this);
            if (i != multishot)
            {
                yield return new WaitForSeconds(firerate / 4);
                shootEvent();
                yield return new WaitForSeconds(firerate / 4);
            }
        }
        yield return new WaitForSeconds(firerate);
        shootEvent();
        shootIsOnCooldown = false;
    }

    /// <summary>
    /// feuert wenn entweder angefangen wird oder aufgehört wird zu schießen
    /// </summary>
    public abstract void shootEvent();
}
