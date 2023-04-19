using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Attack Damage")]
public class AttackDamageBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        Weapon weapon = target.GetComponent<WeaponHandler>().getCurrentWeapon();
        weapon.projectile.baseDamage += amount;
    }
}
