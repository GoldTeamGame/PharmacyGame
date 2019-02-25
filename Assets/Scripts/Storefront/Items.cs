// File: Items
// Version: 1.0
// Last Updated: 2/21/19
// Authors: Ross Burnworth
// Description: GameObject script for Item

using UnityEngine;
[System.Serializable]
public class Items : MonoBehaviour
{
    public StoreItems sd; // contains information about item

    // Generate item Data
    private void Start()
    {
        InsertItems.generate(ref sd, sd.appearance); // pass variables to be handled by ProceduralGenerator
        GetComponent<SpriteRenderer>().sprite = InsertItems.staticAppearanceList[sd.appearance]; // set item sprite
        transform.localScale = new Vector3(1.25f, 1.25f, 0); // set item sprite size (make it bigger)
    }

    // Dictates a item's actions
    private void Update()
    {
        // Save current coordinate position of item in itemData (for save/load purposes)
        sd.locationX = transform.position.x;
        sd.locationY = transform.position.y;
        sd.rotationX = transform.rotation.x;
        sd.rotationY = transform.rotation.y;
        sd.rotationZ = transform.rotation.z;
        sd.rotationW = transform.rotation.w;
    }
}
