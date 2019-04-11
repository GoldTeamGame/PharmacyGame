// File: Obsticals
// Version: 1.0.5
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Stores all objects in storefront in a bool array. Allows customers to "see" obsticals and avoid them.
//          Also includes checking if locations are within allowed boundaries of the tilemap

using UnityEngine;
using UnityEngine.Tilemaps;

public class Obsticals : MonoBehaviour
{
    public Tilemap tilemap;
    public static bool[][] obstical;
    public static int numberOfRows;
    public static int numberOfColumns;
    
    // Use this for initialization
    void Awake()
    {
        // 15 x 14
        if (obstical == null)
        {
            obstical = new bool[tilemap.cellBounds.size.y * 2][];
            for (int i = 0; i < obstical.Length; i++)
                obstical[i] = new bool[tilemap.cellBounds.size.x * 2 - 1];
        }
    }

    // Add Object to obstical array. 
    // x and y are the coordinates that the object was placed at
    // width and height are how many spaces the object takes up
    // row and column offset are used to make the code more efficient (it is the starting point of the loops)
    public static void addObstical(float x, float y, int width, int height, int rowOffset, int columnOffset)
    {
        // Convert x and y to obstical array locations
        int row = yToRow(y) + rowOffset;
        int column = xToColumn(x) + columnOffset;

        int heightLocation = row + height;
        int widthLocation = column + width;

        if (row < 0)
            row = 0;
        if (column < 0)
            column = 0;

        for (int i = row; i < heightLocation && i < obstical.Length; i++)
            for (int j = column; j < widthLocation && j < obstical[0].Length; j++)
                obstical[i][j] = true;
    }

    public static bool isObstical(float x, float y)
    {
        int column = xToColumn(x);
        int row = yToRow(y);

        if (row >= obstical.Length || row < 0 || column >= obstical[0].Length || column < 0)
            return true;

        //Debug.Log("Location: " + locationY + " " + locationX);
        //Debug.Log("Array: " + y + " " + x);
        return obstical[row][column];
    }

    public static bool isObstical(int row, int column)
    {
        if (row >= obstical.Length || row < 0 || column >= obstical[0].Length || column < 0)
            return true;

        return obstical[row][column];
    }

    // Converts x to a 2D array column index
    // Returns -1 if coordinate is less than minimum value (-3.5)
    public static int xToColumn(float locationX)
    {
        if (locationX < -3.5f)
            return -1;

        return Mathf.Abs((int)((locationX + 3.5) / 0.5));
    }

    // Converts y to a 2D array row index
    // Returns -1 if coordinate is greater than maximum value (6)
    public static int yToRow(float locationY)
    {
        if (locationY > 6)
            return -1;

        return Mathf.Abs((int)((locationY - 6) / 0.5));
    }

    // Returns true if the row/column is within the bounds of the 2D array
    // (2D array size is based on the tilemap size)
    public static bool isInBounds(int row, int column)
    {
        return !(row < 0 || column < 0 || row > 13 || column > 14);
    }

    // Returns true if the row/column is within the bounds of the 2D array
    // (2D array size is based on the tilemap size)
    public static bool isInBounds(Vector3 coordinate)
    {
        int row = yToRow(coordinate.y);
        int column = xToColumn(coordinate.x);
        
        return !(row < 0 || column < 0 || row > 13 || column > 14);
    }

    // Checks if adding object will prevent customer from getting from entrance to counter
    public static bool willAddBlock(float x, float y, int width, int height, int rowOffset, int columnOffset)
    {
        // Copy obstical array into new array
        bool[][] tempObsticals = new bool[obstical.Length][];
        for (int i = 0; i < tempObsticals.Length; i++)
        {
            tempObsticals[i] = new bool[obstical[0].Length];
            for (int j = 0; j < tempObsticals[0].Length; j++)
                tempObsticals[i][j] = obstical[i][j];
        }

        // Add obstical to obstical array
        addObstical(x, y, width, height, rowOffset, columnOffset);

        // Plan a move from entrance to counter
        Path path = new Path(0.5f, -0.5f);
        bool isBlocked = !Astar.findPath(ref path, -1.5f, 6f, 0.5f, -0.5f);

        // Reset obstical array
        obstical = tempObsticals;

        return isBlocked;
    }

    public static void removeObstical(int index)
    {
        //Obsticals.addObstical(tile.x, tile.y, s.width, s.height, s.rowOffset, s.columnOffset); // Add item to obstical array
        for (int i = 0; i < obstical.Length; i++)
            for (int j = 0; j < obstical[0].Length; j++)
                obstical[i][j] = false;

        int numberOfItems = Globals_Items.storeData.Count;
        for (int i = 0; i < numberOfItems; i++)
        {
            if (i != index)
            {
                StoreItems s = Globals_Items.storeData[i];
                addObstical(s.locationX, s.locationY, s.width, s.height, s.rowOffset, s.columnOffset);
            }
        }
    }

    // Show text visualization of obsticals in bool array
    public static void displayAllObsticals()
    {
        Debug.Log("      0      1      2      3      4      5      6      7      8      9      10   11   12   13   14");
        for (int i = 0; i < obstical.Length; i++)
            Debug.Log(i + ": " + obstical[i][0] + " " + obstical[i][1] + " " + obstical[i][2] + " " + obstical[i][3] + " " + obstical[i][4]
                 + " " + obstical[i][5] + " " + obstical[i][6] + " " + obstical[i][7] + " " + obstical[i][8] + " " + obstical[i][9]
                  + " " + obstical[i][10] + " " + obstical[i][11] + " " + obstical[i][12] + " " + obstical[i][13] + " " + obstical[i][14]);
    }
}
