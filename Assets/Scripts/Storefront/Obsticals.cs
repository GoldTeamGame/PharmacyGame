// File: Obsticals
// Version: 1.0.2
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Stores all objects in storefront in a bool array. Allows customers to "see" obsticals and avoid them.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticals : MonoBehaviour {

    public static bool[][] obstical;

    // Use this for initialization
    void Start ()
    {
        obstical = new bool[14][];
        for (int i = 0; i < obstical.Length; i++)
            obstical[i] = new bool[15];

        //addObstical(1f, 1.5f, 3, 2, -1, -1);
        
    }

    // Add Object to obstical array. 
    // x and y are the coordinates that the object was placed at
    // width and height are how many spaces the object takes up
    // row and column offset are used to make the code more efficient (it is the starting point of the loops)
    public static void addObstical(float x, float y, int width, int height, int rowOffset, int columnOffset)
    {
        // Convert x and y to obstical array locations
        int row = findY(y) + rowOffset;
        int column = findX(x) + columnOffset;

        int heightLocation = row + height;
        int widthLocation = column + width;

        for (int i = row; i < heightLocation && i < obstical.Length; i++)
        {
            obstical[i][column] = true;
            for (int j = column; j < widthLocation && j < obstical[0].Length; j++)
                obstical[i][j] = true;
        }
    }

    public static bool isObstical(float locationX, float locationY)
    {
        int x = findX(locationX);
        int y = findY(locationY);

        //Debug.Log("Location: " + locationY + " " + locationX);
        //Debug.Log("Array: " + y + " " + x);
        return obstical[y][x];
    }

    public static bool isObstical(int row, int column)
    {
        return obstical[row][column];
    }

    public static int findX(float locationX)
    {
        return Mathf.Abs((int)((locationX + 3.5) / 0.5));
    }

    public static int findY(float locationY)
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
                  + " " + obstical[i][10] + " " + obstical[i][11] + " " + obstical[i][12] + " " + obstical[i][13]);
    }
}
