using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Set : Item
{
    string[] itemName; // the drugs that will be unlocked
    int index; // the array index that the drugs are in (0 for prescription or 1 over-the-counter)

    // Constructor for 1 item
    public Set(int index, string name, int price, string description, string item0)
    {
        this.index = index;
        this.name = name;
        this.price = price;
        this.description = description;
        itemName = new string[1];
        itemName[0] = item0;
    }

    // Constructor for 2 items
    public Set(int index, string name, int price, string description, string item0, string item1)
    {
        this.index = index;
        this.name = name;
        this.price = price;
        this.description = description;
        itemName = new string[2];
        itemName[0] = item0;
        itemName[1] = item1;
    }

    // Constructor for 3 items
    public Set(int index, string name, int price, string description, string item0, string item1, string item2)
    {
        this.index = index;
        this.name = name;
        this.price = price;
        this.description = description;
        itemName = new string[3];
        itemName[0] = item0;
        itemName[1] = item1;
        itemName[2] = item2;
    }

    // Unlock the drugs
    override public void action()
    {
        if (Globals.playerPlatinum - price >= 0)
        {
            for (int i = 0; i < itemName.Length; i++)
            {
                ((Drug)find(index, itemName[i])).isUnlocked = true;
            }
            Globals.playerPlatinum -= price;
            isUnlocked = true;
        }
    }

    override public string generateTooltip()
    {
        return "Unlocks: " + description;
    }

    public static Set[] generateSetList()
    {
        Set[] setList = new Set[1];

        setList[0] = new Set(1, "Vitamins", 10, "Vitamin B and Vitamin C", "Vitamin B", "Vitamin C");

        return setList;
    }
}
