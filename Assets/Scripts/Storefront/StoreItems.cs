// File: StoreItems
// Version: 1.0.2
// Last Updated: 3/1/19
// Authors: Ross Burnworth, Alexander Jacks
// Description: Contains all a StoreItem information

[System.Serializable]
public class StoreItems
{
    public string name;

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate
    public float rotationZ; // rotation (divisble by 90)

    /*      -------OFFSET-----
     * Explaination: Used for correcting where setting the obstical should start at in the obstical array.
     *      If rowOffset equals -1, it will shift the object up by 1. If columnOffset equals -1, it will shift the object left by 1.
     * 
     * Text Representation Examples: 0's are no obstical and 1's represent object. Object width equals 2 and height = 1. Object exists within a 4x4 obstical array.
     * 
     * rowOffset = 0, columnOffset = 0  *   rowOffset = -1, columnOffset = 0    *   rowOffset = 1, columnOffset = -1 
     *                                  *                                       *
     * |  0  |  0  |  0  |  0  |        *    |  0  |  1  |  1  |  0  |          *   |  0  |  0  |  0  |  0  |
     * |  0  |  1  |  1  |  0  |        *    |  0  |  0  |  0  |  0  |          *   |  0  |  0  |  0  |  0  |
     * |  0  |  0  |  0  |  0  |        *    |  0  |  0  |  0  |  0  |          *   |  1  |  1  |  0  |  0  |
     * |  0  |  0  |  0  |  0  |        *    |  0  |  0  |  0  |  0  |          *   |  0  |  0  |  0  |  0  |
     */

    // These 4 variables must be hardcoded and tailored to each individual item
    //      to account for the item's sprite's shape
    public int width; // width of object (used for obstical detection)
    public int height; // height of object (used for obstical detection)
    public int rowOffset; // shift left with - and right with +
    public int columnOffset; // shift up with - and down with +

    public bool isItem(float x, float y)
    {
        return (locationX == x && locationY == y);
    }
}
