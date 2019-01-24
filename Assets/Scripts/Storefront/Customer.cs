using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
    
    public int id; // unique id to find customer in its array
    public string name; // name of customer
    public float speed; // speed that customer moves
    public string[] desires; // what a customer wants to buy
    public int happiness; // how happy a customer is
    public bool isAlive; // does the customer gameObject still exist?
    DEMO_SimpleMovement movement;
    
    //public double wallet; // amount of money a customer has
    
    // Generate Customer Data
    private void Start()
    {
        ProceduralGenerator.generate(ref id, ref name, ref speed, ref movement); // pass variables to ProceduralGenerator
        isAlive = true; // set customer to alive
        Globals_Customer.customer[id] = gameObject; // update gameObject in Globals_Customer
        Globals_Customer.customerData[id] = this; // update Customer in Globals_Customer
    }

    // Dictates a customer's actions
    private void Update()
    {
        movement.move(transform, speed); // Move

        // Delete the object after it has reached the end
        if (transform.position.y > 4)
        {
            Destroy(gameObject);
            isAlive = false; // set customer to "dead" allowing its id to be replaced
            Globals_Customer.numberOfCustomers--; // decrement number of customers
        }
    }
}
