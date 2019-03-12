// File: TilemapReference
// Version: 1.0.2
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Takes in a tilemap from inspector and creates a static version that can be accessed anywhere.
//      It also contains various values that may be useful.
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapReference : MonoBehaviour
{
    public Tilemap tilemap;
    public static Tilemap staticTilemap;
    public static float xMin;
    public static float yMin;
    public static float xAdjust;
    public static float yAdjust;

    // Use this for initialization
    void Start()
    {
        staticTilemap = tilemap;
    }
}