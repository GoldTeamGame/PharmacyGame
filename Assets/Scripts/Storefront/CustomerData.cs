// File: CustomerData
// Version: 1.0.2
// Last Updated: 2/6/19
// Authors: Alexander Jacks
// Description: Contains all a customers information

[System.Serializable]
public class CustomerData
{
    public string name; // name of customer
    public float speed; // speed that customer moves
    public int mood; // how happy a customer is
    public string thoughts; // what the customer is currently thinking about
    public string[] desires; // what a customer wants to buy
    public bool isAlive; // does the customer gameObject still exist?
    public bool isBuying; // is the customer buying something
    public bool isLeaving; // is the customer leaving the store

    public int appearance;

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate

    public CustomerData(string name, float speed)
    {
        this.name = name;
        this.speed = speed;
        isAlive = true;
    }
}
