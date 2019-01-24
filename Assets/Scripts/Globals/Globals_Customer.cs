﻿// File: Globals_Customer
// Description: Holds Customers

using UnityEngine;

public static class Globals_Customer
{
    public const int MAX_CUSTOMERS = 10;

    public static int numberOfCustomers = 0; // customers currently in the store
    public static int currentID = 0; // a unique identifier for customers (used keep the index for customer and customerData the same)
    public static GameObject[] customer = new GameObject[MAX_CUSTOMERS]; // holds the customer's gameObject (contains customer position)
    public static Customer[] customerData = new Customer[MAX_CUSTOMERS]; // holds the customer's data (customer attributes)

    public static string[] name = { "Alex", "Dylan", "Jon", "Ross" }; // List of names
}