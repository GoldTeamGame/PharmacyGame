// File: CustomerData
// Version: 1.0.4
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Contains all a customers information

[System.Serializable]
public class CustomerData
{

    public string name; // name of customer
    public float speed; // speed that customer moves
    public int mood; // how happy a customer is
    public string thoughts; // what the customer is currently thinking about
    public Desires desires;

    public bool isAlive; // does the customer gameObject still exist?
    public bool isBuying; // is the customer buying something
    public bool isLeaving; // is the customer leaving the store
    public bool isWaiting; // is the customer finding something
    public bool isInLine;
    public bool isDeciding;
    public int counter;

    public int positionInLine;
    public bool isUpdate; // set to true if the customer needs to update their position in line
    public int currentAmount; // keeps track of when customer desire should be updated


    public int appearance;

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate

    public Path path;

    public float pLocationX = 0; // FOR DEBUGGING: Shows x-location 
    public float pLocationY = 0; // FOR DEBUGGING: Shows y-location

    public CustomerData(string name, float speed)
    {
        this.name = name;
        this.speed = speed;
        isAlive = true;
        isDeciding = true;
        counter = -1;
    }
}
