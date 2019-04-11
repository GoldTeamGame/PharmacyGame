using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, 0.95f, 0.95f, -0.95f, -0.95f }; // values that help set moveLocation

    static Path path;
    Vector3 moveLocation;
    int direction;

    private void Start()
    {
        Astar.findPath(ref path, transform.localPosition.x, transform.localPosition.y, -2, 4.5f);
        path.currentNode = 0;
        moveLocation = new Vector3(path.current().position.x, path.current().position.y);
        direction = path.current().direction;
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
            setMove();
        else
            move(); // perform move
	}

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
            Vector3 move = new Vector3(directionX[direction], directionY[direction], 0) * Time.deltaTime * 0.2f;
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

    //// state == -2 is for when player picks an item up
    //// state == -1 is for when player places an item down
    //public static void repath(int state)
    //{
    //    path.isMoving = state;
    //}

    // Check if the customer is inside of a fixture
    private bool isInObstical(Vector3 location)
    {
        float x = Mathf.Round(location.x * 2) / 2;
        float y = Mathf.Round(location.y * 2) / 2;

        return Obsticals.isObstical(x, y);
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
}
