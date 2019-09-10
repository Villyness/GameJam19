using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : MonoBehaviour
{
    public float speed;
    public int health;

    float shootDelay;
    float shootTimer;

    public GameObject bulletPrefab;

    private void Start()
    {
        health = 100;
        shootDelay = 2;
        shootTimer = 0;
    }

    void Update()
    {
        // Clamping the position to within the play boundaries.
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp( currentPosition.x, -6, 6);
        transform.position = currentPosition;
        
        var move = new Vector3(Input.GetAxisRaw("P2 Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;


        shootTimer -= Time.deltaTime;
        if (Input.GetButton("P2 Fire") && shootTimer < 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Destroy(bullet, 5);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 10, 0) * 50);


            shootTimer = shootDelay;
        }



        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}