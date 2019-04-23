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
        Drug d = (Drug)Item.find(0, name);

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
        Drug d = (Drug)Item.find(1, name);

        int price = d.price;
        if (d.isUnlocked && Globals.playerGold >= price)
        {
            d.amount += 1; 
            Globals.playerGold -= price;
        }
    }

    public static void hire(string name)
    {
        Pharmacist e = (Pharmacist)Item.find(2, name);

        if (!e.isUnlocked)
        {
            int price = e.price;
            if (Globals.playerGold >= price)
            {
                e.isUnlocked = true; //worker becomes employed
                Globals.playerGold -= price; //at the cost of his/her wage
            }
        }
    }
}
