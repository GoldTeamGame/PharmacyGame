using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Globals
{

    //Player currencies
    public static int playerGold;
    public static int playerPlatinum;

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
