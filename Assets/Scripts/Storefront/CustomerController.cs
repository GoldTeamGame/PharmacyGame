// File: CustomerController
// Version: 1.0.8
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Tells customer when and where to move

using UnityEngine;

public class CustomerController : MonoBehaviour
{
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, 0.95f, 0.95f, -0.95f, -0.95f }; // values that help set moveLocation

    Path path;
    Vector3 moveLocation;
    int direction;
    PriorityQueue pq;
    public float speed;
    //public MoveSet ms;
    //public Queue<int> moveQ; // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
    public int limit = 20; // "Desire Capacity"
    public int currentAmount = 0; // Number is increased each move. When currentAmmount reaches limit, reset currentAmount and remove a desire
    public bool isBuying;
    public bool isLeaving;
    public bool isFinding;
    public int wallet = 0;

	void Start ()
    {
        // Instantiate MoveSet using info saved in CustomerData
        //ms = new MoveSet(transform, speed, GetComponent<Customer>().cd.isMoving, GetComponent<Customer>().cd.destLocationX, GetComponent<Customer>().cd.destLocationY);
        //moveQ = new Queue<int>(100);
        path = GetComponent<Customer>().cd.path;

        if (path == null)
        {
            path = new Path(-1.5f, 6);
            GetComponent<Customer>().cd.path = path;
        }
        isBuying = GetComponent<Customer>().cd.isBuying;
        isLeaving = GetComponent<Customer>().cd.isLeaving;
        isFinding = GetComponent<Customer>().cd.isFinding;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // If player has picked item up
        if (path.isMoving == -2)
        {
            // Only repath if customer is a significant distance away
            if (path.getDistance() > 12)
                Astar.findPath(ref path, moveLocation.x, moveLocation.y, path.destination.x, path.destination.y);

            path.isMoving = 1; // continue moving
        }
        // If player has placed item down
        else if (path.isMoving == -1)
        {
            if (isInObstical(transform.localPosition))
                teleport();

            path.isMoving = 0;
            checkPath();
        }
        // Set move to next node in path when 
        else if (path.isMoving == 0)
        {
            if (path.currentNode == path.path.Count)
                think();
            setMove();
        }
        else
            move(); // perform move

        //// isMoving == -2 means the customer must reset its path because an object was placed in the store.
        //if (GetComponent<Customer>().cd.isMoving == -2)
        //{
        //    moveQ.reset(); // Remove everything from queue

        //    GetComponent<Customer>().cd.pLocationX = transform.localPosition.x;
        //    GetComponent<Customer>().cd.pLocationY = transform.localPosition.y;

        //    if (isInObstical(transform.localPosition))
        //        teleport();

        //    ms.findNearestLocation(transform.localPosition.x, transform.localPosition.y, ref moveQ);
        //    gameObject.GetComponent<Customer>().cd.isMoving = ms.isMoving;
        //    gameObject.GetComponent<Customer>().cd.destLocationX = ms.moveLocation.x;
        //    gameObject.GetComponent<Customer>().cd.destLocationY = ms.moveLocation.y;

        //    if (isTrapped(ms.moveLocation))
        //    {
        //        teleport();
        //        GetComponent<Customer>().cd.isMoving = -2;
        //    }
        //    //Debug.Break();
            
        //    isFinding = false;
        //    GetComponent<Customer>().cd.isFinding = false;
        //}
        //// If customer is not moving, then customer thinks of what it wants to do
        //else if (path.isMoving == 0)
        //{
        //    setMove();

        //    updateDesire(4); // Periodically remove desire

        //    // Save moveLocation and isMoving state into CustomerData
        //    gameObject.GetComponent<Customer>().cd.destLocationX = moveLocation.x;
        //    gameObject.GetComponent<Customer>().cd.destLocationY = moveLocation.y;
        //    gameObject.GetComponent<Customer>().cd.isMoving = path.isMoving;
        //    gameObject.GetComponent<Customer>().cd.direction = direction;
        //}
        //else
        //    move();
    }

    // Customer sets its move according to its current state
    void think()
    {
        // Find the counter if the customer is ready to buy
        if (isBuying)
        {
            // Locate path to counter after finishing cuurent moves
            if (!isFinding)
            {
                Astar.findPath(ref path, transform.localPosition.x, transform.localPosition.y, 0.5f, -0.5f);
                isFinding = true;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }

            // Change states once counter is reached
            if (isFinding && transform.localPosition.Equals(new Vector3(0.5f, -0.5f)))
            {
                isLeaving = true;
                isBuying = false;
                GetComponent<Customer>().cd.isLeaving = true;
                GetComponent<Customer>().cd.isBuying = false;
                Globals.setGold(Globals.getGold() + wallet);
                wallet = 0;
                isFinding = false;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }
            else
                isFinding = false; // reset isFinding to false if customer hasnt found the destination
        }
        // Find the exit if the customer is ready to leave
        else if (isLeaving)
        {
            if (!isFinding)
            {
                Astar.findPath(ref path, transform.localPosition.x, transform.localPosition.y, -1.5f, 6f);
                isFinding = true;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }

            // Remove customer once they reach the exit
            if (transform.localPosition.Equals(new Vector3(-1.5f, 6f)))
            {
                removeCustomer();
                isFinding = false;
                GetComponent<Customer>().cd.isFinding = isFinding;
            }
            else
                isFinding = false; // reset isFinding to false if customer hasnt found the destination
        }
        // Move in a random direction and update desires if not buying or leaving
        else
        {
            // Set direction and distance
            //int direction = Random.Range(0, 7);
            //int distance = Random.Range(1, 10);

            // Continue generating random path until a valid path is found
            bool doesPathExist = false;

            do
            {
                float x = Mathf.Round(Random.Range(-3.5f, 3.5f) * 2) / 2;
                float y = Mathf.Round(Random.Range(-0.5f, 6) * 2) / 2;
                doesPathExist = Astar.findPath(ref path, transform.localPosition.x, transform.localPosition.y, x, y);
            } while (!doesPathExist) ;

            //moveQ.enqueue(direction, distance);
        }
    }

    //// Move customer
    //// It detects when the move should finish and finishes it
    //private void move()
    //{
    //    if (Vector3.Distance(moveLocation, transform.localPosition) <= 0.06f)
    //    {
    //        transform.localPosition = moveLocation;
    //        path.currentNode++;
    //        path.isMoving = 0;
    //    }
    //    else
    //    {
    //        Vector3 move = new Vector3(directionX[direction], directionY[direction], 0) * Time.deltaTime * 0.5f;
    //        transform.Translate(move);
    //    }
    //}

    //// Set move to the next location.
    //private void setMove()
    //{
    //    if (path.currentNode < path.path.Count)
    //    {
    //        moveLocation = new Vector3(path.current().position.x, path.current().position.y);
    //        direction = path.current().direction;
    //        path.isMoving = 1;
    //    }
    //}

    // Check if the customer is inside of a fixture
    private bool isInObstical(Vector3 location)
    {
        float x = Mathf.Round(location.x * 2) / 2;
        float y = Mathf.Round(location.y * 2) / 2;

        return Obsticals.isObstical(x, y);
    }

    // Check if the customer is isolated between fixtures
    //private bool isTrapped(Vector3 location)
    //{
    //    return Astar.findPath(ref path, location.x, location.y, -1.5f, 6);
    //}

    // Teleport the customer to a nearby "safe spot"
    //private void teleport()
    //{
    //    // Find nearest x and y location divisible by 0.5
    //    // This will be used as the origin point
    //    float x = Mathf.Round(transform.localPosition.x * 2) / 2;
    //    float y = Mathf.Round(transform.localPosition.y * 2) / 2;

    //    int jumpAmount = 1; // number of tiles away from customer
    //    float tileSize = 0.5f; // width/height of tile

    //    Vector3 newLocation = Vector3.zero;

    //    // Continue looking for a safe location
    //    while (jumpAmount < 50)
    //    {
    //        float jump = jumpAmount * tileSize; // calculate distance of jump

    //        newLocation = new Vector3(x + jump, y); // check right
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x - jump, y); // check left
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x, y + jump); // check up
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x, y - jump); // check down
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x + jump, y + jump); // check right-up
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x - jump, y + jump); // check left-up
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x - jump, y - jump); // check left-down
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        newLocation = new Vector3(x + jump, y - jump); // check right-down
    //        if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
    //            break;

    //        jumpAmount++;
    //    }

    //    // Report if teleport doesnt work and teleport customer to entrance
    //    if (jumpAmount == 50)
    //    {
    //        Debug.Log("Teleport Error");
    //        transform.localPosition = new Vector3(-1.5f, 6f);
    //    }

    //    transform.localPosition = newLocation; // teleport customer to safe location
    //}

    private void move()
    {
        if (Vector3.Distance(moveLocation, transform.localPosition) <= 0.06f)
        {
            transform.localPosition = moveLocation;
            path.currentNode++;
            path.isMoving = 0;
        }
        else
        {
            Vector3 move = new Vector3(directionX[direction], directionY[direction], 0) * Time.deltaTime * speed;
            transform.Translate(move);
        }
    }

    private void setMove()
    {
        if (path.currentNode < path.path.Count)
        {
            moveLocation = new Vector3(path.current().position.x, path.current().position.y);
            direction = path.current().direction;
            path.isMoving = 1;
        }
    }

    private bool isBlocked(ref int count)
    {
        bool isObsticalInPath = false;

        for (int i = path.currentNode; i < path.path.Count && !isObsticalInPath; i++, count++)
        {
            Position p = path.path[i].position;
            isObsticalInPath = Obsticals.isObstical(p.x, p.y);
        }

        return isObsticalInPath;
    }

    private void checkPath()
    {
        // Figure out if there is an obstical in the path
        int count = 0;
        bool isObsticalInPath = isBlocked(ref count);

        if (isObsticalInPath)
        {
            bool doesPathExist = true;
            // If count is 0, then obstical is directly in front of the customer's path
            // So teleport customer back a space
            if (count == 0)
            {
                Position position = path.current().previous.position; // find previous position to teleport back to

                // If previous location exists
                if (position != null)
                {
                    transform.localPosition = new Vector3(position.x, position.y); // teleport to position
                    moveLocation = transform.localPosition; // reset moveLocation
                }

                // Find new path from moveLocation
                doesPathExist = Astar.findPath(ref path, moveLocation.x, moveLocation.y, path.destination.x, path.destination.y);

                // If previous location did not exist before, it will exist now
                if (position == null)
                {
                    position = path.path[0].previous.position; // find previous position to teleport back to
                    transform.localPosition = new Vector3(position.x, position.y); // teleport to position
                }
            }
            else
            {
                Position position = path.current().position;
                moveLocation = new Vector3(position.x, position.y);
                doesPathExist = Astar.findPath(ref path, moveLocation.x, moveLocation.y, path.destination.x, path.destination.y);
                path.isMoving = 1;
            }

            if (!doesPathExist)
                teleportOutOfTrap();
        }
    }

    // Teleport the customer to a nearby "safe spot"
    private void teleport()
    {
        for (int i = path.currentNode; i < path.path.Count; i++)
            if (!Obsticals.isObstical(path.path[i].position.x, path.path[i].position.y))
            {
                transform.localPosition = new Vector3(path.path[i].position.x, path.path[i].position.y);
                path.currentNode = i;
                path.isMoving = 0;
                break;
            }
    }

    // When there is no way to reach destination, then teleport until a path is found
    private void teleportOutOfTrap()
    {
        // Find nearest x and y location divisible by 0.5
        // This will be used as the origin point
        float x = Mathf.Round(transform.localPosition.x * 2) / 2;
        float y = Mathf.Round(transform.localPosition.y * 2) / 2;

        int jumpAmount = 1; // number of tiles away from customer
        float tileSize = 0.5f; // width/height of tile

        Vector3 newLocation = Vector3.zero;

        // Continue looking for a safe location
        while (jumpAmount < 50)
        {
            float jump = jumpAmount * tileSize; // calculate distance of jump

            newLocation = new Vector3(x + jump, y); // check right
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x - jump, y); // check left
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x, y + jump); // check up
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x, y - jump); // check down
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x + jump, y + jump); // check right-up
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x - jump, y + jump); // check left-up
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x - jump, y - jump); // check left-down
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            newLocation = new Vector3(x + jump, y - jump); // check right-down
            if (Obsticals.isInBounds(newLocation) && !isTrapped(newLocation) && !isInObstical(newLocation))
                break;

            jumpAmount++;
        }

        // Report if teleport doesnt work and teleport customer to entrance
        if (jumpAmount == 50)
        {
            Debug.Log("Teleport Error");
            transform.localPosition = new Vector3(-1.5f, 6f);
        }
        else
            transform.localPosition = newLocation;
    }

    private bool isTrapped(Vector3 location)
    {
        return !Astar.findPath(ref path, location.x, location.y, path.destination.x, path.destination.y);
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
        for (int i = 0; i < numberOfCustomers; i++)
            Globals_Customer.customerData[i].path.isMoving = state;
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
