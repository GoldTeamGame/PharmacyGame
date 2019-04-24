// File: ItemPlacer
// Version 1.0.5
// Last Updated: 3/13/19
// Authors: Alexander Jacks
// Description: Handles placing items once an item is selected from the inventory

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemPlacer : MonoBehaviour
{
    public static bool isPlacing = false; // state is true when player is trying to place an item on storefront
    public static bool isValidPlacement = false; // state is true when item is in a valid location to be placed
    public static bool isSelecting = false; // state is true when the player can select an item

    public static int rotationState = 0; // (0 = normal, -90 = down, -180 = left, -270 = up)

    public Transform parent; // container that item will be placed in
    public static GameObject current; // current gameObject being manipulated
    public Vector3 tile; // The current selected tile
    
    public Button[] button; // Holds all buttons on the inventory UI

	// Update is called once per frame
	void Update ()
    {
        if (isPlacing)
        {
            // Spawn item at entrance (space is guarrenteed to be available)
            if (PlaceItem.needsPlacing)
            {
                current = InsertItems.instantiateObject(PlaceItem.staticItem, parent, new Vector3(-1.5f, 5.5f)); // spawn item at entrance
                current.transform.eulerAngles = new Vector3(0, 0, rotationState * -90); // Set rotation
                current.GetComponent<SpriteRenderer>().color = PlaceItem.color[2]; // set color to invalid
                isValidPlacement = false; // set placement state to false
                PlaceItem.needsPlacing = false; // item has been spawned, so this if-statement will not be accessed until a new
                                                // item is selected from inventory list 
            }

            setButtonState(true);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = CoordinateTracker.getMousePosition(); // Get tile selected

                // Place item in tile if selected tile is within the parent
                if (Obsticals.isInBounds(mouse) && !Obsticals.isObstical(mouse.x, mouse.y))
                {
                    tile = mouse; // set tile

                    // Move gameObject to location
                    current.transform.localPosition = tile;

                    StoreItems s = current.GetComponent<Items>().s; // grab item data script from gameObject

                    // Determine color of item depending on if it is in a valid spot or not
                    if (!Obsticals.willAddBlock(tile.x, tile.y, s.width, s.height, s.rowOffset, s.columnOffset) &&
                        !(mouse.x == -1.5f && mouse.y == 5.5) && Obsticals.yToRow(mouse.y) <= 11)
                    {
                        current.GetComponent<SpriteRenderer>().color = PlaceItem.color[1];
                        isValidPlacement = true;
                    }
                    else
                    {
                        current.GetComponent<SpriteRenderer>().color = PlaceItem.color[2];
                        isValidPlacement = false;
                    }
                }
            }
        }
        else if (isSelecting && Globals_Tutorials.tutorialIndex != 11 && Globals_Tutorials.tutorialIndex != 14)
        {
            setButtonState(false);
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

                    // "Select" the object if an item was selected
                    // (Index will remain -1 no item was selected)
                    if (index > -1)
                    {
                        current = Globals_Items.objects[index].gameObject; // Set current to selected gameObject

                        // Remove gameObject and data from lists and obstical array
                        Obsticals.removeObstical(index);
                        Globals_Items.storeData.RemoveAt(index);
                        Globals_Items.objects.RemoveAt(index);
                        
                        CustomerController.repath(-2); // tell customers to plan new paths now that an obstical has been removed

                        PlaceItem.setColors(current); // set the color array values for current
                        current.GetComponent<SpriteRenderer>().color = PlaceItem.color[1]; // set current color state to transparent

                        setInteractionState(true, false); // change state to "Placing"
                    }
                }
            }
        }
        else
            setButtonState(false);
	}

    // Button function
    // Confirms item placement by adding it to the obstical array
    //      and then adding its data to Globals_Items.storeData via InsertItems.generate
    public void confirm()
    {
        // Store items obstical data into the obsticals array
        StoreItems s = current.GetComponent<Items>().s; // grab item data script from gameObject

        if (isValidPlacement)
        {
            if (Globals_Tutorials.tutorialIndex == 10 || Globals_Tutorials.tutorialIndex == 13)
            {
                Globals_Tutorials.tutorialIndex++;
                TutorialMonitor.isPopup = true;
            }

            setButtonState(false);
            current.GetComponent<SpriteRenderer>().color = PlaceItem.color[0]; // Set color back to original
            Obsticals.addObstical(current.transform.localPosition.x, current.transform.localPosition.y, s.width, s.height, s.rowOffset, s.columnOffset); // Add item to obstical array

            InsertItems.generate(current, s); // add s to Globals_Items.storeData
            
            CustomerController.repath(-1);

            //Obsticals.displayAllObsticals(); // Debug: display obstical array

            current = null; // reset to null
            PlaceItem.staticItem = null;

            setInteractionState(false, true); // Change state to "Selecting"
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

    // Activate buttons when set to true
    // De-activates buttons when set to false
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

    // True, False = "Placement" State (Player can move item around in storefront)
    // False, True = "Selecting" State (Player can pick item up in storefront)
    // False, False = "null" state (Interaction with storefront is no longer permitted)
    public static void setInteractionState(bool placementState, bool selectionState)
    {
        isPlacing = placementState;
        isValidPlacement = placementState;
        
        isSelecting = selectionState;
    }
    
    public void removeItem()
    {
        Destroy(current); // remove gameObject from storefront

        // Set current selected object to null
        current = null;
        PlaceItem.staticItem = null;

        setInteractionState(false, true); // change state to "Selecting"
        setButtonState(false); // deactivate buttons
    }

    // Destroy gameObject
    public static void delete()
    {
        Destroy(current);
    }
}
