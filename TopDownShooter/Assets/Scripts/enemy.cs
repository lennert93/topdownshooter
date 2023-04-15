using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        //added
        lookingForPlayer();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
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

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    
    /* 15.04.: Idee:
     * Enemy schaut sich um (links oder rechts um seine eigene Achse).
     * Sobald er den Player sieht, läuft er auf ihn zu.
     * Hinzulaufen ist in moving() realisiert, weiß aber nicht ob es eine effizientere Möglichkeit gibt
     * 
    */
    
    public float enemySpeed;
    private void moving()
    {
        this.GetComponent<Rigidbody>().transform.position += getVectorToPlayerPosition() * enemySpeed * Time.fixedDeltaTime;

    }

    //berechnet Position Enemy - Position Spieler und gibt den umgekehrten Vector zurück
    private Vector3 getVectorToPlayerPosition()
    {
        Vector3 enemyPosition = this.GetComponent<Rigidbody>().transform.position;
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position; //changed Tag from player to "Player"
        // Debug.Log(playerPosition);
        Vector3 x = new Vector3(
            enemyPosition.x - playerPosition.x,
            0,
            enemyPosition.z - playerPosition.z);
        return -x;
    }

    private Vector3 RotationVector = new Vector3(0f, 1f, 0f);
    private float rotationSpeed = 0.2f;

    //umschauen, bei Sichtkontakt moving
    private void lookingForPlayer()
    {
        this.GetComponent<Rigidbody>().transform.Rotate(RotationVector * rotationSpeed, Space.World);
        if (seePlayer())
        {
            moving();
            //facing
        }
    }

    //
    private Boolean seePlayer()
    {
        return true;
    }
}
