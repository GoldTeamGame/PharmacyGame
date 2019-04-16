using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistController : MonoBehaviour
{
    public Pharmacist p;
    MovementController mc; // handles movement

	// Use this for initialization
	void Start ()
    {
        mc = GetComponent<MovementController>();
        mc.path.destination = (findNextLocation());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.localPosition.x == mc.path.destination.x && transform.localPosition.y == mc.path.destination.y)
            think();
        else
            mc.performMove();
    }

    void think()
    {
        if (p.currentState == -1 && Globals_Pharmacist.pharmacistCounter[p.counter].isCustomer)
            p.currentState = 0;
        if (p.currentState == 0)
        {
            mc.setPath(Globals_Pharmacist.pharmacistCounter[p.counter].path[p.currentState]);
            p.currentState = 1;
        }
        else if (p.currentState == 1)
        {
            mc.setPath(Globals_Pharmacist.pharmacistCounter[p.counter].path[p.currentState]);
            p.currentState = 2;
            
        }
        else if (p.currentState == 2)
        {
            mc.setPath(Globals_Pharmacist.pharmacistCounter[p.counter].path[p.currentState]);
            p.currentState = 3;
        }
        else if (p.currentState == 3)
        {
            p.currentState = -1;
            updatePositions(p.counter);
            Globals_Pharmacist.pharmacistCounter[p.counter].isFinished = true;
            Globals_Pharmacist.pharmacistCounter[p.counter].isCustomer = false;
        }
    }

    private static void updatePositions(int counter)
    {
        Globals_Pharmacist.pharmacistCounter[counter].numberInLine--;
        Debug.Log(Globals_Pharmacist.pharmacistCounter[counter].numberInLine);
        int numberOfCustomers = Globals_Customer.customerData.Count;
        for (int i = 0; i < numberOfCustomers; i++)
            if (Globals_Customer.customerData[i].positionInLine >= 0)
            {
                Globals_Customer.customerData[i].positionInLine--;
                Globals_Customer.customerData[i].isUpdate = true;
            }
    }

    Position findNextLocation()
    {
        if (p.currentState == -1)
            return Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[0];
        else
            return Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[p.currentState];
    }
}
