// File: CustomerController
// Version: 1.0.4
// Last Updated: 2/25/19
// Authors: Alexander Jacks
// Description: Tells customer when and where to move

using UnityEngine;

public class CustomerController : MonoBehaviour
{
    PriorityQueue pq;
    public float speed;
    public MoveSet ms;
    public Queue<int> moveQ; // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
    public int limit = 20; // "Desire Capacity"
    public int currentAmount = 0; // Number is increased each move. When currentAmmount reaches limit, reset currentAmount and remove a desire
    public bool isBuying;
    public bool isLeaving;
    public bool isFinding;

	void Start ()
    {
        // Instantiate MoveSet using info saved in CustomerData
        ms = new MoveSet(transform, speed, GetComponent<Customer>().cd.isMoving, GetComponent<Customer>().cd.destLocationX, GetComponent<Customer>().cd.destLocationY);
        moveQ = new Queue<int>(100);
        isBuying = GetComponent<Customer>().cd.isBuying;
        isLeaving = GetComponent<Customer>().cd.isLeaving;
        isFinding = GetComponent<Customer>().cd.isFinding;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // If customer is not moving, then customer thinks of what it wants to do
        if (ms.isMoving == -1)
        {
            think();
            ms.setMove(moveQ.peek(), ref moveQ);

            updateDesire(ms.distance);

            // Save moveLocation and isMoving state into CustomerData
            gameObject.GetComponent<Customer>().cd.destLocationX = ms.moveLocation.x;
            gameObject.GetComponent<Customer>().cd.destLocationY = ms.moveLocation.y;
            gameObject.GetComponent<Customer>().cd.isMoving = ms.isMoving;
        }
        else
            ms.move();
    }

    // Customer sets its move according to its current state
    void think()
    {
        // Find the counter if the customer is ready to buy
        if (isBuying)
        {
            // Locate path to counter after finishing cuurent moves
            if (moveQ.isEmpty() && !isFinding)
            {
                aStar(0.5f, -0.5f);
                isFinding = true;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }

            // Change states once counter is reached
            if (moveQ.isEmpty() && isFinding)
            {
                isLeaving = true;
                isBuying = false;
                GetComponent<Customer>().cd.isLeaving = true;
                GetComponent<Customer>().cd.isBuying = false;
                Globals.setGold(Globals.getGold() + Random.Range(1, 3));
                isFinding = false;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }
        }
        // Find the exit if the customer is ready to leave
        else if (isLeaving)
        {
            if (!isFinding)
            {
                aStar(-1.5f, 6f);
                isFinding = true;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }

            if (moveQ.isEmpty())
            {
                removeCustomer();
                isFinding = false;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }
        }
        // Move in a random direction and update desires if not buying or leaving
        else
        {
            // Set direction and distance
            int direction = Random.Range(0, 7);
            int distance = Random.Range(1, 10);

            moveQ.enqueue(direction, distance);
        }
    }

    // Customer will find its way to [x, y]
    public void aStar(float x, float y)
    {
        pq = new PriorityQueue(10000); // reset priority queue

        // Generate a 2D float array to prevent duplicate entries into the queue
        float[][] check = new float[14][];
        for (int i = 0; i < check.Length; i++)
        {
            check[i] = new float[15];
            for (int j = 0; j < check[0].Length; j++)
            {
                check[i][j] = 1000;
            }
        }

        // Set first move
        float currentX = transform.localPosition.x; // x-coordinate of customers current location
        float currentY = transform.localPosition.y; // y-coordinate of customers current location
        int row = Obsticals.yToRow(currentY); // convert y to row value
        int column = Obsticals.xToColumn(currentX); // convert x to column value
        Move currentMove = new Move(currentX, currentY, 0, findDistance(currentX, currentY, x, y, row, column), 0, null);

        // Keep searching for path until destination is found
        while(currentMove != null && (currentMove.x != x || currentMove.y != y))
        {
            // Enqueue every movement direction
            // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
            checkMove(currentMove, 0.5f,    0,      x, y, 0, ref check); // right
            checkMove(currentMove, 0.5f,    0.5f,   x, y, 4, ref check); // upright
            checkMove(currentMove, 0.5f,    -0.5f,  x, y, 6, ref check); // downright
            checkMove(currentMove, 0,       0.5f,   x, y, 2, ref check); // up
            checkMove(currentMove, -0.5f,   0.5f,   x, y, 5, ref check); // upleft
            checkMove(currentMove, 0, -     0.5f,   x, y, 3, ref check); // down
            checkMove(currentMove, -0.5f,   0,      x, y, 1, ref check); // left
            checkMove(currentMove, -0.5f,   -0.5f,  x, y, 7, ref check); // downleft

            currentMove = pq.peekAndDequeue(); // Set the first item in the queue as the currentMove
        }

        addMoves(currentMove); // Add moves to movement queue
        //currentMove.displayMoves();
        //Debug.Break();
    }

    // (USED FOR A*)
    // Checks to see if a move is valid and then places it into the priority queue
    private void checkMove(Move move, float xShift, float yShift, float xDest, float yDest, int direction, ref float[][] check)
    {
        // Calculate what x and y will be after the move
        float x = move.x + xShift;
        float y = move.y + yShift;

        // Obtain row and column values
        // (translate coordinate positions to array positions)
        int row = Obsticals.yToRow(y);
        int column = Obsticals.xToColumn(x);

        // Check is move is within the bounds of the tilemap
        if (Obsticals.isInBounds(row, column))
        {
            // Prepare side/diagonal Distances
            // (Used for the A* heuristic. Diagonal travel is more costly than side travel)
            float sideDistance = move.distanceTraveled + 0.15f;
            float diagonalDistance = move.distanceTraveled + 0.25f;

            // If direction is greater than 3, then a diagonal move is being made
            // Only add move to queue if the distanceTraveled is smaller than what is in the check array
            // (If distanceTraveled is larger than what is in the check array, then that means a better path to that spot already exists)
            if (direction > 3 && diagonalDistance < check[row][column])
            {
                pq.enqueue(new Move(x, y, move.distanceTraveled + .25f, findDistance(x, y, xDest, yDest, row, column), direction, move));
                check[row][column] = diagonalDistance;
            }
            // If direction is less than or equal to 3, then a side move is being made (up/down/left/right)
            else if (direction <= 3 && sideDistance < check[row][column])
            {
                pq.enqueue(new Move(x, y, move.distanceTraveled + .15f, findDistance(x, y, xDest, yDest, row, column), direction, move));
                check[row][column] = sideDistance;
            }
        }
    }

    // move holds a coordinate location as well as every previous move that took to reach the current move
    // Because this is in reverse order, the function adds all moves to a stack
    // so that all moves can be added to the movement queue
    private void addMoves(Move move)
    {
        Stack<Move> moves = new Stack<Move>(100); // instantiate stack

        // Continue adding moves to stack until there are no moves remaining
        while(move != null && move.previousMove != null)
        {
            moves.push(move);
            move = move.previousMove;
        }

        // Enqueue all moves in the stack
        int length = moves.size;
        for (int i = 0; i < length; i++)
        {
            moveQ.enqueue(moves.peekAndPop().direction);
        }
    }

    // Find the distance between 2 coordinates
    // returns 1000 (or some large number) if the object at the location is an obstical
    private float findDistance(float x1, float y1, float x2, float y2, int row, int column)
    {
        if (Obsticals.isObstical(row, column))
            return 1000; // return large number if obstical is found
        else
            return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2)); // return distance between points
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
