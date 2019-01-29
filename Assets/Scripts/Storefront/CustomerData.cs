using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomerData
{
    public string name; // name of customer
    public float speed; // speed that customer moves
    public string[] desires; // what a customer wants to buy
    public int happiness; // how happy a customer is
    public bool isAlive; // does the customer gameObject still exist?

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate

    public CustomerData(string name, float speed)
    {
        this.name = name;
        this.speed = speed;
        isAlive = true;
    }
}
