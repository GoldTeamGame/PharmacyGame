using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistCounter
{
    // [0] - start
    // [1] - computer
    // [2] - shelf
    public Position[] pharmacistZone; // positions relative to pharmacistState
    public Position checkout; // Where customer can checkout
    public Position lineStart; // Where the customer enters the line
    public int numberInLine; // number of customers currently in line
    //public bool isUnlocked; // determines if the PharmacistCounter exists

    // Generates all positions based on the passed in position
    // Constructor is only called on a new game
    public PharmacistCounter(Position p)
    {
        pharmacistZone = new Position[3];
        pharmacistZone[0] = p;
        pharmacistZone[1] = new Position(p.x - 1, p.y - 0.5f);
        pharmacistZone[2] = new Position(p.x, p.y - 1);

        checkout = new Position(p.x, p.y + 1.5f);
        lineStart = new Position(p.x + 1.5f, p.y + 1.5f);

        numberInLine = 0;
    }
}
