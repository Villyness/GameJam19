using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    // This is the script for the bullets fired by the ships
    // Setting up...
    public float speed;
    //private Vector3 speedVector;
    public float expiryTimer;
    private float timer;
    public GameObject selfObj;
    public GameObject target;
    
    void Start()
    {
        speed = 3f; //adjust later
        //speedVector = new Vector3(speed, 0, 0);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        /*timer += Time.deltaTime;
        if((int)timer == (int)expiryTimer)
            DestroySelf();*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //DestroySelf();

        //give the Pilot a pilot tag so the pilot will be hurt by bullets
        if (other.tag == "Pilot")
        {
            //set pilot's health to -10
            //right now the Pilot is controlled by QueenController, change this as necessary.
            other.GetComponent<QueenController>().health -= 10;
            //destroy itself


            Destroy(gameObject);
        }
    }

    public void DestroySelf()
    {
        //Destroy(selfObj);
    }
}
