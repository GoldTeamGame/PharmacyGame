/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.2
 * Date: 4/8/2019
 * Description: Handles buying each drug or employee. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {

    public void _buyPrescription(string name)
    {
        buyPrescription(name);
    }

    public void _buyOverCounter(string name)
    {
        buyOverCounter(name);
    }

    public void _hire(string name)
    {
        hire(name);
    }

    public static void buyPrescription(string name)
    {
        Drug d = Globals.findDrug(name, Globals.drugList);

        int price = d.price;
        if (d.isUnlocked && Globals.playerGold >= price)
        {
            d.amount += 1; //buy 1 unit
            Globals.playerGold -= price; //at its respective cost
            Debug.Log("purchased!");
        }
    }

    public static void buyOverCounter(string name)
    {
        Drug d = Globals.findDrug(name, Globals.overCounterList);

        int price = d.price;
        if (d.isUnlocked && Globals.playerGold >= price)
        {
            d.amount += 1; 
            Globals.playerGold -= price;
        }
    }

    public static void hire(string name)
    {
        Employee e = Globals.findEmployee(name);

        if (!e.isUnlocked)
        {
            int wage = e.wage;
            if (Globals.playerGold >= wage)
            {
                e.isUnlocked = true; //worker becomes employed
                Globals.playerGold -= wage; //at the cost of his/her wage
            }
        }
    }
}
