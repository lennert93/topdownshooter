using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Scatter Shot")]
public class ScatterShotBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<WeaponHandler>().getCurrentWeapon().scattershot += amount;
    }
}
