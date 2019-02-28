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

        obstical[5][5] = true;
        obstical[6][5] = true;

        obstical[7][5] = true;
        obstical[8][5] = true;

        obstical[9][5] = true;
        obstical[10][5] = true;
        
        obstical[9][8] = true;
        obstical[9][9] = true;

        obstical[9][10] = true;
        obstical[9][11] = true;
        obstical[9][12] = true;

        // Show text visualization of obsticals
        //for (int i = 0; i < obstical.Length; i++)
        //    Debug.Log(obstical[i][0] + " " + obstical[i][1] + " " + obstical[i][2] + " " + obstical[i][3] + " " + obstical[i][4]
        //         + " " + obstical[i][5] + " " + obstical[i][6] + " " + obstical[i][7] + " " + obstical[i][8] + " " + obstical[i][9]
        //          + " " + obstical[i][9] + " " + obstical[i][10] + " " + obstical[i][11] + " " + obstical[i][12] + " " + obstical[i][13]);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public static void addObstical()
    {

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
}
