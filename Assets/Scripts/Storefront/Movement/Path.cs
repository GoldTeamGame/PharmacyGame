using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    List<Node> path;

    public Path()
    {
        path = new List<Node>();
    }

    public void Add(Node node)
    {
        path.Add(node);
    }

    public bool isObsticalInPath()
    {
        for (int i = 0; i < path.Count; i++)
            if (path[i].isObstical)
                return true;
        return false;
    }
}
