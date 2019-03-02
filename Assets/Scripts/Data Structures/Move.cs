// File: Move
// Version: 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Holds a coordinate point and a goodness value (Used for A*)

public class Move
{
    public float x; // x-coordinate of move
    public float y; // y-coordinate of move
    public float distanceTraveled; // distance currently traveled
    public float distance; // how far move is from destination
    public float goodness; // how "good" the move is
    public int direction; // which direction was taken to get to the move
    public Move previousMove; // which move was before "this" move

    // Move constructor
    public Move(float x, float y, float distanceTraveled, float distance, int direction, Move previousMove)
    {
        this.x = x;
        this.y = y;
        this.distanceTraveled = distanceTraveled;
        this.distance = distance;
        this.direction = direction;
        this.previousMove = previousMove;

        goodness = (distance + distanceTraveled); // Calculate goodness based on distance remaining + distance currently traveled
    }

    // Display all moves up to "this"
    public void displayMoves()
    {
        Move current = this;
        DebugTool.Log("X: " + x + ", Y: " + y);

        current = previousMove;

        while (current != null)
        {
            DebugTool.Log("X: " + current.x + ", Y: " + current.y);
            current = current.previousMove;
        }
    }
}
