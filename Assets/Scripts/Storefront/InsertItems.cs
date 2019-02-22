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
            instantiateObject(v);
        }
        InvokeRepeating("Spawn", 0, 5); // start the script and repeat it every spawnTime second
        

    }

    // Spawn a new Item until the limit is reached
    private void Spawn()
    {
        if (Globals_Items.storeData.Count < 10)
            instantiateObject(spawnPoint.position);
    }

    private void instantiateObject(Vector3 position)
    {
        GameObject go = Instantiate(Item, position, spawnPoint.rotation); // spawn the item
        go.transform.parent = parent;
    }

    // Generate Item data
    public static void generate(ref StoreItems sd)
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

            sd.appearance = Random.Range(0, 2); // set appearance





            Globals_Items.storeData.Add(sd); // add cd to Globals list
        }

    }
}
