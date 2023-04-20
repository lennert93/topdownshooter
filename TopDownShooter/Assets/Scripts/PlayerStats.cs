using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider healthbar;
    public float health = 100;
    public float shield = 0;

    private void Start() {
        healthbar.maxValue = health;
        healthbar.minValue = 0;
        healthbar.value = health;
    }

    public void setHealth(float value)
    {
        health = value;
        if(value > healthbar.maxValue) 
            healthbar.maxValue = value;
        healthbar.value = health;
    }
}
