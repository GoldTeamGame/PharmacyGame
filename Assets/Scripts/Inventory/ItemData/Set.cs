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
        Set[] setList = new Set[12];

        int index = 0;
        setList[index++] = new Set(1, "Vitamins", 10, "Vitamin B and Vitamin C", "Vitamin B", "Vitamin C");

        setList[index++] = new Set(0, "High Blood Pressure Set A", 10, "Lisinopri", "Lisinopri 10mg");
        setList[index++] = new Set(0, "High Blood Pressure Set B", 20, "Atenolol", "Atenolol 50mg");
        setList[index++] = new Set(0, "High Blood Pressure Set C", 30, "Metoprolol Succinate", "Metoprolol Succinate 100mg");

        setList[index++] = new Set(0, "High Cholesterol Meds", 25, "Atorvastatin Calcium, Simvastatin, and Pravastatin Na", "Atorvastatin Calcium 10mg", "Simvastatin 10mg", "Pravastatin Na 80mg");

        setList[index++] = new Set(0, "Type-2 Diabetes Treatment", 25, "Metformin HCl", "Metformin HCl 1000mg");

        setList[index++] = new Set(0, "Asthma Treatment", 40, "Montelukast Sodium", "Montelukast Sodium 10mg");
    
        setList[index++] = new Set(0, "Heartburn Set", 20, "Omeprazole and Amoxicillin", "Omeprazole 20mg", "Amoxicillin 500mg");

        setList[index++] = new Set(0, "Erosive Esophagitis Treatment", 15, "Pantoprazole Sodium", "Pantoprazole Sodium 40mg");

        setList[index++] = new Set(0, "Shingles Treatment", 10, "Gabapentin", "Gabapentin 300mg");

        setList[index++] = new Set(0, "Antidepressant Set A", 20, "Sertraline Hydrocholoride and Alprazolam", "Sertraline Hydrocholoride 50mg", "Alprazolam 0.5mg");
        setList[index++] = new Set(0, "Antidepressant Set B", 40, "Escitalopram Oxalate and Trazodone Hcl", "Escitalopram Oxalate 10mg", "Trazodone Hcl 150mg");

        return setList;
    }
}
