// File: ItemPlacer
// Version 1.0.4
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Handles placing items once an item is selected from the inventory

using UnityEngine;
using UnityEngine.UI;

public class ItemPlacer : MonoBehaviour
{
    public static bool isPlacing = false; // start as not placing item
    public static bool isSelecting = false; // start as not selecting item
    public static int rotationState = 0; // (0 = normal, -90 = down, -180 = left, -270 = up)

    public Transform parent; // container that item will be placed in
    public static GameObject current; // current gameObject being manipulated
    public static Vector3 tile; // The current selected tile
    public bool isPlaceable = false;
    public static bool isPlaced = false;

    public Button[] button;

	// Update is called once per frame
	void Update ()
    {
	    if (isPlacing)
        {
            setButtonState(true);
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = CoordinateTracker.getMousePosition(); // Get tile selected

                // Place item in tile if selected tile is within the parent
                if (Obsticals.isInBounds(mouse) && !Obsticals.isObstical(mouse.x, mouse.y))
                {
                    tile = mouse; // set tile

                    // Spawn item or update its position
                    if (isPlaced)
                    {
                        current.transform.localPosition = tile;
                    }
                    //Destroy(current);
                    else
                    {
                        current = InsertItems.instantiateObject(PlaceItem.staticItem, parent, tile);
                        current.transform.eulerAngles = new Vector3(0, 0, rotationState * -90); // Set rotation
                        isPlaced = true;
                    }

                    StoreItems s = current.GetComponent<Items>().s; // grab item data script from gameObject

                    // Determine color of item depending on if it is in a valid spot or not
                    if (!Obsticals.willAddBlock(tile.x, tile.y, s.width, s.height, s.rowOffset, s.columnOffset) &&
                        !(mouse.x == -1.5f && mouse.y == 5.5) && Obsticals.yToRow(mouse.y) <= 11)
                    {
                        current.GetComponent<SpriteRenderer>().color = PlaceItem.color[1];
                        isPlaceable = true;
                    }
                    else
                    {
                        current.GetComponent<SpriteRenderer>().color = PlaceItem.color[2];
                        isPlaceable = false;
                    }
                }
            }
        }
        else if (isSelecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = CoordinateTracker.getMousePosition(); // Get tile selected

                // Place item in tile if selected tile is within the parent

                if (Obsticals.isInBounds(mouse))
                {
                    // Find Index position of selected item
                    int index = -1;
                    for (int i = 0; i < Globals_Items.storeData.Count; i++)
                    {
                        if (Globals_Items.storeData[i].isItem(mouse.x, mouse.y))
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index > -1)
                    {
                        Debug.Log(index);
                        current = Globals_Items.objects[index].gameObject;
                        Obsticals.removeObstical(index);
                        Globals_Items.storeData.RemoveAt(index);
                        Globals_Items.objects.RemoveAt(index);
                        PlaceItem.setColors(current);
                        CustomerController.repath();
                        current.GetComponent<SpriteRenderer>().color = PlaceItem.color[1];
                        isPlaceable = true;
                        isPlacing = true;
                        isSelecting = false;
                        isPlaced = true;
                    }
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

        if (isPlaceable)
        {
            setButtonState(false);
            current.GetComponent<SpriteRenderer>().color = PlaceItem.color[0]; // Set color back to original
            Obsticals.addObstical(tile.x, tile.y, s.width, s.height, s.rowOffset, s.columnOffset); // Add item to obstical array

            InsertItems.generate(current, s); // add s to Globals_Items.storeData

            CustomerController.repath();

            //Obsticals.displayAllObsticals(); // Debug: display obstical array

            current = null; // reset to null
            isPlaceable = false;
            isPlacing = false;
            PlaceItem.staticItem = null;
            isSelecting = true;
            isPlaced = false;
            PlaceItem.isExisting = true;
        }
    }

    // Button Function
    // Rotates item clockwise
    public void rotate(int direction)
    {
        // Do nothing if item hasn't been placed yet
        if (current != null)
        {
            // Cycle through rotationState
            rotationState += direction;
            if (rotationState > 3)
                rotationState = 0;
            if (rotationState < 0)
                rotationState = 3;

            // Rotate object 90 degrees
            current.transform.eulerAngles = new Vector3(0, 0, rotationState * -90);
        }
    }

    private void setButtonState(bool state)
    {
        float transparency = (state) ? 1 : 0.5f;

        for (int i = 0; i < button.Length; i++)
        {
            Color c = button[i].GetComponent<Image>().color;
            button[i].GetComponent<Image>().color = new Color(c.r, c.g, c.b, transparency);
            button[i].enabled = state;
        }
    }
    
    // Destroy gameObject
    public static void delete()
    {
        Destroy(current);
    }
}
