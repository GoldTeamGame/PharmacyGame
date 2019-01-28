// File: Globals_Customer
// Description: Holds Customers

using UnityEngine;

public static class Globals_Customer
{
    public const int MAX_CUSTOMERS = 10;

    public static int numberOfCustomers = 0; // customers currently in the store
    public static int currentID = 0; // a unique identifier for customers (used keep the index for customer and customerData the same)
    public static CustomerData[] customerData = new CustomerData[MAX_CUSTOMERS]; // holds the customer's data (customer attributes)

    public static string[] name = { "Alex", "Dylan", "Jon", "Ross" }; // List of names

    public static GameObject[] GetGameObjects()
    {
        return customer;
    }
    public static Customer[] GetCustomers()
    {
        return customerData;
    }
    public static void setGameObjects(GameObject[] customers)
    {
        customer = customers;
    }
    public static void setCustomers(Customer[] customerDatas)
    {
        customerData = customerDatas;
    }
}
