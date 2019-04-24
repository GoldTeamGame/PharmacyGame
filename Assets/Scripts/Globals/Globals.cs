/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.6
 * Date: 4/11/2019
 * Description: Game Controller script to handle flags and data used across the entire game. Allows for scene-to-scene communication.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Globals
{
    // info passing for showing what prev report is to be shown
    // at -1 should never show, but any other value will display a report
    public static int prevReportToDisplay = -1;

    // report saving
    // the first index for the array is the month (0 - 23) and the second is for the answers that were submitted
    public static string[,] reports = new string [24,13];


    //Player currencies
    public static int playerGold = 7;
    public static int playerPlatinum;
    public static int monthlyGold;
    
    public static StoreValues sv; // holds store global values

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

    //Dylan: Below are Jon's globals from his older branch
    //Game time storage
    public static int globalTime = 0;
    public static int loadTime = 0;
    public const int timePerMonth = 30;
    public static int month = 0;
    public static int year = 2019;

    //Game time flags
    public static bool newMonth = false;

    public static bool sem = false;

    public static int getInGameTime()
    {
        return (globalTime - loadTime) % timePerMonth;
    }
    
}