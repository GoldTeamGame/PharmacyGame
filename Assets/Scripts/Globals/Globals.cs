/* 
 * Most Recent Author: Ross Burnworth
 * Version 1.3.2
 * Date: 2/04/2019
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
    public static int playerGold;
    public static int playerPlatinum;

    //Player inventory of drugs (in "units") and price (in gold)
    //Consider making a struct for drugs that have fields: amount, price, and name


    /* Hypothetical organization for adding drugD, E, F... Would push drugs made in a form into these data structures
    public const int NUM_DRUGS = 3;
    public static string[] all_drugs = new string[NUM_DRUGS];
    public const int NUM_EMPLOYEES = 3;
    public static string[] all_employees = new string[NUM_EMPLOYEES];
    */

    [System.Serializable]
    public struct Employee {
        public bool isHired;
        public int wage;
        public string name;
        public Employee(bool p1, int p2, string p3)
        {
            isHired = p1;
            wage = p2;
            name = p3;
        }
    }
    [System.Serializable]
    public struct Drug
    {
        public int price;
        public int amount;
        public string name;
        public Drug(int p1, int p2, string p3)
        {
            price = p1;
            amount = p2;
            name = p3;
        }
    }

    public static Employee Jon = new Employee(false, 15, "Jon");
    public static Employee Alex = new Employee(false, 22, "Alex");
    public static Employee Ross = new Employee(false, 19, "Ross");

    public static Drug Ventolin = new Drug(5, 0, "Ventolin");
    public static Drug Vyvanse = new Drug(7, 0, "Vyvanse");
    public static Drug Lyrica = new Drug(10, 0, "Lyrica");


    //Flags for unlocked materials from expansions
    public static bool unlockedB = false;
    public static bool unlockedFluShotStation = false;
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
    public static List<Employee> getEmployees()
    {
        List<Employee> employees = new List<Employee>();
        employees.Add(Jon);
        employees.Add(Alex);
        employees.Add(Ross);
        return employees;
    }
    public static void setEmployees(List<Employee> employees)
    {
        Jon = employees[0];
        Alex = employees[1];
        Ross = employees[2];

    }

    public static List<Drug> getDrugs()
    {
        List<Drug> drugs = new List<Drug>();
        drugs.Add(Ventolin);
        drugs.Add(Vyvanse);
        drugs.Add(Lyrica);
        
        return drugs;
    }
    public static void setDrugs(List<Drug> drugs)
    {
        Ventolin = drugs[0];
        Vyvanse = drugs[1];
        Lyrica = drugs[2];

    }
}
