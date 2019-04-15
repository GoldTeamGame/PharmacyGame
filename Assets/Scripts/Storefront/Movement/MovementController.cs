using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, 0.95f, 0.95f, -0.95f, -0.95f }; // values that help set moveLocation

    public Path path; // The path the customer must take
    public Vector3 moveLocation; // The node the customer currently wants to reach
    public Vector3 moveDirection; // The direction customer moves in
    public float speed; // The speed at which the customer moves
    

    public MovementController()
    {
        path = new Path(-1.5f, 6);
    }

    public void setPath(float x1, float y1, float x2, float y2)
    {
        Astar.findPath(ref path, x1, y1, x2, y2);
    }

    public void setRandomPath()
    {
        // Continue generating random path until a valid path is found
        bool doesPathExist = false;
        int count = 0;
        do
        {
            float x = Mathf.Round(Random.Range(-3.5f, 3.5f) * 2) / 2;
            float y = Mathf.Round(Random.Range(-0.5f, 6) * 2) / 2;
            doesPathExist = Astar.findPath(ref path, transform.localPosition.x, transform.localPosition.y, x, y);
        } while (!doesPathExist && count++ < 20);

        if (count == 20)
            teleportOutOfTrap();
    }
    // Update is called once per frame
    public void performMove()
    {
        // If player has picked item up
        if (path.moveState == -2)
        {
            // Only repath if customer is a significant distance away
            if (path.getDistance() > 12)
                Astar.findPath(ref path, moveLocation.x, moveLocation.y, path.destination.x, path.destination.y);

            path.moveState = 1; // continue moving
        }
        // If player has placed item down
        else if (path.moveState == -1)
        {
            // Teleport customer if object was placed on top of it
            if (isInObstical(transform.localPosition))
                teleport();
            // Or repath if obstical is placed in path of customer
            else
                checkPath();
        }
        // Set move to next node in path when 
        else if (path.moveState == 0)
            setMove();
        else
            move(); // perform move
	}

    // Perform Movement
    private void move()
    {
        // Finish Move
        if (Vector3.Distance(moveLocation, transform.localPosition) <= 0.06f)
        {
            transform.localPosition = moveLocation; // Set position to moveLocation
            path.moveState = 0; // Change moveState
            path.currentNode++; // finish move by moving to the next node
        }
        // Move Customer
        else
        {
            //Vector3 move = new Vector3(directionX[path.currentDirection], directionY[path.currentDirection], 0) * Time.deltaTime * speed;

            transform.Translate(moveDirection);
        }
    }

    // Set the currentNode as the new move destination
    private void setMove()
    {
        // Only set move if nodes are available
        if (path.currentNode < path.path.Count)
        {
            //Debug.Log("Move Set: " + path.getCurrentNode().position.ToString());
            moveLocation = new Vector3(path.getCurrentNode().position.x, path.getCurrentNode().position.y); // Set moveLocation
            moveDirection = new Vector3(directionX[path.getCurrentNode().direction], directionY[path.getCurrentNode().direction]) * speed;
            path.moveState = 1; // Set moveState to moving
        }
    }

    // state == -2 is for when player picks an item up
    // state == -1 is for when player places an item down
    //public static void repath(int state)
    //{
    //    path.moveState = state;
    //}

    // Check if the customer is inside of a fixture
    private bool isInObstical(Vector3 location)
    {
        float x = Mathf.Round(location.x * 2) / 2;
        float y = Mathf.Round(location.y * 2) / 2;

        return Obsticals.isObstical(x, y);
    }

    // Check to see if the path needs to be updated and update it
    private void checkPath()
    {
        // Figure out if there is an obstical in the path
        bool isObsticalInPath = path.isObsticalInPath();

        // Change Paths if there is an obstical
        if (isObsticalInPath)
        {
            Position position = path.getCurrentNode().position; // Get position of node being traveled to

            // position is the location directly in front of the customer.
            // If it is an obstical, then teleport back a step and then repath
            if (Obsticals.isObstical(position.x, position.y))
            {
                position = path.getCurrentNode().previous.position;
                transform.localPosition = moveLocation = createVector(position);
            }
            if (Obsticals.isObstical(path.destination.x, path.destination.y))
            {
                path.destination.x = position.x;
                path.destination.y = position.y;
            }

            bool doesPathExist = Astar.findPath(ref path, position.x, position.y, path.destination.x, path.destination.y); // find new path

            // If path does not exist, then the customer is trapped, so teleport the customer out
            if (!doesPathExist)
            {
                teleportOutOfTrap();
                path.moveState = 0;
            }
            else
            {
                moveLocation = createVector(path.getCurrentNode().position);
                path.moveState = 1;
            }
        }
        else
            path.moveState = 1;
    }

    private static Vector3 createVector(Position position)
    {
        return new Vector3(position.x, position.y);
    }

    // Teleport the customer to a nearby "safe spot"
    private void teleport()
    {
        for (int i = path.currentNode; i < path.path.Count; i++)
            if (!Obsticals.isObstical(path.path[i].position.x, path.path[i].position.y))
            {
                transform.localPosition = new Vector3(path.path[i].position.x, path.path[i].position.y);
                path.currentNode = i;
                path.moveState = 0;
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
}
