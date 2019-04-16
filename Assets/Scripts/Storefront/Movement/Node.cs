// File: Node
// Description: A Node within a path

[System.Serializable]
public class Node
{
    public Position position;
    public Node previous;
    
    public float distance; // how far move is from destination
    public float distanceTraveled; // distance currently traveled
    public float goodness; // how "good" the move is

    public int direction;

    public Node(Position position, float distance)
    {
        this.position = position;
        this.distance = distance;
    }

    public Node(Position position, float distance, int direction)
    {
        this.position = position;
        this.distance = distance;
        this.direction = direction;
    }

    public Node(Position position, Node previous, float distance, float distanceTraveled, int direction)
    {
        this.position = position;
        this.previous = previous;

        this.distance = distance;
        this.distanceTraveled = distanceTraveled;
        goodness = (distance + distanceTraveled);

        this.direction = direction;
    }
}
