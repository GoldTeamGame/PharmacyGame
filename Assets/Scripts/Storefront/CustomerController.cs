// File: CustomerController
// Version: 1.0.3
// Last Updated: 2/11/19
// Authors: Alexander Jacks
// Description: Tells customer when and where to move

using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public float speed;
    MoveSet ms;
    Queue<int> moveQ; // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
    int limit = 5;
    int currentAmount = 0;
    bool isBuying;
    bool isLeaving;

	void Start ()
    {
        ms = new MoveSet(transform, speed);
        moveQ = new Queue<int>(100);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ms.isMoving == -1)
        {
            think();
            ms.setMove(moveQ.peek(), ref moveQ);
        }
        else
            ms.move();
    }

    void think()
    {
        if (isBuying)
        {
            if (moveQ.isEmpty())
                findCounter();

            if (moveQ.isEmpty())
            {
                isLeaving = true;
                isBuying = false;
            }
        }
        else if (isLeaving)
        {
            findExit();

            if (moveQ.isEmpty())
                removeCustomer();
        }
        else
        {
            // Update Desires
            updateDesire();

            // Set direction and distance
            int direction = Random.Range(0, 7);
            int distance = Random.Range(1, 10);

            moveQ.enqueue(direction, distance);
        }
    }

    void findCounter()
    {
        float xPath;
        float yPath;

        float xDest = 0.5f;
        float yDest = -0.5f;

        float xCurrent = transform.localPosition.x;
        float yCurrent = transform.localPosition.y;

        xPath = (xDest - xCurrent) / .5f;
        yPath = (yDest - yCurrent) / .5f;

        // EX: xPath = 5 & yPath = -13
        float diagonal = Mathf.Min(Mathf.Abs(xPath), Mathf.Abs(yPath));

        if (xPath > 0)
            moveQ.enqueue(6, (int) diagonal);
        else
            moveQ.enqueue(7, (int) diagonal);

        float remaining = Mathf.Abs(Mathf.Abs(xPath) - Mathf.Abs(yPath));

        if (Mathf.Abs(xPath) > Mathf.Abs(yPath))
        {
            if (xPath > 0)
                moveQ.enqueue(0, (int) remaining);
            else
                moveQ.enqueue(1, (int) remaining);
        }
        else
            moveQ.enqueue(3, (int) remaining);
    }

    void findExit()
    {
        if (transform.localPosition.x > ProceduralGenerator.xSpawnPoint)
            moveQ.enqueue(1, 1);
        else if (transform.localPosition.x < ProceduralGenerator.xSpawnPoint)
            moveQ.enqueue(0, 1);

    }

    void updateDesire()
    {
        currentAmount += Random.Range(3, 5); // add random value to currentAmount

        // When currentAmount reaches limit, reset currentAmount and remove a desire
        if (!isBuying && !isLeaving && currentAmount >= limit)
        {
            currentAmount = 0; // reset currentAmount
            CustomerData cd = GetComponent<Customer>().cd; // grab customerData from Customer Script
            string[] newDesires = new string[cd.desires.Length - 1]; // Create new desires list

            // Update desires if length of new list is greater than 0
            if (cd.desires.Length >= 0)
            {
                // Copy desires into newDesires
                for (int i = 0; i < newDesires.Length; i++)
                    newDesires[i] = cd.desires[i];

                // Replaced desires currently in customerData with newDesires
                GetComponent<Customer>().cd.desires = newDesires;

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
                        CustomerScreen.listDesires(newDesires);
                }
            }

            // Set isBuying to true when customer has picked up everything they want to purchase
            if (newDesires.Length == 0)
                isBuying = true;
        }
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
}
