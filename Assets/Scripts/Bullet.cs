using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // This is the script for the bullets fired by the ships
    // Setting up...
    public float speed;
    private Vector3 speedVector;
    public float expiryTimer;
    private float timer;
    public GameObject selfObj;

    void Start()
    {
        speedVector = new Vector3(speed, 0, 0);
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = speedVector;
        timer += Time.deltaTime;
        if((int)timer == (int)expiryTimer)
            DestroySelf();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(selfObj);
    }
}
