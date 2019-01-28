using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int p;

    public int g;
    public static int numberOfCustomers; // customers currently in the store
    public static int currentID;
    public GameObject[] c; // holds the customer's gameObject (contains customer position)

    public Customer[] cd;

    //public object shots { get; internal set; }
}