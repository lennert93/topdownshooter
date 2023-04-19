using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultWeapon : Weapon
{
    public override void shootEvent()
    {
        animator.SetBool("throwing", !animator.GetBool("throwing"));
    }
}
