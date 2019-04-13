using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    // Check if a path does not exists between [x1, y1] and [x2, y2]
    // NOTE: Precision path finding (finding path to a destination whose x and/or y coordinate(s) is not divisible by 0.5) may not consistently
    //      work for diagonal movements, but it is currently not necessary to fix this.
    public static bool findPath(ref Path path, float x1, float y1, float x2, float y2)
    {
        Path newPath = new Path(x2, y2);
        PriorityQueue pq = new PriorityQueue(1000); // Instantiate Priority Queue

        // Initialize variables
        int dir = 0;
        float updateX1, updateY1, updateX2, updateY2;
        updateX1 = updateY1 = updateX2 = updateY2 = 0;
        
        // Append update coordinates (for starting/ending positions that aren't divisble by md (0.5))
        appendCoordinates(x1, y1, x2, y2, ref updateX1, ref updateY1, ref updateX2, ref updateY2, ref dir);

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

        // Set first node and add it to the newPath
        int row = Obsticals.yToRow(updateY1); // convert y to row value
        int column = Obsticals.xToColumn(updateX1); // convert x to column value
        Node node = new Node(new Position(updateX1, updateY1), findDistance(updateX1, updateY1, updateX2, updateY2, row, column));
        node.direction = dir;
        newPath.Add(node);
        
        float md = TileCalculator.TILE_DIMENSIONS; // (Move distance) used to make code prettier

        // Keep searching for path until destination is found
        while (node != null && node.goodness < 1000 && (node.position.x != updateX2 || node.position.y != updateY2))
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
        
        bool doesPathExist = node != null && node.position.x == updateX2 && node.position.y == updateY2; // check if path exists

        // Replace old path with new path if path exists
        if (doesPathExist)
        {
            addMoves(ref newPath, node); // generate newPath ArrayList

            // Append path by changing destination back to original destination
            newPath.path[newPath.path.Count - 1].position.x = x2;
            newPath.path[newPath.path.Count - 1].position.y = y2;
            path = newPath;
        }
        
        return doesPathExist;
    }

    private static void appendCoordinates(float x1, float y1, float x2, float y2, ref float updateX1, ref float updateY1, ref float updateX2, ref float updateY2, ref int dir)
    {
        // Check if x1/y1 or x2/y2 are divisible by 0.5
        updateX1 = float.Parse(x1.ToString());
        updateY1 = float.Parse(y1.ToString());

        if (updateX1 % 0.5 != 0)
        {
            float difference = x2 - updateX1;
            if (difference > 0)
            {
                // round up
                updateX1 = Mathf.Ceil(updateX1 * 2) / 2;
                dir = 0;
            }
            else if (difference < 0)
            {
                // round down
                updateX1 = Mathf.Floor(updateX1 * 2) / 2;
                dir = 1;
            }
        }
        if (updateY1 % 0.5 != 0)
        {
            float difference = y2 - updateY1;
            if (difference > 0)
            {
                // round up
                updateY1 = Mathf.Ceil(updateY1 * 2) / 2;
                if (dir == 0)
                    dir = 4;
                else if (dir == 1)
                    dir = 5;
                else
                    dir = 2;
            }
            else if (difference < 0)
            {
                // round down
                updateY1 = Mathf.Floor(updateY1 * 2) / 2;
                if (dir == 0)
                    dir = 6;
                else if (dir == 1)
                    dir = 7;
                else
                    dir = 3;
            }
        }

        // Update x2 and y2
        updateX2 = float.Parse(x2.ToString());
        updateY2 = float.Parse(y2.ToString());

        if (updateX2 % 0.5f != 0)
            updateX2 = Mathf.Round(updateX2 * 2) / 2;
        if (updateY2 % 0.5f != 0)
            updateY2 = Mathf.Round(updateY2 * 2) / 2;
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
