// File: PlaceItem
// Version: 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Script placed on an inventory button which sends 
//      player to storefront to place the item corresponding to the button

using UnityEngine;

public class PlaceItem : MonoBehaviour {

    public static GameObject staticItem = null;

    public void place(GameObject item)
    {
        staticItem = item;
        ItemPlacer.isPlacing = true;
        Debug.Log(name);
    }
}
