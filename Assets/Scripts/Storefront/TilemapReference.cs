using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapReference : MonoBehaviour
{
    public Tilemap tilemap;
    public static Tilemap staticTilemap;

    // Use this for initialization
    void Start()
    {
        staticTilemap = tilemap;
    }
}