// File: MoveSet
// Version: 1.0.4
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Contains basic movement directions for customer

using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSet
{
    private const float MOVE_DISTANCE = 0.5f; // the smallest unit of distance a customer can move
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, 0.95f, 0.95f, -0.95f, -0.95f }; // values that help set moveLocation
    Tilemap tilemap; // the area the customer can explore
    Transform transform; // the current location of the customer
    public int isMoving; // number that changes depending on the direction customer is moving
    public Vector3 moveLocation; // the location of the next place the customer will move
    public Vector3 previousMoveLocation; // the place the customer is moving from;
    float speed; // the speed that a customer moves at
    public int distance; // how far the move took the customer
    public bool isRedirecting;
    
    public MoveSet(Transform transform, float speed, int isMoving, float xDest, float yDest)
    {
        this.isMoving = isMoving; // set saved isMoving state
        moveLocation = new Vector3(xDest, yDest, 0); // Set previous moveLocation

        // Set variables
        tilemap = TilemapReference.staticTilemap;
        this.transform = transform;
        this.speed = speed;

        int sizeX = tilemap.cellBounds.size.x - 1;
        int sizeY = tilemap.cellBounds.size.y;
    }

    // Determines destination
    public void setMove(int command, ref Queue<int> moveQ)
    {
        previousMoveLocation = moveLocation;

        float numberOfMoves = 0;

        // Figure out how many consecutive movements of the same type are in the moveQ
        while (!moveQ.isEmpty() && moveQ.peek().Equals(command))
        {
            numberOfMoves += MOVE_DISTANCE;
            moveQ.dequeue();
        }

        isMoving = command; // set movement state

        // Find where the customer will end up after moving.
        moveLocation = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]), 
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
        
        // Remove a move if the moveLocation is out of bounds
        while (!isInBounds() && numberOfMoves > 0)
        {
            numberOfMoves -= MOVE_DISTANCE;
            moveLocation = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]),
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
        }

        if (cantMove())
        {
            isMoving = -1;
            return;
        }

        distance = (int)(numberOfMoves * 2); // set how far customer moved
    }

    // Moves gameObject to destination
    public void move()
    {
        // Set customer movement state to stationary if it reached its location.
        if (Vector3.Distance(moveLocation, transform.localPosition) <= 0.1f)
        {
            isMoving = -1; // set to stationary
            transform.localPosition = moveLocation; // set customer position to moveLocation to keep customer on track
        }
        // Perform move.
        else
        {
            Vector3 move = new Vector3(directionX[isMoving], directionY[isMoving], 0) * Time.deltaTime * speed;
            transform.Translate(move);
        }
    }

    // Simulate completing a customer move in whatever direction they were headed in
    // If there isnt an obstical in the destination, then proceed
    // If there is, then backtrack
    public void findNearestLocation(float x, float y, ref Queue<int> moveQ)
    {
        // Figure out the direction the customer was traveling
        isMoving = findDirection();

        // Simulate move
        Vector3 move = finishMove();

        // Set move location if there isnt an obstical
        if (!Obsticals.isObstical(move.x, move.y))
            moveLocation = move;
        else
        {
            // Set moveLocation to previousMove and determine the isMoving state
            moveLocation = previousMoveLocation;
            isMoving = findDirection();
        }
    }

    // Complete a single unit of movement in whatever direction customer was initially going in
    public Vector3 finishMove()
    {
        Vector3 m = transform.localPosition;
        float x = Mathf.Round(m.x * 2) / 2;
        float y = Mathf.Round(m.y * 2) / 2;
        float right = Mathf.Ceil(m.x * 2) / 2;
        float left = Mathf.Floor(m.x * 2) / 2;
        float up = Mathf.Ceil(m.y * 2) / 2;
        float down = Mathf.Floor(m.y * 2) / 2;
        // Right
        if (isMoving == 0)
            return new Vector3(right, y, 0);
        // Left
        else if (isMoving == 1)
            return new Vector3(left, y, 0);
        // Up
        else if (isMoving == 2)
            return new Vector3(x, up, 0);
        // Down
        else if (isMoving == 3)
            return new Vector3(x, down, 0);
        // Upright
        else if (isMoving == 4)
            return new Vector3(right, up, 0);
        // Upleft
        else if (isMoving == 5)
            return new Vector3(left, up, 0);
        // Downright
        else if (isMoving == 6)
            return new Vector3(right, down, 0);
        // Downleft
        else if (isMoving == 7)
            return new Vector3(left, down, 0);
        // Find closest tile
        else
            return new Vector3(Mathf.Round(transform.localPosition.x * 2) / 2, Mathf.Round(transform.localPosition.y * 2) / 2, 0); // Move to nearest tile
    }

    private int findDirection()
    {
        // Must adjust precision to prevent location errors (Sometimes localPosition might have a trailing 0.00001, an error caused by unity.
        //      so if moveLocation.x is 0.5, but localPosition.x is 0.50001, then the function will detect the move as being some sort of left move
        //      instead of being just an up or down move.
        int transitionX = (int)(transform.localPosition.x * 1000);
        int transitionY = (int)(transform.localPosition.y * 1000);
        float x = transitionX / 1000f;
        float y = transitionY / 1000f;

        // Calculate difference of moveLocation - localPosition (adjust the values so that they are always positive)
        float differenceX = (3.5f + moveLocation.x) - (3.5f + x);
        float differenceY = (0.5f + moveLocation.y) - (0.5f + y);

        // Right
        if (differenceX > 0 && differenceY == 0)
            return 0;
        // Left
        if (differenceX < 0 && differenceY == 0)
            return 1;
        // Up
        if (differenceX == 0 && differenceY > 0)
            return 2;
        // Down
        if (differenceX == 0 && differenceY < 0)
            return 3;
        // Upright
        if (differenceX > 0 && differenceY > 0)
            return 4;
        // Upleft
        if (differenceX < 0 && differenceY > 0)
            return 5;
        // Downright
        if (differenceX > 0 && differenceY < 0)
            return 6;
        // Downleft
        if (differenceX < 0 && differenceY < 0)
            return 7;
        return -1;
    }

    bool isInBounds()
    {
        return (moveLocation.x >= tilemap.cellBounds.xMin + 0.5f) && (moveLocation.x <= tilemap.cellBounds.xMax - 0.5f) && 
            (moveLocation.y <= tilemap.cellBounds.yMax) && (moveLocation.y >= tilemap.cellBounds.yMin + 0.5f);
    }

    // Check if there is an obstacle in the path
    // If there is, limit move to before obstical
    // Or change direction if there is no path
    bool cantMove()
    {
        // transform.localposition = P
        // x = obsticals array
        // M = moveLocation
        // t = 

        if (Obsticals.isObstical(moveLocation.x, moveLocation.y))
            return true;

        float numberOfMoves = 0;

        // Set tracker to player location
        Vector3 tracker = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]),
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);

        while (!tracker.Equals(moveLocation))
        {
            numberOfMoves += 0.5f;

            if (!Obsticals.isObstical(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]), transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving])))
            {
                tracker = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]),
                    transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
            }
            else
            {
                moveLocation = tracker;
                break;
            }
        }

        return tracker.Equals(transform.localPosition);
    }
}
