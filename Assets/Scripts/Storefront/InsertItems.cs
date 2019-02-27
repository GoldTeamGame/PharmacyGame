// File: InsertItems
// Version: 1.0
// Last Updated: 2/21/19
// Authors: Ross Burnworth
// Description: Spawns items into game world

using UnityEngine;
using System.Collections.Generic;

public class InsertItems : MonoBehaviour
{
    public Transform parent;
    public Sprite[] appearanceList; // contains sprites passed in from unity editor
    public static Sprite[] staticAppearanceList; // Static version of appearanceList which can be used in static functions
    public GameObject Item; // object being spawned
    public Transform spawnPoint; // location the object will be spawned at
    public SpriteRenderer sprite; // the sprite that represents the Item (will be overwritten)
    public static float xSpawnPoint; // the x-coordinate of the spawn point

    // Use this for initialization
    void Start()
    {
        xSpawnPoint = spawnPoint.localPosition.x;

        // Instantiate ItemData list if none currently exists
        if (Globals_Items.storeData == null)
            Globals_Items.storeData = new List<StoreItems>();

        // Copy non-static appearanceList into staticAppearanceList
        staticAppearanceList = new Sprite[appearanceList.Length];
        for (int i = 0; i < appearanceList.Length; i++)
            staticAppearanceList[i] = appearanceList[i];

        // Spawn all Items currently in ItemData into the game world
        int numberOfItems = Globals_Items.storeData.Count;
        for (int i = 0; i < numberOfItems; i++)
        {
            Vector3 v = new Vector3(Globals_Items.storeData[i].locationX, Globals_Items.storeData[i].locationY, 0);
            Quaternion w = new Quaternion(Globals_Items.storeData[i].rotationX, Globals_Items.storeData[i].rotationY, Globals_Items.storeData[i].rotationZ, Globals_Items.storeData[i].rotationW);
            instantiateObject(v, w);
        }
        if(numberOfItems == 0)
        {
        Spawn();
        }

    }

    // Spawn a new Item until the limit is reached
    private void Spawn()
    {
        //horizontal
        instantiateObject(new Vector3(0, 1.5f, 0), new Quaternion(0,0, 0,0));
        instantiateObject(new Vector3(1, 1.5f, 0), new Quaternion(0,0,0,0));
        instantiateObject(new Vector3(2, 1.5f, 0), new Quaternion(0, 0, 0, 0));
        //vertical
        instantiateObject(new Vector3(-1, 1, 0), new Quaternion(1, 1, 0, 0)); 
        instantiateObject(new Vector3(-1, 2, 0), new Quaternion(1, 1, 0, 0));
        instantiateObject(new Vector3(-1, 3, 0), new Quaternion(1, 1, 0, 0));
    }
                         
   
    private void instantiateObject(Vector3 position, Quaternion rotation)
    {
        GameObject go = Instantiate(Item, position, rotation); // spawn the item 
        go.transform.parent = parent;

    }

    // Generate Item data
    public static void generate(ref StoreItems sd, int ap)
    {
        // Set cd equal to the last element in ItemData
        // (This if-statement is for the sake of loading in Items that were saved in ItemData)
        // (In other words, set cd equal to existing ItemData element that exists in Globals_Item)
        // (When currentNumberOfItems catches up to numberOfItems, that symbolizes that all Items have been loaded)
        if (Globals_Items.numberOfItems < Globals_Items.currentNumberOfItems)
        {
            sd = Globals_Items.storeData[Globals_Items.numberOfItems];
            Globals_Items.numberOfItems++;
        }
        // Generate new ItemData element and then add it to Globals_Item.ItemData
        else
        {

            sd = new StoreItems();

            sd.appearance = ap; // set appearance






            Globals_Items.storeData.Add(sd); // add cd to Globals list
        }

    }
}
