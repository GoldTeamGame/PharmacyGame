// File: Globals_Items
// Version: 1.0.2
// Last Updated: 3/12/19
// Authors: Ross Burnworth
// Description: Contains Global variables and functions relevent to items

using System.Collections.Generic;
using UnityEngine;

public static class Globals_Items
{
    public static int numberOfItems = 0;
    public static int currentNumberOfItems;
    public static List<StoreItems> storeData; // holds the item data (item attributes)
    public static List<GameObject> objects; // holds the item gameObjects
    public static List<Service> serviceList; // list of services

    public static void generateServices(List<Service> service)
    {
        serviceList = new List<Service>();

        serviceList.Add(new Service("Shelf", 0, true, 2, "A Fixture for displaying over the counter drugs. Customers can only buy the drugs being displayed."));
        serviceList.Add(new Service("Flu Shot Station", 0, false, 1, ""));
        serviceList.Add(new Service("Vaccine Station", 0, false, 1, ""));
        serviceList.Add(new Service("Blood Pressure Monitor", 0, false, 2, ""));

        // If service (list from save) is not null, fill in the important values
        if (service != null)
            for (int i = 0; i < serviceList.Count; i++)
            {
                serviceList[i].amount = service[i].amount;
                serviceList[i].limit = service[i].limit;
                serviceList[i].isUnlocked = service[i].isUnlocked;
                serviceList[i].isPlaced = service[i].isPlaced;
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
