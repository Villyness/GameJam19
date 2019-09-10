﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : MonoBehaviour
{
    public float speed;

    public int health;

    private void Start()
    {
        health = 100;
    }

    void Update()
    {
        // Clamping the position to within the play boundaries.
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp( currentPosition.x, -6, 6);
        transform.position = currentPosition;
        
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;


        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}