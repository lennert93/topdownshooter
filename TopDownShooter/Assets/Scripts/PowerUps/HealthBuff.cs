using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Health")]
public class HealthBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        PlayerStats stat = target.GetComponent<PlayerStats>();
        stat.setHealth(stat.health + amount);
    }
}
