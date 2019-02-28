// File: Move
// Version: 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Holds a coordinate point and a goodness value (Used for AStar)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public float x;
    public float y;
    public float goodness;
    public int direction;
    public Move previousMove;

    public Move(float x, float y, float goodness, int direction, Move previousMove)
    {
        this.x = x;
        this.y = y;
        this.goodness = goodness;
        this.direction = direction;
        this.previousMove = previousMove;
    }

    public void displayMoves()
    {
        Move current = this;
        Debug.Log("X: " + x + ", Y: " + y);

        current = previousMove;

        while (current != null)
        {
            Debug.Log("X: " + current.x + ", Y: " + current.y);
            current = current.previousMove;
        }
    }
}
