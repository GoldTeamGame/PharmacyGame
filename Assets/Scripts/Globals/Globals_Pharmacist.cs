using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals_Pharmacist
{
    public static Position[] STARTING_LOCATIONS = { new Position(0.5f, -2) }; // holds all PharmacistZone starting locations
    public static Sprite[] APPEARANCE; // Hardcoded sprite array

    public static List<Pharmacist> pharmacistList; // pharmacist data
    public static PharmacistCounter[] pharmacistCounter; // pharmacistCounter data

    public static Pharmacist findPharmacist(string name)
    {
        for (int i = 0; i < pharmacistList.Count; i++)
            if (pharmacistList[i].name.Equals(name))
                return pharmacistList[i];
        return null;
    }
}
