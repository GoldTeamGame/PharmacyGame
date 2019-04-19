using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistController : MonoBehaviour
{
    public Pharmacist p;
    MovementController mc; // handles movement
    Timer t;

	// Use this for initialization
	void Start ()
    {
        mc = GetComponent<MovementController>();
        mc.speed = p.speed;
        mc.path.destination = (findNextLocation());
        t = new Timer(p.progress);
        if (p.progress > 0)
            t.start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.localPosition.x == mc.path.destination.x && transform.localPosition.y == mc.path.destination.y)
            think();
        else
            mc.performMove();
    }

    // The AI thinking aspect of the pharmacist
    void think()
    {
        // If pharmacist is idle and a customer is at the counter, then begin processing transaction
        if (p.currentState == -1 && Globals_Pharmacist.pharmacistCounter[p.counter].isCustomer)
            p.currentState = 0;

        // Process Initial Transaction
        if (p.currentState == 0)
            processTransaction(0, 1);
        // Process Computer
        else if (p.currentState == 1)
            processTransaction(1, 2);
        // Process Drug Fetching 
        else if (p.currentState == 2)
            processTransaction(2, 3);
        // Process Post Transaction, communicate with customer and pharmacistCounter line
        else if (p.currentState == 3)
        {
            if (p.progress == 0 && !t.getIsActive())
                t.start();
            else if (t.getTime() > p.stats[p.currentState])
            {
                t.stopAndReset(); // stop and reset timer
                p.progress = 0; // reset progress
                p.currentState = -1; // switch state to idle
                updatePositions(p.counter); // update customer's line positions
                Globals_Pharmacist.pharmacistCounter[p.counter].isFinished = true; // tell pharmacistCounter that transaction is finished
                Globals_Pharmacist.pharmacistCounter[p.counter].isCustomer = false; // open up the pharmacistCounter for another customer
            }
            else
                p.progress = t.getTimeInSeconds();
        }
    }

    // Pharmacist spends time processing a transaction and then sets its path to the next location and changes state to next
    private void processTransaction(int index, int next)
    {
        if (p.currentState == -1)
        {
            t.stopAndReset();
            p.progress = 0;
        }
        else if (p.progress == 0 && !t.getIsActive())
            t.start(); // start timer
        else if (t.getTime() > p.stats[index])
        {
            t.stopAndReset(); // stop and reset timer
            p.progress = 0; // reset progress
            mc.setPath(Globals_Pharmacist.pharmacistCounter[p.counter].path[p.currentState]); // move to next location
            p.currentState = next; // change to next state
        }
        else
            p.progress = t.getTimeInSeconds(); // set progress
    }

    private static void updatePositions(int counter)
    {
        Globals_Pharmacist.pharmacistCounter[counter].numberInLine--;
        int numberOfCustomers = Globals_Customer.customerData.Count;
        for (int i = 0; i < numberOfCustomers; i++)
            if (Globals_Customer.customerData[i].counter == counter && Globals_Customer.customerData[i].positionInLine >= 0)
            {
                Globals_Customer.customerData[i].positionInLine--;
                Globals_Customer.customerData[i].isUpdate = true;
            }
    }

    Position findNextLocation()
    {
        if (p.currentState == -1 || p.currentState > 2)
            return Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[0];
        else
            return Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[p.currentState];
    }
}
