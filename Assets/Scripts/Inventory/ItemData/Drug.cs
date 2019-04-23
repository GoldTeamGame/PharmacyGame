using System.Collections;
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
        isUnlocked = true;
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
        Drug[] prescriptionList = new Drug[17];

        int index = 0;
        prescriptionList[index++] = new Drug("Amlodipine Besylate 10mg",        4, 80, "Treats High Blood Pressure");
        prescriptionList[index++] = new Drug("Lisinopri 10mg",                  6, 70, "Treats High Blood Pressure");
        prescriptionList[index++] = new Drug("Atenolol 50mg",                   8, 60, "Treats High Blood Pressure");
        prescriptionList[index++] = new Drug("Metoprolol Succinate 100mg",      80, 5, "Treats High Blood Pressure");
        

        prescriptionList[index++] = new Drug("Atorvastatin Calcium 10mg",       20, 25, "Treats High Cholesterol");
        prescriptionList[index++] = new Drug("Simvastatin 10mg",                7, 60, "Treats High Cholesterol");
        prescriptionList[index++] = new Drug("Pravastatin Na 80mg",             15, 40, "Treats High Cholesterol");

        prescriptionList[index++] = new Drug("Metformin HCl 1000mg",            8, 70, "Treats Type-2 Diabetes");

        prescriptionList[index++] = new Drug("Montelukast Sodium 10mg",         20, 50, "Treats Asthma");

        prescriptionList[index++] = new Drug("Omeprazole 20mg",                 17, 25, "Treats Heartburns & Stomach Ulcers");
        prescriptionList[index++] = new Drug("Amoxicillin 500mg",               35, 20, "Treats Infections & Stomach Ulcers");
        prescriptionList[index++] = new Drug("Pantoprazole Sodium 40mg",        10, 70, "Treats Erosive Esophagitis");

        prescriptionList[index++] = new Drug("Gabapentin 300mg",                17, 25, "Treats Pains caused by Shingles");

        prescriptionList[index++] = new Drug("Sertraline Hydrocholoride 50mg",  9, 60, "Treats Depression & Mood Disorders");
        prescriptionList[index++] = new Drug("Alprazolam 0.5mg",                4, 75, "Treats Anxiety and Panic Disorder");
        prescriptionList[index++] = new Drug("Escitalopram Oxalate 10mg",       16, 50, "Treats Depression & Anxiety");
        prescriptionList[index++] = new Drug("Trazodone Hcl 150mg",             36, 35, "Treats Depression");



        prescriptionList[0].isUnlocked = true; // unlock first prescription drug

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
