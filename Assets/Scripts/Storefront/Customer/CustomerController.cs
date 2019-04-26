﻿// File: CustomerController
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

    public CustomerData cd;
    public MovementController mc;
    public int limit = 20; // "Desire Capacity"
    public int currentAmount = 0; // Number is increased each move. When currentAmmount reaches limit, reset currentAmount and remove a desire
    public bool isBuying;
    public bool isLeaving;
    public bool isWaiting;
    public bool isInLine;
    public int cart = 0;

    void Start()
    {
        cd = GetComponent<Customer>().cd;
        List<CustomerData> p = Globals_Customer.customerData;
        GetComponent<MovementController>().path = GetComponent<Customer>().cd.path;
        mc = GetComponent<MovementController>();
        currentAmount = GetComponent<Customer>().cd.currentAmount;
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
        isWaiting = GetComponent<Customer>().cd.isWaiting;
        isInLine = GetComponent<Customer>().cd.isInLine;
    }

    // Update is called once per frame
    void Update()
    {
        if (mc.path.currentNode == mc.path.path.Count)
        {
            think(); // Find a path to a location
        }
        else
        {
            mc.performMove(); // Move to a node
            setMovementController(); // Update data
        }
    }

    // Customer sets its move according to its current state
    void think()
    {
        // Find the counter if the customer is ready to buy
        if (isBuying)
        {
            // Do stuff while not waiting
            if (!cd.isWaiting)
            {
                if (cd.counter != -1 && !Globals_Pharmacist.pharmacistCounter[cd.counter].isPharmacist)
                {
                    cd.isDeciding = true;
                    cd.isInLine = false;
                    mc.setPath(transform.localPosition.x, transform.localPosition.y, Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.x, Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.y);
                    cd.counter = -1;
                }
                if (cd.isDeciding)
                {
                    int counter = 0;
                    for (int i = 1; i < Globals_Pharmacist.pharmacistCounter.Length; i++)
                        if (Globals_Pharmacist.pharmacistCounter[i].isUnlocked && Globals_Pharmacist.pharmacistCounter[i].isPharmacist && Globals_Pharmacist.pharmacistCounter[i].numberInLine < Globals_Pharmacist.pharmacistCounter[counter].numberInLine)
                            counter = i;
                    cd.counter = counter;
                    cd.isDeciding = false;
                }
                
                // Find path to start of line
                if (!cd.isInLine && (transform.localPosition.x != Globals_Pharmacist.pharmacistCounter[cd.counter].lineStart.x || transform.localPosition.y != Globals_Pharmacist.pharmacistCounter[cd.counter].lineStart.y))
                {
                    cd.thoughts = "Going to Pharmacist Counter";
                    mc.setPath(transform.localPosition.x, transform.localPosition.y, Globals_Pharmacist.pharmacistCounter[cd.counter].lineStart.x, Globals_Pharmacist.pharmacistCounter[cd.counter].lineStart.y);
                    setMovementController();
                    saveLocation();
                }

                // When reaching the start of the line, find the position in the line to move to the appropriate spot in the line
                if (transform.localPosition.x == Globals_Pharmacist.pharmacistCounter[cd.counter].lineStart.x && transform.localPosition.y == Globals_Pharmacist.pharmacistCounter[cd.counter].lineStart.y)
                {
                    cd.positionInLine = Globals_Pharmacist.pharmacistCounter[cd.counter].numberInLine++; // increment line number
                    Position pos = new Position(Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.x + (cd.positionInLine * 0.1f), Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.y);
                    mc.setPath(new Vector3(pos.x, pos.y)); // set path
                    //cd.positionInLine = Globals_Pharmacist.pharmacistCounter[0].numberInLine++; // increment line number
                    isInLine = true; // set isInLine to true (which will trigger the following if-statement after the movement finishes
                    GetComponent<Customer>().cd.isInLine = isInLine;
                }
                // Reached counter, now pay and change state to leaving
                else if (cd.isInLine)
                {
                    Globals_Pharmacist.pharmacistCounter[cd.counter].isCustomer = true; // Tell pharmacist that a customer is at the counter
                    isWaiting = true; // set isWaiting to true
                    GetComponent<Customer>().cd.isWaiting = isWaiting;
                }
            }
            else if (Globals_Pharmacist.pharmacistCounter[cd.counter].isFinished && cd.positionInLine == -1)
            {
                buyItems();
                isLeaving = true;
                isBuying = false;
                GetComponent<Customer>().cd.isLeaving = true;
                GetComponent<Customer>().cd.isBuying = false;
                Globals.setGold(Globals.getGold() + cart);
                Globals.monthlyGold += cart;
            }
            else if (GetComponent<Customer>().cd.isUpdate)
            {
                cd.isUpdate = false;
                GetComponent<Customer>().cd.isUpdate = false;
                Position pos = new Position(Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.x + (cd.positionInLine * 0.1f), Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.y);
                mc.setPath(new Vector3(pos.x, pos.y)); // set path
                Globals_Pharmacist.pharmacistCounter[cd.counter].isCustomer = true; // Tell pharmacist that a customer is at the counter
            }
            else if (!Globals_Pharmacist.pharmacistCounter[cd.counter].isPharmacist)
            {
                cd.isDeciding = true;
                cd.isInLine = false;
                mc.setPath(transform.localPosition.x, transform.localPosition.y, Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.x, Globals_Pharmacist.pharmacistCounter[cd.counter].checkout.y);
                cd.counter = -1;
                cd.isWaiting = false;
            }
        }
        // Find the exit if the customer is ready to leave
        else if (isLeaving)
        {
            // Find the exit
            if (transform.localPosition.x != -1.5f && transform.localPosition.y != 6)
            {
                cd.thoughts = "Leaving Store";
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
            // Change state to buying when currentAmount reaches limit
            if (currentAmount > limit || cd.desires.overCounter.Length == 0)
            {
                isBuying = true;
                GetComponent<Customer>().cd.isBuying = true;
            }
            else
            {
                mc.setRandomPath();
                setMovementController();
                saveLocation();
                updateDesire(mc.path.getDistance());
                GetComponent<Customer>().cd.currentAmount = currentAmount;
            }
        }
    }

    private Vector3 createVector(Position p)
    {
        return new Vector3(p.x, p.y);
    }

    private void buyItems()
    {
        for (int i = 0; i < cd.desires.overCounter.Length; i++)
        {
            if (cd.desires.overCounter[i].hasPickedUp)
                cart += cd.desires.overCounter[i].drug.price + (cd.desires.overCounter[i].drug.price / 2);
        }
        for (int i = 0; i < cd.desires.prescription.Length; i++)
        {
            if (cd.desires.prescription[i].drug.amount > 0)
            {
                cart += cd.desires.prescription[i].drug.price + (cd.desires.prescription[i].drug.price / 2);
                cd.desires.prescription[i].drug.amount--;
                increaseMood(1);
            }
            else
                decreaseMood(4);
        }
    }

    // Handles a customers desires
    // Only deals with Over the Counter drugs
    // Customer will walk around "picking items up off the shelves"
    //      - Each time they find an item, their mood will increase and the item will be crossed off the list
    //      - If the customer cannot find the item, they will move on to another item
    //      - If the only item(s) left on their list are items they cannot find, they will go to buy the items they can and their mood will drop for every item they could not find
    void updateDesire(int distance)
    {
        currentAmount += distance; // add distance traveled to currentAmount
        decreaseMood(0);

        // When currentAmount reaches limit, update desires
        if (!isBuying && !isLeaving && currentAmount >= limit)
        {
            currentAmount = 0; // reset currentAmount
            CustomerData cd = GetComponent<Customer>().cd; // grab customerData from Customer Script
            Drug d = cd.desires.getCurrentDrug(); // get the drug that the customer is currently looking for

            // if d exists
            if (d != null)
            {
                // Check if d is unlocked
                if (d.isUnlocked && findDrug(d.name))
                {
                    cd.desires.desiresRemaining--;
                    d.amount--;
                    cd.desires.overCounter[cd.desires.currentDrug].hasPickedUp = true;
                    increaseMood(0);
                    //d.name = Toolbox.StrikeThrough(d.name);
                    cd.desires.willBuyOverCounter = true;
                }
                else
                {
                    if (d.isUnlocked)
                        decreaseMood(1);
                    else
                        decreaseMood(2);

                    if (++cd.desires.overCounter[cd.desires.currentDrug].attempts >= 2)
                        cd.desires.desiresRemaining--;
                    cd.desires.currentDrug++;

                    d = cd.desires.getCurrentDrug();
                    if (d != null)
                        cd.thoughts = "Looking For: " + cd.desires.getCurrentDrug().name;
                }
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

            // Set isBuying to true when customer has picked up everything they want to purchase
            if (cd.desires.isLooking() || cd.desires.desiresRemaining == 0)
            {
                if (cd.desires.willBuyOverCounter || cd.desires.prescription.Length > 0)
                {
                    isBuying = true;
                    GetComponent<Customer>().cd.isBuying = true;
                }
                else
                {
                    isLeaving = true;
                    GetComponent<Customer>().cd.isLeaving = true;
                }
            }
        }
    }

    // Attempt to find if "s" is somewhere on the storefront
    public bool findDrug(string s)
    {
        bool isAvailable = false;

        // Loop through storeData array (each element is a script attatched to a shelf on the storefront)
        for (int i = 0; i < Globals_Items.storeData.Count; i++)
        {
            // Check to see if the first side of the shelf has the drug being queried
            if (Globals_Items.storeData[i].drug[0].Equals(s))
            {
                // Check if the amount of the drug being stored on the shelf is larger than 0
                isAvailable = Globals_Items.storeData[i].amount[0] > 0;

                // If the drug is available, then decrease the amount on the shelf
                if (isAvailable)
                {
                    Globals_Items.storeData[i].amount[0]--;
                    ShowGameObject.updateAmount();
                    break;
                }
            }
            // Check to see if the second side of the shelf has the drug being queried
            if (Globals_Items.storeData[i].drug[1].Equals(s))
            {
                // Check if the amount of the drug being stored on the shelf is larger than 0
                isAvailable = Globals_Items.storeData[i].amount[1] > 0;

                // If the drug is available, then decrease the amount on the shelf
                if (isAvailable)
                {
                    Globals_Items.storeData[i].amount[1]--;
                    ShowGameObject.updateAmount();
                    break;
                }
            }
        }
        return isAvailable;
    }

    // Sets state for all customers to tell them an object has been placed or removed from storefront
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
        Globals_Customer.cumulativeMood += cd.mood;
        Globals_Customer.customersServed++;
        Globals_Customer.globalMood = Globals_Customer.cumulativeMood / Globals_Customer.customersServed; // set new average
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

    private void decreaseMood(int trigger)
    {
        int decrease = 0;

        // Traveling penalty
        if (trigger == 0)
            decrease = Random.Range(2, 4) - (cd.tolerance / 3);
        // No over-counter stock penalty
        else if (trigger == 1)
            decrease = Random.Range(5, 10) - cd.tolerance;
        // No over-counter unlocked penalty
        else if (trigger == 2)
            decrease = Random.Range(2, 4) - (cd.tolerance / 3);
        // No prescription stock
        else if (trigger == 4)
            decrease = Random.Range(8, 14) - cd.tolerance;

        // Restrict lowest decrease amount to 1
        if (decrease < 1)
            decrease = 1;

        cd.mood -= decrease; // lower mood

        // Make sure mood doesn't go below 0
        if (cd.mood < 0)
            cd.mood = 0;
    }

    private void increaseMood(int trigger)
    {
        int increase = 0;

        // Increase after finding over-counter drug
        if (trigger == 0)
            increase = Random.Range(3, 6) + cd.flexibility;
        // Increase after getting prescription drug
        else if (trigger == 1)
            increase = Random.Range(6, 10) + cd.flexibility;

        cd.mood += increase; // increase mood

        // Make sure mood does not go over 100
        if (cd.mood > 100)
            cd.mood = 100;
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
