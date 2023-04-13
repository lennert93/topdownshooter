using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class topDownController : MonoBehaviour
{
    public float health = 100;
    private Camera camera;
    private Rigidbody rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dashSpeed = 3f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float shootCooldown = 0.1f;
    [SerializeField] private float shootSpeed = 1000f;

    private bool dashingAvailable = true;
    private bool shootingAvailable = true;
    Vector3 movement = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //make camera follow
        camera.transform.position = transform.position + new Vector3(0, 10, -10);

        //save keyboard input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        lookAtMouse();
        if (Input.GetKeyDown(KeyCode.Space) && dashingAvailable)
        {
            StartCoroutine(dash());
        }
        if(Input.GetMouseButton(0) && shootingAvailable)
        {
            Debug.Log("shoot");
            shoot();
        }
    }

    private void FixedUpdate()
    {
        //move character
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void lookAtMouse()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layer_mask = LayerMask.GetMask("Terrain");
        if (Physics.Raycast(ray, out hit, 100f, layer_mask))
        {
            Debug.DrawRay(ray.GetPoint(0), ray.direction * 100);
            transform.LookAt(hit.point + new Vector3(0, transform.position.y, 0));
        }
    }

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

    private IEnumerator waitForDashCooldown()
    {
        
        dashingAvailable = false;
        yield return new WaitForSeconds(dashCooldown);
        dashingAvailable = true;
    }

    private void shoot()
    {
        StartCoroutine(waitForShootCooldown());
        GameObject bullet_tmp = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb_bullet = bullet_tmp.GetComponent<Rigidbody>();
        rb_bullet.AddForce(transform.forward * shootSpeed);
    }
    private IEnumerator waitForShootCooldown()
    {
        
        shootingAvailable = false;
        yield return new WaitForSeconds(shootCooldown);
        shootingAvailable = true;
    }

}
