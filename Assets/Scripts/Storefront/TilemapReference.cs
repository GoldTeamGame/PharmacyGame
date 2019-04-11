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
    public Tilemap[] tilemap;
    public static Tilemap[] staticTilemap;
    public static float[] xAdjust;
    public static float[] yAdjust;

    // Use this for initialization
    void Awake()
    {
        staticTilemap = new Tilemap[tilemap.Length];
        xAdjust = new float[tilemap.Length];
        yAdjust = new float[tilemap.Length];

        for (int i = 0; i < tilemap.Length; i++)
        {
            staticTilemap[i] = tilemap[i];
            xAdjust[i] = Mathf.Abs(tilemap[i].cellBounds.xMin + TileCalculator.TILE_DIMENSIONS);
            yAdjust[i] = Mathf.Abs(tilemap[i].cellBounds.yMin + TileCalculator.TILE_DIMENSIONS);
        }
    }
}