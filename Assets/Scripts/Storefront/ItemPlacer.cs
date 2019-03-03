// File: ItemPlacer
// Version 1.0.2
// Last Updated: 3/1/19
// Authors: Alexander Jacks
// Description: Handles placing items once an item is selected from the inventory

using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public static bool isPlacing = false;
    public static int state = 0;

    public Transform parent;
    public GameObject[] item;
    public static GameObject current;
    public static Vector3 tile;

	// Update is called once per frame
	void Update ()
    {
	    if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = CoordinateTracker.getMousePosition();

                if (Obsticals.isInBounds(mouse))
                {
                    tile = mouse;
                    Destroy(current);
                    current = InsertItems.instantiateObject(PlaceItem.staticItem, parent, tile, new Quaternion(0, 0, 0, 0));
                    current.transform.eulerAngles = new Vector3(0, 0, state * -90);
                }
            }
        }
	}

    public void confirm()
    {
        //int numberOfRotations = PlaceItem.staticItem.GetComponent<ItemData>().width.Length;
        //if (state >)
        Obsticals.addObstical(tile.x, tile.y, PlaceItem.staticItem.GetComponent<ItemData>().width, PlaceItem.staticItem.GetComponent<ItemData>().height, PlaceItem.staticItem.GetComponent<ItemData>().rowOffset, PlaceItem.staticItem.GetComponent<ItemData>().columnOffset);
        Obsticals.displayAllObsticals();
        current = null;
    }

    public void rotate()
    {
        if (current != null)
        {
            Destroy(current);
            state++;
            if (state > 3)
                state = 0;
            current = InsertItems.instantiateObject(PlaceItem.staticItem, parent, current.transform.localPosition, new Quaternion(0, 0, 0, 0));
            current.transform.eulerAngles = new Vector3(0, 0, state * -90);
        }
    }

    public static void delete()
    {
        Destroy(current);
    }
}
