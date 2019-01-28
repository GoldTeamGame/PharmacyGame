/*
    Author: Jon Hearn
    Ver.: 1.1
    Date: 1/16/19
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Globals
{

    //Player currencies
    public static int playerGold = 999;
    public static int playerPlatinum = 999;

    //Player inventory of drugs (in "units")
    public static int drugA = 0;
    public static int drugB = 0;
    public static int drugC = 0;

    //Player inventory of workers (in per "hour")
    public static bool hiredA = false;
    public static int wageA = 15;
    public static bool hiredB = false;
    public static int wageB = 22;
    public static bool hiredC = false;
    public static int wageC = 19;

    //Flags for unlocked materials from expansions
    public static bool unlockedB = false;


    //Game time storage
    public static int loadTime = 0;
    public static int month = 0;
    public static int year = 2019;
    
    //Game time flags
    public static bool newMonth = false;

    public static int getInGameTime(){
        return Globals.loadTime + (int)Time.time;
    }
}
