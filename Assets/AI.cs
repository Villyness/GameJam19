using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // This is the base script for the AI ships used by the player
    // Setting up...
    public string name;
    public Transform[] path;
    public int currentPoint = 0;
    public float speed;
    
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
            currentPoint++;
        }

        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }
}
