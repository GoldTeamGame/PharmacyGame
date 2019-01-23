// File: Globals_Customer
// Description: Holds Customers

using UnityEngine;

public static class Globals_Customer
{
    public const int MAX_CUSTOMERS = 100;

    public static int currentID = 0;
    public static GameObject[] customer = new GameObject[MAX_CUSTOMERS];
    public static Customer[] customerData = new Customer[MAX_CUSTOMERS];

    public static string[] name = { "Alex", "Dylan", "Jon", "Ross" };
}
