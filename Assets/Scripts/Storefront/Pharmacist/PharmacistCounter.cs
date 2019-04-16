using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PharmacistCounter
{
    // [0] - start
    // [1] - computer
    // [2] - shelf
    public Position[] pharmacistZone; // positions relative to pharmacistState

    // [0] - start -> computer
    // [1] - computer -> shelf
    // [2] - shelf ->start
    public Node[][] path; // paths between different pharmacistZone's
    public bool isFinished; // Sends out a ping saying that the pharmacist is done processing transaction
    public bool isCustomer; // Tells the pharmacist that a customer is waiting at checkout
    public Position checkout; // Where customer can checkout
    public Position lineStart; // Where the customer enters the line
    public int numberInLine; // number of customers currently in line
    //public bool isUnlocked; // determines if the PharmacistCounter exists

    // Generates all positions based on the passed in position
    // Constructor is only called on a new game
    public PharmacistCounter(Position p)
    {
        pharmacistZone = new Position[3];
        path = new Node[3][];
        pharmacistZone[0] = p;
        Node[] newP1 = { new Node(new Position(pharmacistZone[0].x - 0.5f, pharmacistZone[0].y - 0.5f), 0, 7), new Node(new Position(pharmacistZone[0].x - 1, pharmacistZone[0].y - 0.5f), 0, 1)};
        path[0] = newP1;

        pharmacistZone[1] = new Position(p.x - 1, p.y - 0.5f);
        Node[] newP2 = { new Node(new Position(pharmacistZone[1].x + 0.5f, pharmacistZone[1].y - 0.5f), 0, 6), new Node(new Position(pharmacistZone[1].x + 1, pharmacistZone[1].y - 0.5f), 0, 0) };
        path[1] = newP2;

        pharmacistZone[2] = new Position(p.x, p.y - 1);
        Node[] newP3 = { new Node(new Position(pharmacistZone[2].x, pharmacistZone[2].y + 0.5f), 0, 2), new Node(new Position(pharmacistZone[2].x, pharmacistZone[2].y + 1), 0, 2) };
        path[2] = newP3;

        checkout = new Position(p.x, p.y + 1.5f);
        lineStart = new Position(p.x + 1.5f, p.y + 1.5f);

        numberInLine = 0;
    }
}
