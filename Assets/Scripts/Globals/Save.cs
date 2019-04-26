/* 
 * Most Recent Author: Ross
 * Version 1.0
 * Date: 1/28/2019
 * Description: Save object class
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public bool doesSaveExist; // save

    // Report data
    public int time;
    public int month;
    public bool isReport;

    // Customer limit data
    public int limit;
    public int _limit;

    // Customer mood data
    public int cumulativeMood;
    public int customersServed;

    public int p;

    public int g;

    public int tutorialIndex;

    //public static int currentID;
    public List<CustomerData> cd;
    public List<StoreItems> si;

    public bool[][] obstical;

    public bool[][] isUnlocked;

    public StoreValues sv;
    public Item[][] item;
    public PharmacistCounter[] pharmacistCounter;
    //public object shots { get; internal set; }
}