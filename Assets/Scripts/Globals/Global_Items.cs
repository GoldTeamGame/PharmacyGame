// File: Globals_Items
// Version: 2.0.1
// Last Updated: 4/17/19
// Authors: Ross Burnworth, Alexander Jacks
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
        if (service != null)
            serviceList = service;
        else
        {
            serviceList = new List<Service>();

            serviceList.Add(new Service("Shelf", "A Fixture for displaying over the counter drugs. Customers can only buy the drugs being displayed."));
            serviceList.Add(new Service("Flu Shot Station", "Flut Shot Station Description"));
            serviceList.Add(new Service("Vaccine Station", "Vaccine Station Description"));
            serviceList.Add(new Service("Blood Pressure Monitor", "Blood Pressure Monitor Description"));
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

    public static Service findService(string name)
    {
        for (int i = 0; i < serviceList.Count; i++)
            if (name.Contains(serviceList[i].name))
                return serviceList[i];
        return null;
    }
}
