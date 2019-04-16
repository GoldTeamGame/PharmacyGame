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
    public int p;

    public int g;
    //public static int currentID;
    public List<CustomerData> cd;
    public List<StoreItems> si;

    public bool[][] obstical;

    public List<Drug> drugList;
    public List<Drug> overCounterList;
    public List<Pharmacist> pharmacistList;
    public PharmacistCounter[] pharmacistCounter;
    //public object shots { get; internal set; }
}