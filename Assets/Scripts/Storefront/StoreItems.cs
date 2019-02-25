// File: StoreItems
// Version: 1.0
// Last Updated: 2/21/19
// Authors: Ross Burnworth
// Description: Contains all a StoreItem information

using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StoreItems
{
    public int appearance;

    public float locationX; // x-coordinate
    public float locationY; // y-coordinate
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float rotationW;

    public StoreItems( float locationX, float locationY, float rotateX, float rotateY,float rotateZ, float rotateW)
    {
        this.locationX = locationX;
        this.locationY = locationY;
        this.rotationX = rotateX;
        this.rotationY = rotateY;
        this.rotationZ = rotateZ;
        this.rotationW = rotateW;

    }
    public StoreItems()
    {

    }
}
