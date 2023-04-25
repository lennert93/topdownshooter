using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    public GameObject model;
    public bool autoDestroy = true;
    public float baseDamage = 50;
    public float elementaryDamage = 0;
    public bool canBounce = false;

    public float getDamage()
    {
        return baseDamage + elementaryDamage;
    }

    public GameObject createProjectile(Vector3 pos, Quaternion rot)
    {
        GameObject obj = Instantiate(model, pos, rot);
        obj.GetComponent<projectile>().info = this;
        return obj;
    }
}
