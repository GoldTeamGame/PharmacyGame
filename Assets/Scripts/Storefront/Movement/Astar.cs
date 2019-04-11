using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    // Check if a path does not exists between [x1, y1] and [x2, y2]
    public static bool findPath(ref Path path, float x1, float y1, float x2, float y2)
    {
        Node previousNode = null;
        if (path != null && path.current() != null && path.current().previous != null)
            previousNode = path.current().previous;

        path = new Path(x2, y2);

        if (previousNode != null)
            path.path[0].previous = previousNode;

        PriorityQueue pq = new PriorityQueue(1000); // Instantiate Priority Queue

        // Generate a 2D float array to prevent duplicate entries into the queue
        float[][] check = new float[14][];
        for (int i = 0; i < check.Length; i++)
        {
            check[i] = new float[15];
            for (int j = 0; j < check[0].Length; j++)
            {
                check[i][j] = 1000;
            }
        }

        int row = Obsticals.yToRow(y1); // convert y to row value
        int column = Obsticals.xToColumn(x1); // convert x to column value
        Node node = new Node(new Position(x1, y1), findDistance(x1, y1, x2, y2, row, column));
        path.Add(node);
        //Move currentMove = new Move(x1, y1, 0, findDistance(x1, y1, x2, y2, row, column), 0, null);
        float md = TileCalculator.TILE_DIMENSIONS; // (Move distance) used to make code prettier

        // Keep searching for path until destination is found
        while (node != null && node.goodness < 1000 && (node.position.x != x2 || node.position.y != y2))
        {
            // Enqueue every movement direction
            // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft
            checkMove(ref pq, node,  md,   0, x2, y2, node.distanceTraveled + .15f, 0, ref check); // right
            checkMove(ref pq, node, -md,   0, x2, y2, node.distanceTraveled + .15f, 1, ref check); // left
            checkMove(ref pq, node,   0,  md, x2, y2, node.distanceTraveled + .15f, 2, ref check); // up
            checkMove(ref pq, node,   0, -md, x2, y2, node.distanceTraveled + .15f, 3, ref check); // down
            checkMove(ref pq, node,  md,  md, x2, y2, node.distanceTraveled + .25f, 4, ref check); // right-up
            checkMove(ref pq, node, -md,  md, x2, y2, node.distanceTraveled + .25f, 5, ref check); // left-up
            checkMove(ref pq, node,  md, -md, x2, y2, node.distanceTraveled + .25f, 6, ref check); // right-down
            checkMove(ref pq, node, -md, -md, x2, y2, node.distanceTraveled + .25f, 7, ref check); // left-down

            node = pq.peekAndDequeue(); // Set the first item in the queue as the currentMove
        }

        addMoves(ref path, node);
        
        return node != null && node.position.x == x2 && node.position.y == y2;
    }

    // (USED FOR A*)
    // Checks to see if a move is valid and then places it into the priority queue
    private static void checkMove(ref PriorityQueue pq, Node node, float xShift, float yShift, float xDest, float yDest, float distanceTraveled, int direction, ref float[][] check)
    {
        // Calculate what x and y will be after the move
        float x = node.position.x + xShift;
        float y = node.position.y + yShift;

        // Obtain row and column values
        // (translate coordinate positions to array positions)
        int row = Obsticals.yToRow(y);
        int column = Obsticals.xToColumn(x);

        // Check is move is within the bounds of the tilemap
        if (Obsticals.isInBounds(row, column))
        {
            // Distance between current position and destination
            float distance = findDistance(x, y, xDest, yDest, row, column);

            // If distance >= 1000, the move is invalid, so don't continue to add it to the queue
            if (distance < 1000)
            {
                // If direction is greater than 3, then a diagonal move is being made
                // Only add move to queue if the distanceTraveled is smaller than what is in the check array
                // (If distanceTraveled is larger than what is in the check array, then that means a better path to that spot already exists)
                if (distanceTraveled < check[row][column])
                {
                    pq.enqueue(new Node(new Position(x, y), node, distance, distanceTraveled, direction));
                    check[row][column] = distanceTraveled;
                }
            }
        }
    }

    // move holds a coordinate location as well as every previous move that took to reach the current move
    // Because this is in reverse order, the function adds all moves to a stack
    // so that all moves can be added to the movement queue
    private static void addMoves(ref Path path, Node node)
    {
        Stack<Node> nodes = new Stack<Node>(100); // instantiate stack

        // Continue adding moves to stack until there are no moves remaining
        while (node != null && node.previous != null)
        {
            nodes.push(node);
            node = node.previous;
        }

        // Enqueue all moves in the stack
        int length = nodes.size;
        for (int i = 0; i < length; i++)
        {
            path.Add(nodes.peekAndPop());
        }
    }

    // Find the distance between 2 coordinates
    // returns 1000 (or some large number) if the object at the location is an obstical
    private static float findDistance(float x1, float y1, float x2, float y2, int row, int column)
    {
        if (Obsticals.isObstical(row, column))
            return 1000; // return large number if obstical is found
        else
            return Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2)); // return distance between points
    }
}
