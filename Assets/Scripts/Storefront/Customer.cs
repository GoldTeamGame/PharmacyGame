// File: Customer
// Version: 1.1.1
// Last Updated: 2/11/19
// Authors: Alexander Jacks
// Description: GameObject script for customer

using UnityEngine;

public class Customer : MonoBehaviour
{
    public CustomerData cd; // contains information about customer
    
    // Generate Customer Data
    private void Start()
    {
        ProceduralGenerator.generate(ref cd); // pass variables to be handled by ProceduralGenerator
        GetComponent<SpriteRenderer>().sprite = ProceduralGenerator.staticAppearanceList[cd.appearance]; // set customer sprite
        transform.localScale = new Vector3(2f, 2f, 0); // set customer sprite size (make it bigger)
        //GetComponent<CustomerController>().speed = cd.speed; // set CustomerController speed
    }

    // Dictates a customer's actions
    private void Update()
    {
        // Save current coordinate position of customer in customerData (for save/load purposes)
        //cd.locationX = transform.position.x;
        //cd.locationY = transform.position.y;
    }
}
