using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    public bool autoDestroy = true;
    public float baseDamage = 50;
    public float elementaryDamage = 0;
    public bool canBounce = false;

    public float getDamage()
    {
        return baseDamage + elementaryDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(autoDestroy) 
        {
            Destroy(gameObject);
        }
    }
}
