// File: Globals_Customer
// Version: 1.0.3
// Last Updated: 2/6/19
// Authors: Alexander Jacks, Ross Burnworth
// Description: Contains Global variables and functions relevent to Customers

using System.Collections.Generic;

public static class Globals_Customer
{
    public static int limit = 0; // Maximum amount of customers that can be in the store
    public static int numberOfCustomers = 0;
    public static int currentNumberOfCustomers;
    public static List<CustomerData> customerData; // holds the customer's data (customer attributes)

    public static string[] name = { "Alex", "Dylan", "Jon", "Ross" }; // List of names
    public static string[] mood = { "Irate", "Mad", "Unhappy", "Content", "Satisfied", "Ecstatic", "Euphoric" }; // List of moods
   
    public static List<CustomerData> GetCustomers()
    {
        return customerData;
    }
   
    public static void setCustomers(List<CustomerData> customerDatas, int number)
    {
        customerData = customerDatas;
        currentNumberOfCustomers = number;
    }
}
