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

    private Vector3 moveDirection = Vector3.zero;
    public float speed;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
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
    }
}
