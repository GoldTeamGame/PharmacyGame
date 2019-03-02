// File: Obsticals
// Version: 1.0.3
// Last Updated: 3/2/19
// Authors: Alexander Jacks
// Description: Stores all objects in storefront in a bool array. Allows customers to "see" obsticals and avoid them.

using UnityEngine;
using UnityEngine.Tilemaps;

public class Obsticals : MonoBehaviour
{
    public Tilemap tilemap;
    public static bool[][] obstical;
    public static int numberOfRows;
    public static int numberOfColumns;

    // Use this for initialization
    void Start ()
    {
        // 15 x 14
        obstical = new bool[tilemap.cellBounds.size.y * 2][];
        for (int i = 0; i < obstical.Length; i++)
            obstical[i] = new bool[tilemap.cellBounds.size.x * 2 - 1];

        Debug.Log(obstical[0].Length + " " + obstical.Length);
        //addObstical(1f, 1.5f, 3, 2, -1, -1);
        
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
        {
            obstical[i][column] = true;
            for (int j = column; j < widthLocation && j < obstical[0].Length; j++)
                obstical[i][j] = true;
        }
    }

    public static bool isObstical(float x, float y)
    {
        int column = xToColumn(x);
        int row = yToRow(y);

        //Debug.Log("Location: " + locationY + " " + locationX);
        //Debug.Log("Array: " + y + " " + x);
        return obstical[row][column];
    }

    public static bool isObstical(int row, int column)
    {
        return obstical[row][column];
    }

    public static int xToColumn(float locationX)
    {
        return Mathf.Abs((int)((locationX + 3.5) / 0.5));
    }

    public static int yToRow(float locationY)
    {
        return Mathf.Abs((int)((locationY - 6) / 0.5));
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
