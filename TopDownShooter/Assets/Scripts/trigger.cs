using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public delegate void bossfight();
    public static event bossfight bossevent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            bossevent.Invoke();
    }
}
