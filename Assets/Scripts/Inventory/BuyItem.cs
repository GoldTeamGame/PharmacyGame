using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {

    public void buyDrug(string name)
    {
        Drug d = Globals.findDrug(name, Globals.drugList);

        int price = d.price;
        if (Globals.playerGold >= price)
        {
            d.amount += 1; //buy 1 unit
            Globals.playerGold -= price; //at the cost of 5 gold
        }
    }

    public void buyOverCounter(string name)
    {
        Drug d = Globals.findDrug(name, Globals.overCounterList);

        int price = d.price;
        if (Globals.playerGold >= price)
        {
            d.amount += 1; //buy 1 unit
            Globals.playerGold -= price; //at the cost of 5 gold
        }
    }

    public void hire(string name)
    {
        Employee e = Globals.findEmployee(name);

        if (!e.isUnlocked)
        {
            int wage = e.wage;
            if (Globals.playerGold >= wage)
            {
                e.isUnlocked = true; //worker becomes employed
                Globals.playerGold -= wage; //at the cost of 15 gold
            }
        }
    }
}
