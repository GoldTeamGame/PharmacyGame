﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drug : Item
{
    public int amount; // amount of the drug in stock
    public int chance; // chance that customer will want to look for drug (scaled from 1-100)

    public Drug(string name, int price, int chance, string description)
    {
        this.name = name;
        this.price = price;
        this.chance = chance;
        amount = 0;
        this.description = description;
    }

    override public void action()
    {
        if (Globals.playerGold - price >= 0)
        {
            amount++;
            Globals.playerGold -= price;
        }
    }

    override public string generateTooltip()
    {
        return "Description: " + description + "\nProfit: " + price * Globals.sv.profitMultiplier + "\nRarity: " + rarity();
    }

    private string rarity()
    {
        if (chance > 80)
            return "Extremely Common";
        else if (chance > 70)
            return "Very Common";
        else if (chance > 60)
            return "Common";
        else if (chance > 50)
            return "Somewhat Common";
        else if (chance > 40)
            return "Uncommon";
        else if (chance > 30)
            return "Very Uncommon";
        else if (chance > 20)
            return "Rare";
        else if (chance > 10)
            return "Very Rare";
        else if (chance > 0)
            return "Extremely Rare";
        else
            return "";
    }

    public static Drug[] generatePrescriptionList()
    {
        Drug[] prescriptionList = new Drug[20];

        int index = 0;
        prescriptionList[index++] = new Drug("Ventolin",                        5, 60, "Treats bronchospasms");
        prescriptionList[index++] = new Drug("Vyvanse",                         7, 40, "Treats ADHD");
        prescriptionList[index++] = new Drug("Lyrica",                          10, 25, "Treats muscle pain");
        prescriptionList[index++] = new Drug("10mg Lisinopri",                  10, 25, "");
        prescriptionList[index++] = new Drug("10mg Atorvastatin Calcium",       10, 25, "");
        prescriptionList[index++] = new Drug("1000mg Metformin HCl",            10, 25, "");
        prescriptionList[index++] = new Drug("10mg Amlodipine besylate",        10, 25, "");
        prescriptionList[index++] = new Drug("100mg Metoprolol succinate",      10, 25, "");
        prescriptionList[index++] = new Drug("20mg Omeprazole",                 10, 25, "");
        prescriptionList[index++] = new Drug("10mg Simvastatin",                10, 25, "");
        prescriptionList[index++] = new Drug("300mg Gabapentin",                10, 25, "");
        prescriptionList[index++] = new Drug("50mg Sertraline Hydrocholoride",  10, 25, "");
        prescriptionList[index++] = new Drug("500mg Amoxicillin",               10, 25, "");
        prescriptionList[index++] = new Drug("0.5mg Alprazolam",                10, 25, "");
        prescriptionList[index++] = new Drug("50mg Atenolol",                   10, 25, "");
        prescriptionList[index++] = new Drug("10mg Montelukast sodium",         10, 25, "");
        prescriptionList[index++] = new Drug("150mg Trazodone Hcl",             10, 25, "");
        prescriptionList[index++] = new Drug("40mg Pantoprazole Sodium",        10, 25, "");
        prescriptionList[index++] = new Drug("10mg Escitalopram Oxalate",       10, 25, "");
        prescriptionList[index++] = new Drug("80mg Pravastatin Na",             10, 25, "");


        prescriptionList[0].isUnlocked = true; // unlock Ventolin

        return prescriptionList;
    }

    public static Drug[] generateOverCounterList()
    {
        Drug[] overCounterList = new Drug[3];

        overCounterList[0] = new Drug("Vitamin A", 2, 85, "Supplement for Vitamin A\nVery Common");
        overCounterList[1] = new Drug("Vitamin B", 2, 85, "Supplement for Vitamin B\nVery Common");
        overCounterList[2] = new Drug("Vitamin C", 2, 85, "Supplement for Vitamin C\nVery Common");

        overCounterList[0].isUnlocked = true;

        return overCounterList;
    }
}
