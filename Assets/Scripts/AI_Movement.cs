using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    // Ship Types
    public enum ShipType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }
    public ShipType shipType;

    // Place ShipDirection GameObjects here.
    public Transform[] path;
    
    private Vector3 moveDirection; // Unneeded now
    
    public float speed;

    // V's edit; mostly just stuff to do with the knight
    public float delayTime;
    private float counter;
    private Transform[] possibleTPs;

    public List<Transform> list;

    private bool switchCounter = false;

    public Collider ownCollider;

    public float delayCoef;

    public GameObject bulletPrefab;
    public GameObject homingBulletPrefab;
    public bool canShoot;
    public bool isHoming;

    public MixMaster MahSoundBoi;


    // Start is called before the first frame update
    void Start()
    {
        GameObject jamintern = GameObject.Find("MasterOfJams");
        MahSoundBoi = jamintern.GetComponent<MixMaster>();

        list = new List<Transform>();
        switch (shipType)
        {
            //possibleTPs = new Transform[GetComponentsInChildren<Transform>().Length];
            
            case ShipType.Knight:
                foreach (Transform point in GetComponentsInChildren<Transform>())
                {
                    list.Add(point);
                }

                break;
            case ShipType.Bishop:
                moveDirection = new Vector3(2, -speed, 0);
                break;
            case ShipType.Rook:
                moveDirection = Vector3.left;
                break;
        }

        InvokeRepeating("Shoot", 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");
        // Ships behave differently when reaching the play boundaries. 
        if (other.tag == "Boundary")
        {
            //Debug.Log("Hit)");
            switch (shipType)
            {
                case ShipType.Bishop:
                    // Invert x
                    moveDirection.x = -moveDirection.x;
                    break;
                case ShipType.Knight:
                    // Invert x
                    //moveDirection.x = -moveDirection.x;

                    break;
                case ShipType.Rook:
                    // store x, x = 0, y = -1 for a bit, then invert and use stored x
                    Debug.Log("Hit");
                    moveDirection = Vector3.down;
                    delayTime = counter + delayCoef;
                    if (switchCounter == true)
                    {
                        switchCounter = false;
                    }
                    else
                    {
                        switchCounter = true;
                    }
                    break;
            }
        }

        // Most ships must be destroyed here. The Bishop bounces off.
        if (other.tag == "Bottom")
        {
            switch(shipType)
            {
                case ShipType.Pawn:
                    // Destroy the Pawn. The next time a ship is spawned, spawn another clone directly behind it (Bonus Ship).
                    Destroy(gameObject);
                    break;
                    // TODO: Bonus Ship
                case ShipType.Bishop:
                moveDirection.y = -moveDirection.y;
                break;
            }
        }

        if(other.tag == "Pilot")
        {
            other.GetComponent<QueenController>().health -= 10;
            MahSoundBoi.ShipOnShip();

            Destroy(gameObject);
        }
        if (other.tag == "PilotBullet")
        {            
            GameObject g = GameObject.Find("Queen_Alt");

            g.GetComponent<QueenController>().enemiesRemaining -= 10;
            MahSoundBoi.ShipGotRekt();

            Destroy(gameObject);
        }
    }

    // Occurs when the player releases a ship from the top of the screen.
    // This is for setting the ships trajectory.
    void ShipRelease()
    {
        switch (shipType)
        {
            case ShipType.Bishop:
                // Moves diagonally across the screen, bouncing off the boundary walls. Like the ball in "Pong."
                break;
            case ShipType.King:
                // A ship fully controlled by the player.
                break;
            case ShipType.Knight:
                // Stationary, but jumps to new location at intervals.
                break;
            case ShipType.Pawn:
                // Moves in a straight line downwards.
                break;
            case ShipType.Queen:
                // A ship fully controlled by the player.
                break;
            case ShipType.Rook:
                // Moves to the end of the screen, then moves downwards, and repeats in the opposite direction.
                break;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        
        switch (shipType)
        {
            case ShipType.Pawn:
                transform.position += Vector3.down * speed * Time.deltaTime; // This is the same as below.
                //transform.position = Vector3.MoveTowards(transform.position, path[0].transform.position, speed * Time.deltaTime);
                break;
            case ShipType.King:
                break;
            case ShipType.Knight:
                if ((int) counter == (int) delayTime)
                {
                    GetComponent<Transform>().position = list[(int)(Random.Range(0, list.Count))].position;
                    counter = 0;
                }
                
                break;
            case ShipType.Bishop:
                GetComponent<Rigidbody>().velocity = moveDirection;
                break;
            case ShipType.Queen:
                break;
            case ShipType.Rook:
                transform.position += moveDirection * speed * Time.deltaTime;
                if(moveDirection == Vector3.down)
                    if(counter >= delayTime)
                        if (switchCounter == true)
                        {
                            moveDirection = Vector3.right;
                        }
                        else
                        {
                            moveDirection = Vector3.left;
                        }
                break;
        }
    }

    void Shoot()
    {
        if(canShoot && Random.Range(1,3) == 1)
        {
            if(isHoming)
            {
                GameObject bullet = Instantiate(homingBulletPrefab, transform.position, Quaternion.identity);
                Destroy(bullet, 3);
                bullet.GetComponent<HomingBullet>().target = GameObject.Find("Queen_Alt");
            }
            else
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Destroy(bullet, 5);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, -10, 0) * 50);

            }
        }

    }
}
