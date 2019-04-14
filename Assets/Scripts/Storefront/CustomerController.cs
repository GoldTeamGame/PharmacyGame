// File: CustomerController
// Version: 2.0.1
// Last Updated: 4/13/19
// Authors: Alexander Jacks
// Description: Tells customer when and where to move

using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, 0.95f, 0.95f, -0.95f, -0.95f }; // values that help set moveLocation

    public MovementController mc;
    public int limit = 20; // "Desire Capacity"
    public int currentAmount = 0; // Number is increased each move. When currentAmmount reaches limit, reset currentAmount and remove a desire
    public bool isBuying;
    public bool isLeaving;
    public bool isFinding;
    public int wallet = 0;

	void Start ()
    {
        List<CustomerData> p = Globals_Customer.customerData;
        GetComponent<MovementController>().path = GetComponent<Customer>().cd.path;
        mc = GetComponent<MovementController>();
        if (mc == null)
        {
            mc = new MovementController();
        }

        if (mc.path == null)
            mc.path = new Path(-1.5f, 6);
        else
            mc.path.moveState = 0;

        setMovementController();
        mc.speed = GetComponent<Customer>().cd.speed;

        isBuying = GetComponent<Customer>().cd.isBuying;
        isLeaving = GetComponent<Customer>().cd.isLeaving;
        isFinding = GetComponent<Customer>().cd.isFinding;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (mc.path.currentNode == mc.path.path.Count)
        {
            think();
        }
        else
        {
            mc.performMove();
            setMovementController();
        }
    }

    // Customer sets its move according to its current state
    void think()
    {
        // Find the counter if the customer is ready to buy
        if (isBuying)
        {
            if (transform.localPosition.x != 0.5f && transform.localPosition.y != -0.5f)
            {
                mc.setPath(transform.localPosition.x, transform.localPosition.y, 0.5f, -0.5f);
                setMovementController();
                saveLocation();
            }
            else
            {
                isLeaving = true;
                isBuying = false;
                GetComponent<Customer>().cd.isLeaving = true;
                GetComponent<Customer>().cd.isBuying = false;
                Globals.setGold(Globals.getGold() + wallet);
            }
        }
        // Find the exit if the customer is ready to leave
        else if (isLeaving)
        {
            if (transform.localPosition.x != -1.5f && transform.localPosition.y != 6)
            {
                mc.setPath(transform.localPosition.x, transform.localPosition.y, -1.5f, 6f);
                setMovementController();
                saveLocation();
            }
            // Remove customer once they reach the exit
            else
            {
                removeCustomer();
            }
        }
        // Move in a random direction and update desires if not buying or leaving
        else
        {
            if (currentAmount > limit)
            {
                isBuying = true;
                GetComponent<Customer>().cd.isBuying = true;
            }
            else
            {
                mc.setRandomPath();
                setMovementController();
                saveLocation();
                currentAmount += mc.path.getDistance();
            }
        }
    }
    
    private Vector3 createVector(Position p)
    {
        return new Vector3(p.x, p.y);
    }

    
    // Handles a customers desires
    void updateDesire(int distance)
    {
        currentAmount += distance; // add distance traveled to currentAmount

        // When currentAmount reaches limit, reset currentAmount and remove a desire
        if (!isBuying && !isLeaving && currentAmount >= limit)
        {
            currentAmount = 0; // reset currentAmount
            CustomerData cd = GetComponent<Customer>().cd; // grab customerData from Customer Script

            // Update desires customer found something
            if (cd.desiresRemaining > 0)
            {
                cd.desiresRemaining--;

                Drug d = Globals.findDrug(cd.desires[cd.desiresRemaining], Globals.overCounterList);

                if (d != null)
                {
                    if (d.amount > 0)
                    {
                        d.amount -= 1;
                        wallet += d.price + (d.price / 2);
                    }

                    cd.desires[cd.desiresRemaining] = Toolbox.StrikeThrough(cd.desires[cd.desiresRemaining]);

                    // Update desires in the customer information screen if the scene is open
                    if (CustomerScreen.isAtCustomerScene)
                    {
                        // Find the index of the customer being updated
                        int numberOfCustomers = Globals_Customer.customerData.Count;
                        int index = -2;
                        for (int i = 0; i < numberOfCustomers; i++)
                            if (cd.Equals(Globals_Customer.customerData[i]))
                                index = i;

                        if (CustomerScreen.currentCustomer == index)
                            CustomerScreen.listDesires(cd);
                    }
                }
            }

            // Set isBuying to true when customer has picked up everything they want to purchase
            if (cd.desiresRemaining == 0)
            {
                isBuying = true;
                GetComponent<Customer>().cd.isBuying = true;
            }
        }
    }

    public static void repath(int state)
    {
        int numberOfCustomers = Globals_Customer.customerData.Count;
        List<CustomerData> ad = Globals_Customer.customerData;
        for (int i = 0; i < numberOfCustomers; i++)
            Globals_Customer.customerData[i].path.moveState = state;
    }

    // Removes the customer from the CustomerData List and the CustomerScreen Button List
    void removeCustomer()
    {
        CustomerData cd = GetComponent<Customer>().cd;
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

        cd.isAlive = false; // set customer to "dead" allowing its id to be replaced
        Globals_Customer.customerData.Remove(cd); // remove customerData element
        Destroy(gameObject); // remove object from game world
    }

    private void setMovementController()
    {
        GetComponent<MovementController>().path = mc.path;
        GetComponent<MovementController>().moveDirection = mc.moveDirection;
        GetComponent<MovementController>().moveLocation = mc.moveLocation;
        GetComponent<Customer>().cd.path = mc.path;
    }

    private void saveLocation()
    {
        GetComponent<Customer>().cd.locationX = transform.position.x;
        GetComponent<Customer>().cd.locationY = transform.position.y;
    }
}
