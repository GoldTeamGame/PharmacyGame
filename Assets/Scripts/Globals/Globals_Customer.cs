// File: Globals_Customer
// Description: Holds Customers

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Globals_Customer
{
    public const int LIMIT = 10;
    public static int numberOfCustomers = 0;
    public static int currentNumberOfCustomers;
    public static List<CustomerData> customerData; // holds the customer's data (customer attributes)

    public static string[] name = { "Alex", "Dylan", "Jon", "Ross" }; // List of names

   
    public static List<CustomerData> GetCustomers()
    {
        return customerData;
    }
   
    public static void setCustomers(List<CustomerData> customerDatas)
    {
        customerData = customerDatas;
    }
}
