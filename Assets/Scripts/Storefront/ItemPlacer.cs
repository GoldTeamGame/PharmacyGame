﻿// File: ItemPlacer
// Version 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Handles placing items once an item is selected from the inventory

using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public static bool isPlacing = false;
    public Transform parent;
    public GameObject[] item;

	// Update is called once per frame
	void Update ()
    {
	    if (isPlacing)
        {
            //Debug.Log(item[0].name);
            //Debug.Log("Placing");
            //Vector3 tile;
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 tile = CoordinateTracker.getMousePosition();
                InsertItems.instantiateObject(PlaceItem.staticItem, parent, tile, new Quaternion(1, 1, 0, 0));
                Obsticals.addObstical(tile.x, tile.y, PlaceItem.staticItem.GetComponent<ItemData>().width, PlaceItem.staticItem.GetComponent<ItemData>().height, PlaceItem.staticItem.GetComponent<ItemData>().rowOffset, PlaceItem.staticItem.GetComponent<ItemData>().columnOffset);
                Obsticals.displayAllObsticals();
            }
            //isPlacing = false;
        }
	}
}
