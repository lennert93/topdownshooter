using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultWeapon : Weapon
{
    public override IEnumerator animateShot()
    {
        animator.SetBool("throwing", true);
        yield return new WaitForSeconds(firerate);
        animator.SetBool("throwing", false);
    }
}
