using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistCounter
{
    public GameObject assignedPharmacist;
    public int numberOfCustomers; // number of customers in line
    public Position checkoutZone; // location of checkout zone
    public Position lineStartZone; // location of line start zone
    public Position employeeStartZone; // location of employee starting zone
    public Position computerZone; // location of computer zone
    public Position shelfZone; // location of shelf zone


    public void generatePositions(Position p)
    {
        employeeStartZone = p;
        checkoutZone = new Position(p.x, p.y + 1.5f);
        lineStartZone = new Position(p.x + 1.5f, p.y + 1.5f);
        computerZone = new Position(p.x - 1, p.y - 0.5f);
        shelfZone = new Position(p.x, p.y - 1);
    }
}
