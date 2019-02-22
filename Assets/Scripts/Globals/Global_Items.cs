// File: Globals_Items
// Version: 1.0
// Last Updated: 2/21/19
// Authors: Ross Burnworth
// Description: Contains Global variables and functions relevent to items

using System.Collections.Generic;

public static class Globals_Items
{
    public static int numberOfItems = 0;
    public static int currentNumberOfItems;
    public static List<StoreItems> storeData; // holds the customer's data (customer attributes)


    public static List<StoreItems> GetItems()
    {
        return storeData;
    }

    public static void setItemss(List<StoreItems> storeDatas, int number)
    {
        storeData = storeDatas;
        currentNumberOfItems = number;
    }
}
