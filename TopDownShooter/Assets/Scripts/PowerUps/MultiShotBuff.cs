using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Multi Shot")]
public class MultiShotBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<WeaponHandler>().getCurrentWeapon().multishot += amount;
    }
}
