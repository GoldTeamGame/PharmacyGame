// File: TileCalculator
// Version: 1.0.1
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Converts coordinates into solid tile coordinates

using UnityEngine;

public class TileCalculator : MonoBehaviour {

    public const float tileDimensions = 0.5f;
    public static float modifier = 1.0f / tileDimensions;

    public static float nearestCoordinate(float f)
    {
        return Mathf.Round(f * modifier) / modifier;
    }

    public static float ceilCoordinate(float f)
    {
        return Mathf.Ceil(f * modifier) / modifier;
    }

    public static float floorCoordinate(float f)
    {
        return Mathf.Floor(f * modifier) / modifier;
    }
}
