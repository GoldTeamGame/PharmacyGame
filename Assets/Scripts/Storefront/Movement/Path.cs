using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Path
{
    public List<Node> path;
    public Position destination;
    public int currentNode;
    public int isMoving;

    public Path(float x, float y)
    {
        path = new List<Node>();
        destination = new Position(x, y);
    }

    public Node current()
    {
        if (currentNode < path.Count)
            return path[currentNode];
        else
            return null;
    }

    // Returns distance remaining to destination
    public int getDistance()
    {
        return path.Count - currentNode;
    }
    public void Add(Node node)
    {
        path.Add(node);
    }

    public bool isObsticalInPath()
    {
        for (int i = 0; i < path.Count; i++)
            if (Obsticals.isObstical(path[i].position.x, path[i].position.y))
                return true;
        return false;
    }
}
