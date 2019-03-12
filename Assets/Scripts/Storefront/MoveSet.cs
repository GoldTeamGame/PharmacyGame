// File: MoveSet
// Version: 1.0.5
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Contains basic movement directions for customer

using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSet
{
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, 0.95f, 0.95f, -0.95f, -0.95f }; // values that help set moveLocation
    Tilemap tilemap; // the area the customer can explore
    Transform transform; // the current location of the customer
    public int isMoving; // number that changes depending on the direction customer is moving
    public Vector3 moveLocation; // the location of the next place the customer will move
    public Vector3 previousMoveLocation; // the place the customer is moving from;
    float speed; // the speed that a customer moves at
    public int distance; // how far the move took the customer
    
    public MoveSet(Transform transform, float speed, int isMoving, float xDest, float yDest)
    {
        this.isMoving = isMoving; // set saved isMoving state
        moveLocation = new Vector3(xDest, yDest, 0); // Set previous moveLocation

        // Set variables
        tilemap = TilemapReference.staticTilemap[0];
        this.transform = transform;
        this.speed = speed;

        int sizeX = tilemap.cellBounds.size.x - 1;
        int sizeY = tilemap.cellBounds.size.y;
    }

    // Evaluates moves stored in Queue and trims them down
    // TODO: combine searching for bounds and searching for obstical
    public void setMove(int command, ref Queue<int> moveQ)
    {
        previousMoveLocation = moveLocation;

        float numberOfMoves = 0;

        // Figure out how many consecutive movements of the same type are in the moveQ
        while (!moveQ.isEmpty() && moveQ.peek().Equals(command))
        {
            numberOfMoves += TileCalculator.TILE_DIMENSIONS;
            moveQ.dequeue();
        }

        isMoving = command; // set movement state

        // Find where the customer will end up after moving.
        moveLocation = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]), 
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
        
        // Remove a move if the moveLocation is out of bounds
        while (!isInBounds() && numberOfMoves > 0)
        {
            numberOfMoves -= TileCalculator.TILE_DIMENSIONS;
            moveLocation = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]),
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
        }

        // Trim move further if obstical is in path
        // Reset to thinking state if move is invalid
        if (cantMove(ref numberOfMoves))
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
        if (Vector3.Distance(moveLocation, transform.localPosition) <= 0.06f)
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

    // Figure out the isMoving state by calculating the distance of current x and y positions and moveLocation x and y positions.
    private int findDirection()
    {
        // Must adjust precision to prevent location errors (Sometimes localPosition might have a trailing 0.00001, an error caused by unity.
        //      so if moveLocation.x is 0.5, but localPosition.x is 0.50001, then the function will detect the move as being some sort of left move
        //      instead of being just an up or down move.
        float x = Toolbox.precisionConversion(transform.localPosition.x, 3);
        float y = Toolbox.precisionConversion(transform.localPosition.y, 3);

        // Calculate difference of moveLocation - localPosition (adjust the values so that they are always positive)
        float differenceX = (TilemapReference.xAdjust[0] + moveLocation.x) - (TilemapReference.xAdjust[0] + x);
        float differenceY = (TilemapReference.yAdjust[0] + moveLocation.y) - (TilemapReference.yAdjust[0] + y);

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
        // Right-Up
        if (differenceX > 0 && differenceY > 0)
            return 4;
        // Left-Up
        if (differenceX < 0 && differenceY > 0)
            return 5;
        // Right-Down
        if (differenceX > 0 && differenceY < 0)
            return 6;
        // Left-Down
        if (differenceX < 0 && differenceY < 0)
            return 7;
        return -1;
    }

    // Complete a single unit of movement in whatever direction customer was initially going in
    private Vector3 finishMove()
    {
        Vector3 m = transform.localPosition; // Save current location into m

        // Find 6 values based off of m (current location)
        float x     = TileCalculator.nearestCoordinate(m.x); // find nearest x-coordinate
        float y     = TileCalculator.nearestCoordinate(m.y); // find neareest y-coordinate
        float right = TileCalculator.ceilCoordinate(m.x);    // find what current x-coordinate will be after moving to the right
        float left  = TileCalculator.floorCoordinate(m.x);   // find what current x-coordinate will be after moving to the left
        float up    = TileCalculator.ceilCoordinate(m.y);    // find what current y-coordinate will be after moving up
        float down  = TileCalculator.floorCoordinate(m.y);   // find what current y-coordinate will be after moving down
        
        // Right
        if (isMoving == 0)
            return new Vector3(right, y, 0);
        // Left
        if (isMoving == 1)
            return new Vector3(left, y, 0);
        // Up
        if (isMoving == 2)
            return new Vector3(x, up, 0);
        // Down
        if (isMoving == 3)
            return new Vector3(x, down, 0);
        // Right-Up
        if (isMoving == 4)
            return new Vector3(right, up, 0);
        // Left-Up
        if (isMoving == 5)
            return new Vector3(left, up, 0);
        // Right-Down
        if (isMoving == 6)
            return new Vector3(right, down, 0);
        // Left-Down
        if (isMoving == 7)
            return new Vector3(left, down, 0);

        // Find closest tile if isMoving is none of the above
        return new Vector3(x, y, 0);
    }
    
    // Returns true if moveLocation is within the allowed bounds of the tilemap
    bool isInBounds()
    {
        return (moveLocation.x >= tilemap.cellBounds.xMin + TileCalculator.TILE_DIMENSIONS) && (moveLocation.x <= tilemap.cellBounds.xMax - TileCalculator.TILE_DIMENSIONS) && 
            (moveLocation.y <= tilemap.cellBounds.yMax) && (moveLocation.y >= tilemap.cellBounds.yMin + TileCalculator.TILE_DIMENSIONS);
    }

    // Check if there is an obstacle in the path
    // If there is, limit move to before obstical
    // Or change direction if there is no path
    bool cantMove(ref float originalNumberOfMoves)
    {
        // If destination is on top of an obstical, move cannot be made
        if (Obsticals.isObstical(moveLocation.x, moveLocation.y))
            return true;

        float numberOfMoves = 0;

        // Set tracker to player location
        Vector3 tracker = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);

        // Continue loop while tracker has not reached moveLocation
        // Example Iteration...
        // Iteration: 1st iteration (1 move)
        // tracker (current location) = [2, 3.5]
        // isMoving = 1 (moving left)
        // directionX[1] = -1; (from global parameters)
        // directionY[1] =  0; (from global parameters)
        // xMove = (2   + (0.5 * -1)) = (2 - 0.5) = 1.5
        // yMove = (3.5 + (0.5 *  0)) = (3.5 + 0) = 3.5
        // if [1.5, 3.5] is not an obstical, then set tracker to [1.5, 3.5]
        while (!tracker.Equals(moveLocation))
        {
            // Simulate a move in whichever direction isMoving state is set to
            numberOfMoves += 0.5f;
            float xMove = transform.localPosition.x + numberOfMoves * directionX[isMoving];
            float yMove = transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]);

            // Set tracker to new location if it isn't an obstical
            if (!Obsticals.isObstical(xMove, yMove))
                tracker = new Vector3(xMove, yMove, 0);
            else
            {
                // Set moveLocation to tracker from previous iteration if new tracker was an obstical
                // and then exit loop
                moveLocation = tracker;
                break;
            }
        }

        originalNumberOfMoves = numberOfMoves; // Update numberOfMoves from calling function

        // If tracker is still the same as localPosition, then no move can be made
        return tracker.Equals(transform.localPosition);
    }
}
