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
    public int time;

    public int p;

    public int g;

    public int tutorialIndex;
    public int customerLimit;

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