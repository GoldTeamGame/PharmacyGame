// File: Customer
// Version: 1.0.5
// Last Updated: 2/6/19
// Authors: Alexander Jacks
// Description: GameObject script for customer

using UnityEngine;

public class Customer : MonoBehaviour
{
    CustomerData cd; // contains information about customer
    DEMO_SimpleMovement movement; // tells customer how to move
    
    
    // Generate Customer Data
    private void Start()
    {
        ProceduralGenerator.generate(ref cd, ref movement); // pass variables to be handled by ProceduralGenerator
        GetComponent<SpriteRenderer>().sprite = ProceduralGenerator.staticAppearanceList[cd.appearance]; // set customer sprite
        transform.localScale = new Vector3(1.5f, 1.5f, 0); // set customer sprite size (make it bigger)
    }

    // Dictates a customer's actions
    private void Update()
    {
        movement.move(transform, cd.speed); // Move customer

        // Save current coordinate position of customer in customerData (for save/load purposes)
        cd.locationX = transform.position.x;
        cd.locationY = transform.position.y;

        // Delete the object after it has reached the end
        if (transform.position.y > 4)
        {
            CustomerScreen.updateList(Globals_Customer.customerData.IndexOf(cd)); // Remove button from customer screen

            // Find the index of the customer being removed
            int numberOfCustomers = Globals_Customer.customerData.Count;
            int index = -2;
            for (int i = 0; i < numberOfCustomers; i++)
                if (cd.Equals(Globals_Customer.customerData[i]))
                    index = i;
            
            // Close the Customer Info screen if the customer being destroyed is the same customer being viewed
            if (CustomerScreen.currentCustomer == index)
            {
                CustomerScreen.staticPanel.gameObject.SetActive(false);
                CustomerScreen.currentCustomer = -1;
            }
            else if (index < CustomerScreen.currentCustomer)
                CustomerScreen.currentCustomer--;

            Globals_Customer.customerData.Remove(cd); // remove customerData element
            Destroy(gameObject); // remove object from game world
            cd.isAlive = false; // set customer to "dead" allowing its id to be replaced
        }
    }
}
