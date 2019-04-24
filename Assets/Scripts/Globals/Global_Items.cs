// File: Globals_Items
// Version: 2.0.1
// Last Updated: 4/17/19
// Authors: Ross Burnworth, Alexander Jacks
// Description: Contains Global variables and functions relevent to items

using System.Collections.Generic;
using UnityEngine;

public static class Globals_Items
{
    /*
     * item[][]
     * 0: Prescription Drug Data
     * 1: Over-the-counter Drug Data
     * 2: Pharmacist Data
     * 3: Drug Sets
     * 4: Upgrade List
     * 5: Service List
     */
    public static Item[][] item;
    public static int numberOfItems = 0;
    public static int currentNumberOfItems;
    public static List<StoreItems> storeData; // holds the item data (item attributes)
    public static List<GameObject> objects; // holds the item gameObjects

    public static bool[][] isUnlocked; // keeps track of which buttons have been unlocked in the expansions screen

    public static void generateItems(Item[][] savedItem)
    {
        // Set list if it isn't null
        if (savedItem != null  && TutorialMonitor.doesSaveExist)
            item = savedItem;
        // Or generate a new list
        else
        {
            // Create the 6 lists and populate them
            item = new Item[6][];
            item[0] = Drug.generatePrescriptionList();
            item[1] = Drug.generateOverCounterList();
            item[2] = Pharmacist.generatePharmacistList();
            item[3] = Set.generateSetList();
            item[4] = Upgrade.generateUpgradeList();
            item[5] = Service.generateServiceList();
        }
    }

    // Sets isUnlocked if the passed argument is not null
    public static void setIsUnlocked(bool[][] isUnlocked)
    {
        if (isUnlocked != null)
            Globals_Items.isUnlocked = isUnlocked;
    }

    // Creates isUnlocked if it hasn't been created
    public static void createIsUnlocked(int size0, int size1, int size2)
    {
        if (isUnlocked == null)
        {
            isUnlocked = new bool[3][];
            isUnlocked[0] = new bool[size0];
            isUnlocked[1] = new bool[size1];
            isUnlocked[2] = new bool[size2];
        }
    }

    public static List<StoreItems> GetItems()
    {
        return storeData;
    }

    public static void setItems(List<StoreItems> storeDatas, int number)
    {
        storeData = storeDatas;
        currentNumberOfItems = number;
    }
}
