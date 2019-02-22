// File: StoreItems
// Version: 1.0
// Last Updated: 2/21/19
// Authors: Ross Burnworth
// Description: Contains all a StoreItem information

[System.Serializable]
public class StoreItems
{
    public int appearance;

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate

    public StoreItems( float locationX, float locationY)
    {
        this.locationX = locationX;
        this.locationY = locationY;
    }
    public StoreItems()
    {

    }
}
