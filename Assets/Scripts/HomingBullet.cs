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


    bool isRight;
    
    void Start()
    {
        speed = 6f; //adjust later
        //speedVector = new Vector3(speed, 0, 0);

        if(Random.Range(0,2) == 1)
        {
            isRight = true;
        }
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        //this gives the bullet more of an arc rather than it flying straight towards the player
        if(isRight)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
        }
        

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
