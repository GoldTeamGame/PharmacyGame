// File: InsertItems
// Version: 1.0.8
// Last Updated: 3/13/19
// Authors: Ross Burnworth, Alexander Jacks
// Description: Spawns items into game world

using UnityEngine;
using System.Collections.Generic;

public class InsertItems : MonoBehaviour
{
    public Transform parent; // container item is being instantiated in to
    public GameObject[] itemList; // contains item prefabs passed in from unity editor
    public static GameObject[] staticItemList; // Static version of itemList which can be used in static functions

    // Use this for initialization
    void Start()
    {
        // Instantiate ItemData list if none currently exists
        if (Globals_Items.storeData == null)
            Globals_Items.storeData = new List<StoreItems>();

        Globals_Items.objects = new List<GameObject>(); // must create gameObject list every time

        // Copy non-static appearanceList into staticAppearanceList
        staticItemList = new GameObject[itemList.Length];
        for (int i = 0; i < itemList.Length; i++)
            staticItemList[i] = itemList[i];

        // Spawn all Items in Global_Items.storeData into the game world
        int numberOfItems = Globals_Items.storeData.Count;
        for (int i = 0; i < numberOfItems; i++)
        {
            Vector3 v = new Vector3(Globals_Items.storeData[i].locationX, Globals_Items.storeData[i].locationY, 0); // location where object will be instantiated

            // Find the game object being instantiated by name from the staticItemList
            GameObject go = null;
            for (int j = 0; j < staticItemList.Length; j++)
                if (Globals_Items.storeData[i].name.Equals(staticItemList[j].name))
                {
                    go = staticItemList[j];
                    break;
                }

            // Instantiate game object if it was found in the list
            if (go != null)
                instantiateObject(go, parent, v, Globals_Items.storeData[i].rotationZ);
            else
                Debug.Log("ERROR: Item is not in staticItemList");
        }
    }

    // Instantiate game object
    public static void instantiateObject(GameObject item, Transform parent, Vector3 position, float rotation)
    {
        GameObject go = Instantiate(item); // spawn the item 
        go.transform.parent = parent;
        go.transform.localPosition = position;
        go.transform.localScale = new Vector3(1f, 1f, 0);
        go.transform.eulerAngles = new Vector3(0, 0, rotation);

        Globals_Items.objects.Add(go);
    }

    // Instantiate and return game object
    public static GameObject instantiateObject(GameObject item, Transform parent, Vector3 position)
    {
        GameObject go = Instantiate(item); // spawn the item 
        go.transform.parent = parent;
        go.transform.localPosition = position;
        go.transform.localScale = new Vector3(1f, 1f, 0);

        return go;
    }

    // Generate Item data
    public static void generate(GameObject item, StoreItems s)
    {
        s.name = item.name.Remove(item.name.Length - 7); // remove "(Clone) from the end of the name
        s.locationX = item.transform.localPosition.x;
        s.locationY = item.transform.localPosition.y;
        s.rotationZ = item.transform.eulerAngles.z;

        Globals_Items.objects.Add(item);
        Globals_Items.storeData.Add(s); // add cd to Globals list
    }
}
