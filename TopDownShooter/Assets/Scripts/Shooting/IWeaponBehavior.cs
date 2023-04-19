using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeaponBehavior : MonoBehaviour
{
    public abstract void Shoot(Weapon weapon);
}
