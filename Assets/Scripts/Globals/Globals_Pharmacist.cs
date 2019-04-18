using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals_Pharmacist
{
    public static GameObject[] zone; // the gameobject container holding the 2 extra pharmacist zones
    public static GameObject[] block; // the gameobject container holding the 2 locations that cover the pharmacy zones when they arent unlocked

    public static Position[] STARTING_LOCATIONS = { new Position(-0.5f, -2), new Position(-3.5f, -2), new Position(2.5f, -2) }; // holds all PharmacistZone starting locations
    
    public static List<Pharmacist> pharmacistList; // pharmacist data
    public static PharmacistCounter[] pharmacistCounter; // pharmacistCounter data
    public static GameObject[] pharmacistGo; // pharmacist gameobjects at each counter

    public static Pharmacist findPharmacist(string name)
    {
        for (int i = 0; i < pharmacistList.Count; i++)
            if (pharmacistList[i].name.Equals(name))
                return pharmacistList[i];
        return null;
    }

    public static void load(PharmacistCounter[] pharmacistCounter, List<Pharmacist> pharmacistList)
    {
        if (pharmacistCounter != null)
        {
            Globals_Pharmacist.pharmacistCounter = pharmacistCounter;
            Globals_Pharmacist.pharmacistList = pharmacistList;
        }
    }
}
