/* 
 * Most Recent Author: Ross Burnworth
 * Version 1.2
 * Date: 2/04/2019
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
    public List<Globals.Employee> employees;
    public List<Globals.Drug> drugs;


    //public object shots { get; internal set; }
}