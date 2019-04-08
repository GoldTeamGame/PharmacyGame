// File: Node
// Description: A Node within a path

public class Node
{
    public Position position;
    public Node next;
    public Node previous;
    
    public float distance; // how far move is from destination
    public float distanceTraveled; // distance currently traveled
    public float goodness; // how "good" the move is
    public int direction; // which direction was taken to get to the move

    public bool isObstical;

    public Node(Position position, float distance)
    {
        this.position = position;
        this.distance = distance;
    }

    public Node(Position position, Node next, Node previous, float distance, float distanceTraveled, float goodness, int direction, bool isObstical)
    {
        this.position = position;
        this.next = next;
        this.previous = previous;

        this.distance = distance;
        this.distanceTraveled = distanceTraveled;
        this.goodness = goodness;
        this.direction = direction;

        this.isObstical = isObstical;
    }
}
