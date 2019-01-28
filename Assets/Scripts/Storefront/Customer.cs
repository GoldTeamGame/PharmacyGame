using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {

    public CustomerData cd;
    DEMO_SimpleMovement movement;
    
    // Generate Customer Data
    private void Start()
    {
        //if (cd == null)
        //{
            ProceduralGenerator.generate(ref cd, ref movement); // pass variables to ProceduralGenerator
        Debug.Log(cd.id);
            Globals_Customer.customerData[cd.id] = cd; // update Customer in Globals_Customer
        //}
    }

    // Dictates a customer's actions
    private void Update()
    {
        movement.move(transform, cd.speed); // Move
        cd.locationX = transform.position.x;
        cd.locationY = transform.position.y;

        // Delete the object after it has reached the end
        if (transform.position.y > 4)
        {
            Destroy(gameObject);
            cd.isAlive = false; // set customer to "dead" allowing its id to be replaced
            Globals_Customer.numberOfCustomers--; // decrement number of customers
        }
    }
}
