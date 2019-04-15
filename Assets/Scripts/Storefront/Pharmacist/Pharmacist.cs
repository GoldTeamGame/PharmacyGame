using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pharmacist
{
    public string name; // name of pharmacist
    public int appearance; // sprite appearance index
    public int wage; // pharmacist upkeep
    public string description; // pharmacist info

    public int currentState; // what the pharmacist is currently doing
    public int counter; // which counter the pharmacist is assigned to
    public bool isUnlocked; // determines if the pharmacist is unlocked

    public Pharmacist(string name, int wage, string description, int appearance)
    {
        this.name = name;
        this.wage = wage;
        this.description = description;
        this.appearance = appearance;

        currentState = -1; // idle state
        counter = -1; // not assigned to counter
        isUnlocked = false; // not unlocked
    }
}
