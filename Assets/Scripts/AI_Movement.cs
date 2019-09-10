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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ships behave differently when reaching the play boundaries. 
        if (other.tag == "Boundary")
        {
            switch(shipType)
            {
                case ShipType.Bishop:
                    // Invert x
                    moveDirection.x = -moveDirection.x;
                    break;
                case ShipType.Knight:
                    // Invert x
                    moveDirection.x = -moveDirection.x;
                    break;
                case ShipType.Rook:
                    // store x, x = 0, y = -1 for a bit, then invert and use stored x
                    break;
            }
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
        switch (shipType)
        {
            case ShipType.Pawn:
                //transform.position += Vector3.down * speed * Time.deltaTime; // This is the same as below.
                transform.position = Vector3.MoveTowards(transform.position, path[0].transform.position, speed * Time.deltaTime);
                break;
            case ShipType.King:
                break;
            case ShipType.Knight:
                break;
            case ShipType.Bishop:
                break;
            case ShipType.Queen:
                break;
            case ShipType.Rook:
                break;
        }
    }
}
