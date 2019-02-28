// File: CustomerController
// Version: 1.0.4
// Last Updated: 2/25/19
// Authors: Alexander Jacks
// Description: Tells customer when and where to move

using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public float speed;
    public MoveSet ms;
    public Queue<int> moveQ; // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
    public int limit = 20; // "Desire Capacity"
    public int currentAmount = 0; // Number is increased each move. When currentAmmount reaches limit, reset currentAmount and remove a desire
    public bool isBuying;
    public bool isLeaving;

	void Start ()
    {
        // Instantiate MoveSet using info saved in CustomerData
        ms = new MoveSet(transform, speed, GetComponent<Customer>().cd.isMoving, GetComponent<Customer>().cd.destLocationX, GetComponent<Customer>().cd.destLocationY);
        moveQ = new Queue<int>(100);
        isBuying = GetComponent<Customer>().cd.isBuying;
        isLeaving = GetComponent<Customer>().cd.isLeaving;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ms.isMoving == -1)
        {
            think();
            ms.setMove(moveQ.peek(), ref moveQ);

            // Save moveLocation and isMoving state into CustomerData
            gameObject.GetComponent<Customer>().cd.destLocationX = ms.moveLocation.x;
            gameObject.GetComponent<Customer>().cd.destLocationY = ms.moveLocation.y;
            gameObject.GetComponent<Customer>().cd.isMoving = ms.isMoving;
        }
        else
            ms.move();
    }

    void think()
    {
        if (isBuying)
        {
            // Locate path to counter after finishing cuurent moves
            if (moveQ.isEmpty())
                aStar(0.5f, -0.5f);

            // Change states once counter is reached
            if (moveQ.isEmpty())
            {
                isLeaving = true;
                isBuying = false;
                GetComponent<Customer>().cd.isLeaving = true;
                GetComponent<Customer>().cd.isBuying = false;
                Globals.setGold(Globals.getGold() + Random.Range(1, 3));
            }
        }
        else if (isLeaving)
        {
            aStar(-1.5f, 6f);

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
        //float xPath;
        //float yPath;

        //float xDest = 0.5f;
        //float yDest = -0.5f;

        //float xCurrent = transform.localPosition.x;
        //float yCurrent = transform.localPosition.y;

        //xPath = (xDest - xCurrent) / .5f;
        //yPath = (yDest - yCurrent) / .5f;

        //// EX: xPath = 5 & yPath = -13
        //float diagonal = Mathf.Min(Mathf.Abs(xPath), Mathf.Abs(yPath));

        //if (xPath > 0)
        //    moveQ.enqueue(6, (int) diagonal);
        //else
        //    moveQ.enqueue(7, (int) diagonal);

        //float remaining = Mathf.Abs(Mathf.Abs(xPath) - Mathf.Abs(yPath));

        //if (Mathf.Abs(xPath) > Mathf.Abs(yPath))
        //{
        //    if (xPath > 0)
        //        moveQ.enqueue(0, (int) remaining);
        //    else
        //        moveQ.enqueue(1, (int) remaining);
        //}
        //else
        //    moveQ.enqueue(3, (int) remaining);

        //Debug.Log("Going to Buy");
        aStar(0.5f, -0.5f);
    }

    void findExit()
    {
        if (Mathf.Abs(transform.localPosition.x - ProceduralGenerator.xSpawnPoint) < 0.3f)
            transform.localPosition = new Vector3(ProceduralGenerator.xSpawnPoint, transform.localPosition.y, 0);
        else if (transform.localPosition.x > ProceduralGenerator.xSpawnPoint)
            moveQ.enqueue(1, 1);
        else if (transform.localPosition.x < ProceduralGenerator.xSpawnPoint)
            moveQ.enqueue(0, 1);

    }

    // Customer will find its way to [x, y]
    public void aStar(float x, float y)
    {
        PriorityQueue pq = new PriorityQueue(1000);

        float currentX = transform.localPosition.x;
        float currentY = transform.localPosition.y;
        Move currentMove = new Move(currentX, currentY, findDistance(currentX, currentY, x, y), 0, null);

        // Keep searching for path until destination is found
        while(currentMove.x != x || currentMove.y != y)
        {
            // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
            pq.enqueue(new Move(currentX + 0.5f, currentY,        findDistance(currentX + 0.5f, currentY,        x, y), 0, currentMove)); // right
            pq.enqueue(new Move(currentX + 0.5f, currentY + 0.5f, findDistance(currentX + 0.5f, currentY + 0.5f, x, y), 4, currentMove)); // upright
            pq.enqueue(new Move(currentX + 0.5f, currentY - 0.5f, findDistance(currentX + 0.5f, currentY - 0.5f, x, y), 6, currentMove)); // downright
            pq.enqueue(new Move(currentX,        currentY + 0.5f, findDistance(currentX,        currentY + 0.5f, x, y), 2, currentMove)); // up
            pq.enqueue(new Move(currentX - 0.5f, currentY + 0.5f, findDistance(currentX - 0.5f, currentY + 0.5f, x, y), 5, currentMove)); // upleft
            pq.enqueue(new Move(currentX,        currentY - 0.5f, findDistance(currentX,        currentY - 0.5f, x, y), 3, currentMove)); // down
            pq.enqueue(new Move(currentX - 0.5f, currentY,        findDistance(currentX - 0.5f, currentY,        x, y), 1, currentMove)); // left
            pq.enqueue(new Move(currentX - 0.5f, currentY - 0.5f, findDistance(currentX - 0.5f, currentY - 0.5f, x, y), 7, currentMove)); // downleft

            currentMove = pq.peekAndDequeue();
            currentX = currentMove.x;
            currentY = currentMove.y;
        }

        //currentMove.displayMoves();
        addMoves(currentMove);
        //Debug.Break();
    }

    private void addMoves(Move move)
    {
        Stack<Move> moves = new Stack<Move>(100);
        while(move.previousMove != null)
        {
            moves.push(move);
            move = move.previousMove;
        }

        int length = moves.size;
        for (int i = 0; i < length; i++)
        {
            moveQ.enqueue(moves.peekAndPop().direction);
        }

    }

    private float findDistance(float x1, float y1, float x2, float y2)
    {
        int row = Obsticals.findY(y1);
        int column = Obsticals.findX(x1);

        if (row < 0 || column < 0 || row > 13 || column > 14)
            return 1000; // return large number if move is out of range
        else if (!Obsticals.isObstical(row, column))
            return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2)); // return distance between points
        else
            return 1000; // return large number if move is an obstical
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
            {
                isBuying = true;
                GetComponent<Customer>().cd.isBuying = true;
            }
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
