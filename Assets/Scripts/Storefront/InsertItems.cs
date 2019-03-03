// File: InsertItems
// Version: 1.0.6
// Last Updated: 3/1/19
// Authors: Ross Burnworth, Alexander Jacks
// Description: Spawns items into game world

using UnityEngine;
using System.Collections.Generic;

public class InsertItems : MonoBehaviour
{
    public Transform parent;
    public GameObject[] itemList; // contains item prefabs passed in from unity editor
    public static GameObject[] staticItemList; // Static version of itemList which can be used in static functions

    // Use this for initialization
    void Start()
    {

        // Instantiate ItemData list if none currently exists
        if (Globals_Items.storeData == null)
            Globals_Items.storeData = new List<StoreItems>();

        // Copy non-static appearanceList into staticAppearanceList
        staticItemList = new GameObject[itemList.Length];
        for (int i = 0; i < itemList.Length; i++)
            staticItemList[i] = itemList[i];

        // Spawn all Items currently in ItemData into the game world
        int numberOfItems = Globals_Items.storeData.Count;
        for (int i = 0; i < numberOfItems; i++)
        {
            Vector3 v = new Vector3(Globals_Items.storeData[i].locationX, Globals_Items.storeData[i].locationY, 0);
            //instantiateObject(v, w);
        }
    }


    public static GameObject instantiateObject(GameObject item, Transform parent, Vector3 position)
    {
        GameObject go = Instantiate(item); // spawn the item 
        go.transform.parent = parent;
        go.transform.localPosition = position;
        go.transform.localScale = new Vector3(1f, 1f, 0);
        return go;
    }

    // Generate Item data
    public static void generate(ref StoreItems s, int itemNumber)
    {
        s = new StoreItems();
        s.appearance = itemNumber; // set appearance
        Globals_Items.storeData.Add(s); // add cd to Globals list
    }
}
