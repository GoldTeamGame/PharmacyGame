// File: ItemPlacer
// Version 1.0.3
// Last Updated: 3/6/19
// Authors: Alexander Jacks
// Description: Handles placing items once an item is selected from the inventory

using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public static bool isPlacing = false; // start as not placing item
    public static int rotationState = 0; // (0 = normal, -90 = down, -180 = left, -270 = up)

    public Transform parent; // container that item will be placed in
    public static GameObject current; // current gameObject being manipulated
    public static Vector3 tile; // The current selected tile

	// Update is called once per frame
	void Update ()
    {
	    if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = CoordinateTracker.getMousePosition(); // Get tile selected

                // Place item in tile if selected tile is within the parent
                if (Obsticals.isInBounds(mouse) && !Obsticals.isObstical(mouse.x, mouse.y))
                {
                    tile = mouse; // set tile

                    // Replace existing gameObject with a new gameObject (in its new position)
                    Destroy(current);
                    current = InsertItems.instantiateObject(PlaceItem.staticItem, parent, tile);
                    current.transform.eulerAngles = new Vector3(0, 0, rotationState * -90); // Set rotation
                }
            }
        }
	}

    // Button function
    // Confirms item placement by adding it to the obstical array
    //      and then adding its data to Globals_Items.storeData via InsertItems.generate
    public void confirm()
    {
        // Store items obstical data into the obsticals array
        StoreItems s = current.GetComponent<Items>().s; // grab item data script from gameObject

        if (!Obsticals.willAddBlock(tile.x, tile.y, s.width, s.height, s.rowOffset, s.columnOffset))
        {
            Obsticals.addObstical(tile.x, tile.y, s.width, s.height, s.rowOffset, s.columnOffset); // Add item to obstical array
            InsertItems.generate(current, s); // add s to Globals_Items.storeData
            CustomerController.repath();

            //Obsticals.displayAllObsticals(); // Debug: display obstical array

            current = null; // reset to null
        }
    }

    // Button Function
    // Rotates item clockwise
    public void rotate()
    {
        // Do nothing if item hasn't been placed yet
        if (current != null)
        {
            // Cycle through rotationState
            rotationState++;
            if (rotationState > 3)
                rotationState = 0;

            // Rotate object 90 degrees
            current.transform.eulerAngles = new Vector3(0, 0, rotationState * -90);
        }
    }

    // Destroy gameObject
    public static void delete()
    {
        Destroy(current);
    }
}
