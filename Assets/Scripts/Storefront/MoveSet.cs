// File: MoveSet
// Version: 1.0.2
// Last Updated: 2/11/19
// Authors: Alexander Jacks
// Description: Contains basic movement directions for customer

using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSet
{
    private const float moveDistance = 0.5f; // the smallest unit of distance a customer can move
    private static float[] directionX = { 1, -1, 0, 0, 1, -1, 1, -1 }; // values that help set moveLocation
    private static float[] directionY = { 0, 0, 1, -1, .95f, .95f, -.95f, -.95f }; // values that help set moveLocation
    Tilemap tilemap; // the area the customer can explore
    Transform transform; // the current location of the customer
    public int isMoving; // number that changes depending on the direction customer is moving
    public Vector3 moveLocation; // the location of the next place the customer will move
    float speed; // the speed that a customer moves at

    // TODO: Add obsticals into isFilled array
    int xLocation;
    int yLocation;
    bool[][] isFilled;
    
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

        isFilled = new bool[sizeY][];
        for (int i = 0; i < sizeY; i++)
            isFilled[i] = new bool[sizeX];
    }

    // Determines destination
    public void setMove(int command, ref Queue<int> moveQ)
    {
        float numberOfMoves = 0;

        // Figure out how many consecutive movements of the same type are in the moveQ
        while (!moveQ.isEmpty() && moveQ.peek().Equals(command))
        {
            numberOfMoves += moveDistance;
            moveQ.dequeue();
        }

        isMoving = command; // set movement state

        // Find where the customer will end up after moving.
        moveLocation = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]), 
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
        
        // Remove a move if the moveLocation is out of bounds
        while (!isInBounds() && numberOfMoves > 0)
        {
            numberOfMoves -= 0.5f;
            moveLocation = new Vector3(transform.localPosition.x + numberOfMoves * Mathf.RoundToInt(directionX[isMoving]),
            transform.localPosition.y + numberOfMoves * Mathf.RoundToInt(directionY[isMoving]), 0);
        }
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

    bool isInBounds()
    {
        return (moveLocation.x >= tilemap.cellBounds.xMin + 0.5f) && (moveLocation.x <= tilemap.cellBounds.xMax - 0.5f) && 
            (moveLocation.y <= tilemap.cellBounds.yMax) && (moveLocation.y >= tilemap.cellBounds.yMin + 0.5f);
    }
}
