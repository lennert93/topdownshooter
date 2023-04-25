using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public ProjectileInfo info;
    private void OnCollisionEnter(Collision collision)
    {
        if (info.autoDestroy && collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
