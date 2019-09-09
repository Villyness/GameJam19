using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // This is the base script for the AI ships used by the player
    // Setting up...
    //public string objectName;
    public Transform[] path;
    public int currentPoint = 0;
    public float speed;

    public float delayTime;
    public float currentTimer;
    public GameObject selfTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != path[currentPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].transform.position,
                speed * Time.deltaTime);
        }

        if (transform.position == path[currentPoint].position)
        {
            Delay();
        }

        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    private void Delay()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            currentPoint++;
            currentTimer = delayTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet>())
            DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(selfTarget);
    }
}
