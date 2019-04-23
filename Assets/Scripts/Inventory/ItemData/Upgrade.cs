using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade : Item
{
    public Upgrade(string name, int price, string description)
    {
        this.name = name;
        this.price = price;
        this.description = description;
    }

    public void upgrade()
    {
        switch(name)
        {
            case "Pharmacist Zone +1":
                if (!Globals_Pharmacist.pharmacistCounter[1].isUnlocked)
                {
                    Globals_Pharmacist.pharmacistCounter[1].isUnlocked = true;
                    Globals_Pharmacist.block[0].SetActive(false);
                    Globals_Pharmacist.zone[0].SetActive(true);
                }
                else if (!Globals_Pharmacist.pharmacistCounter[2].isUnlocked)
                {
                    Globals_Pharmacist.pharmacistCounter[2].isUnlocked = true;
                    Globals_Pharmacist.block[1].SetActive(false);
                    Globals_Pharmacist.zone[1].SetActive(true);
                }
                    break;
        }
    }

    override public void action()
    {
        if (Globals.playerPlatinum - price >= 0)
        {
            upgrade();
            Globals.playerPlatinum -= price;
            isUnlocked = true;
        }
    }

    override public string generateTooltip()
    {
        return "Description: " + description;
    }

    public static Upgrade[] generateUpgradeList()
    {
        Upgrade[] upgradeList = new Upgrade[2];

        upgradeList[0] = new Upgrade("Pharmacist Zone +1", 10, "Unlocks an additional Pharmacist Counter");
        upgradeList[1] = new Upgrade("Pharmacist Zone +1", 10, "Unlocks an additional Pharmacist Counter");

        return upgradeList;
    }
}
