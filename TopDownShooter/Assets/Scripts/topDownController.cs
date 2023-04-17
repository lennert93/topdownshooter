using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class topDownController : MonoBehaviour
{
    private Camera cam;
    private Rigidbody rb;
    private Animator anim;

    public float health = 100;
    public GameObject bullet;
    public float moveSpeed = 5f;
    public float dashSpeed = 3f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;
    public float shootCooldown = 0.1f;
    public float shootSpeed = 1000f;

    private bool dashingAvailable = true;
    private bool shootingAvailable = true;
    Vector3 movement = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //make camera follow
        cam.transform.position = transform.position + new Vector3(0, 10, -10);

        //save keyboard input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        anim.SetFloat("vertical", Math.Abs(movement.z));
        anim.SetFloat("horizontal", Math.Abs(movement.x));

        lookAtMouse();
        if (Input.GetKeyDown(KeyCode.Space) && dashingAvailable)
        {
            StartCoroutine(dash());
        }
        if(Input.GetMouseButton(0) && shootingAvailable)
        {
            shoot();
        }
    }

    private void FixedUpdate()
    {
        //move character
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Macht, dass der Spieler immer in die Richtung des Mauszeigers schaut
    /// </summary>
    private void lookAtMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layer_mask = LayerMask.GetMask("Terrain");
        if (Physics.Raycast(ray, out hit, 100f, layer_mask))
        {
            Debug.DrawRay(ray.GetPoint(0), ray.direction * 100);
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    /// <summary>
    /// F�hrt einen Dash aus
    /// </summary>
    /// <returns></returns>
    private IEnumerator dash()
    {
        StartCoroutine(waitForDashCooldown());
        float timer = dashTime;
        float initalMoveSpeed = moveSpeed;
        moveSpeed *= dashSpeed;
        while(timer >= 0)
        {
            timer -= Time.smoothDeltaTime;
            yield return null;
        }
        moveSpeed = initalMoveSpeed;
    }

    /// <summary>
    /// Cooldown f�r den Dash
    /// </summary>
    /// <returns></returns>
    private IEnumerator waitForDashCooldown()
    {
        
        dashingAvailable = false;
        yield return new WaitForSeconds(dashCooldown);
        dashingAvailable = true;
    }

    /// <summary>
    /// Schie�t in Richtung des Mauszeigers
    /// </summary>
    private void shoot()
    {
        StartCoroutine(waitForShootCooldown());
        GameObject bullet_tmp = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb_bullet = bullet_tmp.GetComponent<Rigidbody>();
        rb_bullet.AddForce(transform.forward * shootSpeed);
    }
    /// <summary>
    /// Cooldown f�r das Schie�en (regelt also die Schussrate)
    /// </summary>
    /// <returns></returns>
    private IEnumerator waitForShootCooldown()
    {
        anim.SetBool("shooting", true);
        shootingAvailable = false;
        yield return new WaitForSeconds(shootCooldown);
        shootingAvailable = true;
        anim.SetBool("shooting", false);
    }

}
