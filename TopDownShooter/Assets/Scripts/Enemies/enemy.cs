using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float health;
    public Slider healthbar;
    public int range;
    private Animator anim;
    public float damage = 50;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = health;
        healthbar.minValue = 0;
        healthbar.value = health;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //added
        lookingForPlayer();
        healthbar.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            ProjectileInfo info = collision.gameObject.GetComponent<ProjectileInfo>();

            //leben reduzieren
            reduceHealth(info.getDamage());
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collided = true;
            PlayerStats stat = collision.gameObject.GetComponent<PlayerStats>();
            stat.setHealth(stat.health - damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = false;
        }
    }

    private void reduceHealth(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        healthbar.value = health;
    }

    
    /* 15.04.: Idee:
     * Enemy schaut sich um (links oder rechts um seine eigene Achse).
     * Sobald er den Player sieht, l�uft er auf ihn zu.
     * Hinzulaufen ist in moving() realisiert, wei� aber nicht ob es eine effizientere M�glichkeit gibt
     * 
    */
    
    public float enemySpeed;
    private void moving()
    {
        if (collided) return;
        this.GetComponent<Rigidbody>().transform.position += getVectorToPlayerPosition().normalized * enemySpeed * Time.fixedDeltaTime;
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", true);
        Debug.Log("walking");
    }

    /// <summary>
    /// berechnet Position Enemy - Position Spieler und gibt den umgekehrten Vector zur�ck
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// umschauen, bei Sichtkontakt moving
    /// </summary>
    private void lookingForPlayer()
    {
        if (Math.Abs(getVectorToPlayerPosition().x) < range && Math.Abs(getVectorToPlayerPosition().z) < range) //Beispielwerte, m�ssen gr��er als Kamerasichtweite sein
        {
            moving();
            facingPlayer();
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            Debug.Log("idle");
        }

        //this.GetComponent<Rigidbody>().transform.Rotate(RotationVector * rotationSpeed, Space.World);
        //if (seePlayer())
        //{
        // moving();
        // //facing
        //}
    }

    private void facingPlayer(){
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));

    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Boolean seePlayer()
    {
        return true;
    }
}
