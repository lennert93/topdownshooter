using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "bullet")
        {
            Debug.Log("test");
            bulletinfo info = other.GetComponent<bulletinfo>();

            //leben reduzieren
            reduceHealth(info.gunpower);
            Destroy(other.gameObject);
        }
    }

    private void reduceHealth(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
