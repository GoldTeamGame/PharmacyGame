// File: ItemPlacer
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
            Debug.Log(item[0].name);
            Debug.Log("Placing");
            InsertItems.instantiateObject(PlaceItem.staticItem, parent, new Vector3(1, 1.5f, 0), new Quaternion(1, 1, 0, 0));
            Obsticals.addObstical(1, 1.5f, PlaceItem.staticItem.GetComponent<ItemData>().width, PlaceItem.staticItem.GetComponent<ItemData>().height, PlaceItem.staticItem.GetComponent<ItemData>().rowOffset, PlaceItem.staticItem.GetComponent<ItemData>().columnOffset);
            Obsticals.displayAllObsticals();
            isPlacing = false;
        }
	}
}
