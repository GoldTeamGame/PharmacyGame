// File: StoreItems
// Version: 1.0.2
// Last Updated: 3/1/19
// Authors: Ross Burnworth, Alexander Jacks
// Description: Contains all a StoreItem information

[System.Serializable]
public class StoreItems
{
    public string name;
    public int appearance;

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate
    public float rotationZ;

    public StoreItems( float locationX, float locationY, float rotationZ)
    {
        this.locationX = locationX;
        this.locationY = locationY;
        this.rotationZ = rotationZ;

    }
    public StoreItems()
    {

    }
}
