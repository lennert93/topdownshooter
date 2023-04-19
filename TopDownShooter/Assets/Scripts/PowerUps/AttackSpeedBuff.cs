using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Attack Speed")]
public class AttackSpeedBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        Weapon weapon = target.GetComponent<WeaponHandler>().getCurrentWeapon();
        weapon.firerate -= amount;
        if(weapon.firerate < 0) weapon.firerate = 0;
    }
}
