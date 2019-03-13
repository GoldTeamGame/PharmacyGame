// File: PlaceItem
// Version: 1.0.3
// Last Updated: 3/13/19
// Authors: Alexander Jacks
// Description: Script placed on an inventory button which sends 
//      player to storefront to place the item corresponding to the button

using UnityEngine;

public class PlaceItem : MonoBehaviour {

    public static GameObject staticItem = null;
    public static Color[] color = new Color[3]; // 0 = original, 1 = transparent, 2 = invalid
    public static bool needsPlacing;

    // Set staticItem as item so that object can be accessed from ItemPlacer
    public void place(GameObject item)
    {
        setColors(item);
        ItemPlacer.isPlacing = true; // Go into ItemPlacer mode
        needsPlacing = true;
    }

    public static void setColors(GameObject item)
    {
        staticItem = item;
        color[0] = staticItem.GetComponent<SpriteRenderer>().color;
        color[1] = new Color(color[0].r, color[0].g, color[0].b, 0.5f);
        color[2] = new Color(1, 0, 0);
    }
}
