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
    public MixMaster MahSoundBoi;

    void Start()
    {
        GameObject jamintern = GameObject.Find("MasterOfJams");
        MahSoundBoi = jamintern.GetComponent<MixMaster>();

        //speedVector = new Vector3(0, -speed, 0);
    }
    void Update()
    {
        //GetComponent<Rigidbody>().velocity = speedVector;

        /*
        timer += Time.deltaTime;
        if((int)timer == (int)expiryTimer)
            DestroySelf();*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //DestroySelf();

        //give the Pilot a pilot tag so the pilot will be hurt by bullets
        if(other.tag == "Pilot")
        {
            //set pilot's health to -10
            //right now the Pilot is controlled by QueenController, change this as necessary.
            other.GetComponent<QueenController>().health -= 10;
            MahSoundBoi.BulletHitShip();
            //destroy itself
            

            Destroy(gameObject);
        }
    }

    public void DestroySelf()
    {
        Destroy(selfObj);
    }
}
