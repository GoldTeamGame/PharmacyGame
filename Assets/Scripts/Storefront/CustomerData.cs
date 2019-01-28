using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerData
{
    public int id; // unique id to find customer in its array
    public string name; // name of customer
    public float speed; // speed that customer moves
    public string[] desires; // what a customer wants to buy
    public int happiness; // how happy a customer is
    public bool isAlive; // does the customer gameObject still exist?

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate

    public CustomerData(int id, string name, float speed)
    {
        this.id = id;
        this.name = name;
        this.speed = speed;
        isAlive = true;
    }
}
