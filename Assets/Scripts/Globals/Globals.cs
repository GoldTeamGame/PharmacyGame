/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.1
 * Date: 1/28/2019
 * Description: Game Controller script to handle flags and data used across the entire game. Allows for scene-to-scene communication.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Globals
{

    //Player currencies
    public static int playerGold = 1000;
    public static int playerPlatinum;

    //Player inventory of drugs (in "units") and price (in gold)
    //Consider making a struct for drugs that have fields: amount, price, and name
    public static int drugA = 0;
    public static int priceA = 5;
    public static string medicationA = "Ventolin";
    public static int drugB = 0;
    public static int priceB = 7;
    public static string medicationB = "Vyvanse";
    public static int drugC = 0;
    public static int priceC = 10;
    public static string medicationC = "Lyrica";

    /* Hypothetical organization for adding drugD, E, F... Would push drugs made in a form into these data structures
    public const int NUM_DRUGS = 3;
    public static string[] all_drugs = new string[NUM_DRUGS];
    public const int NUM_EMPLOYEES = 3;
    public static string[] all_employees = new string[NUM_EMPLOYEES];
    */

    //Player inventory of workers (in per "hour")
    public static bool hiredA = false;
    public static int wageA = 15;
    public static string nameA = "Jon";
    public static bool hiredB = false;
    public static int wageB = 22;
    public static string nameB = "Alex";
    public static bool hiredC = false;
    public static int wageC = 19;
    public static string nameC = "Ross";

    public static bool inEditMode = false;

    //Flags for unlocked materials from expansions
    public static bool unlockedB = false;
    public static bool unlockedFluShotStation = true; //TESTING
    public static bool unlockedVaccineStation = false;
    public static bool unlockedC = false;
    public static int employeeCap = 1;
    public static bool storeB = false;
    public static bool storeC = false;

    //Costs for expansions
    public static int platB = 10;
    public static int platFlu = 5;
    public static int platVac = 10;
    public static int platC = 15;
    public static int platCap = 30;
    public static int platStore = 10;


    public static int getGold()
    {
        return playerGold;
    }
    public static int getPlatinum()
    {
        return playerPlatinum;
    }
    public static void setGold(int gold)
    {
        playerGold = gold;
    }
    public static void setPlatinum(int platinum)
    {
        playerPlatinum = platinum;
    }
}
