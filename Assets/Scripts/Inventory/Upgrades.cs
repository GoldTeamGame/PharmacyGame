using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades
{
    public static void upgrade(string s)
    {
        switch(s)
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
}
