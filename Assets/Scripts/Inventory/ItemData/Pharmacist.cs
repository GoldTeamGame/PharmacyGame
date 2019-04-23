﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pharmacist : Item
{
    public int appearance; // sprite appearance index
    
    // [0] - Initial Checkout time
    // [1] - Computer Processing time
    // [2] - Drug fetching time
    // [3] - Post Checkout time
    public int[] stats; // how fast the pharmacist can process particular transactions
    public float speed; // how fast the pharmacist can move
    public float personality; // how good the pharmacist is at keeping customers happy
    
    public int currentState; // what the pharmacist is currently doing
    public int progress; // amount of progress towards completion of an action
    public int counter; // which counter the pharmacist is assigned to
    public bool isMoving; // if the customer is moving or not

    public Pharmacist(string name, int price, string description, int appearance, int s0, int s1, int s2, int s3, float speed, float personality)
    {
        this.name = name;
        this.price = price;
        this.description = description;
        this.appearance = appearance;

        stats = new int[4];
        stats[0] = s0;
        stats[1] = s1;
        stats[2] = s2;
        stats[3] = s3;

        this.speed = speed;
        this.personality = personality;

        currentState = -1; // idle state
        progress = 0; // no progress
        counter = -1; // not assigned to counter
        isUnlocked = false; // not unlocked
        isMoving = false; // customer is not moving
    }

    public void reset(int counter)
    {
        if (counter == -1 || !Globals_Pharmacist.pharmacistCounter[counter].isCustomer)
            currentState = -1;
        else
            currentState = 0;

        progress = 0;
    }

    override public void action()
    {
        if (Globals.playerGold - price >= 0)
        {
            isUnlocked = true;
            Globals.playerGold -= price;
        }
    }

    override public string generateTooltip()
    {
        return "Description: " + description + "\nCheckout Time: " + stats[0] + "seconds\nComputer Time: " + stats[1] + "seconds\nDrug Fetching Time: " + stats[2] + "seconds";
    }

    public static Pharmacist[] generatePharmacistList()
    {
        Pharmacist[] pharmacistList = new Pharmacist[4];

        pharmacistList[0] = new Pharmacist("Dylan", 0, "A dude that works for free", 0, 3, 3, 3, 3, 0.005f, 0);
        pharmacistList[1] = new Pharmacist("Jon", 15, "Works at his own pace", 1, 3, 3, 3, 3, 0.005f, 0);
        pharmacistList[2] = new Pharmacist("Ross", 19, "Standard skilled employee", 2, 3, 3, 3, 3, 0.005f, 0);
        pharmacistList[3] = new Pharmacist("Alex", 22, "Hard working and reliable", 3, 3, 3, 3, 3, 0.005f, 0);

        pharmacistList[0].isUnlocked = true; // Unlock Dylan by default

        return pharmacistList;
    }
}