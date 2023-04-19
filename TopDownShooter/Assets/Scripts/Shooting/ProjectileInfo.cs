using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    public float autoDestory = 2f;
    public float baseDamage;
    public float elementaryDamage;
    public bool canBounce;

    public float getDamage()
    {
        return baseDamage + elementaryDamage;
    }

    private void Start()
    {
        Destroy(gameObject, autoDestory);
    }
}
