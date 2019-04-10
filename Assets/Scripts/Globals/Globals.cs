/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.5
 * Date: 4/8/2019
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
    public static int playerGold = 50;
    public static int playerPlatinum;
    public static int monthlyGold;

    //Player inventory of drugs (in "units") and price (in gold)
    //Consider making a struct for drugs that have fields: amount, price, and name
    public static List<Drug> drugList;
    public static List<Drug> overCounterList;
    public static List<Employee> employeeList;

    public static void generateDrugList(List<Drug> list)
    {
        drugList = new List<Drug>();

        drugList.Add(new Drug("Ventolin", 5, 60, "Treats bronchospasms"));
        drugList.Add(new Drug("Vyvanse", 7, 40, "Treats ADHD"));
        drugList.Add(new Drug("Lyrica", 10, 25, "Treats muscle pain"));

        if (list != null)
            setAmount(drugList, list);
    }

    public static void generateOverCounterList(List<Drug> list)
    {
        overCounterList = new List<Drug>();

        overCounterList.Add(new Drug("Vitamin A", 2, 85, "Supplement for Vitamin A"));
        overCounterList.Add(new Drug("Vitamin B", 2, 85, "Supplement for Vitamin B"));
        overCounterList.Add(new Drug("Vitamin C", 2, 85, "Supplement for Vitamin C"));

        if (list != null)
            setAmount(overCounterList, list);
    }

    public static void generateEmployeeList(List<Employee> list)
    {
        employeeList = new List<Employee>();

        employeeList.Add(new Employee("Jon", 15, "Works at his own pace"));
        employeeList.Add(new Employee("Ross", 19, "Standard skilled employee"));
        employeeList.Add(new Employee("Alex", 22, "Hard working and reliable"));

        if (list != null)
            setHired(employeeList, list);
    }

    public static void setAmount(List<Drug> list1, List<Drug> list2)
    {
        for (int i = 0; i < list2.Count; i++)
            list1[i].amount = list2[i].amount;
    }

    public static void setHired(List<Employee> list1, List<Employee> list2)
    {
        for (int i = 0; i < list2.Count; i++)
        {
            list1[i].isUnlocked = list2[i].isUnlocked;
        }
    }

    public static Drug findDrug(string name, List<Drug> list)
    {
        for (int i = 0; i < list.Count; i++)
            if (list[i].name.Equals(name))
                return list[i];
        return null;
    }

    public static Employee findEmployee(string name)
    {
        for (int i = 0; i < employeeList.Count; i++)
            if (employeeList[i].name.Equals(name))
                return employeeList[i];
        return null;
    }

    //public static int drugA = 0;
    //public static int priceA = 5;
    //public static string medicationA = "Ventolin";
    //public static int drugB = 0;
    //public static int priceB = 7;
    //public static string medicationB = "Vyvanse";
    //public static int drugC = 0;
    //public static int priceC = 10;
    //public static string medicationC = "Lyrica";
    //public static int vitaminA = 0;
    //public static int vitaminAPrice = 2;
    //public static string vitaminAName = "Vitamin A";

    //Vitamin resource for shelf mechanic. No functionality as of now. 
    public static int vitamins = 0;

    /* Hypothetical organization for adding drugD, E, F... Would push drugs made in a form into these data structures
    public const int NUM_DRUGS = 3;
    public static string[] all_drugs = new string[NUM_DRUGS];
    public const int NUM_EMPLOYEES = 3;
    public static string[] all_employees = new string[NUM_EMPLOYEES];
    */

    //Player inventory of workers (in per "hour")
    //public static bool hiredA = false;
    //public static int wageA = 15;
    //public static string nameA = "Jon";
    //public static bool hiredB = false;
    //public static int wageB = 22;
    //public static string nameB = "Alex";
    //public static bool hiredC = false;
    //public static int wageC = 19;
    //public static string nameC = "Ross";

    public static bool inEditMode = false;

    //Flags for unlocked materials from expansions
    public static bool unlockedVitamins = false;
    public static bool unlockedFluShotStation = false; //TESTING
    public static bool unlockedVaccineStation = false;
    public static bool unlockedC = false;
    public static int employeeCap = 1;
    public static bool storeB = false;
    public static bool storeC = false;

    //Costs for expansions
    public static int platVit = 10;
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

[System.Serializable]
public class Drug
{
    public string name;
    public int amount;
    public int price;
    public int chance; // chance that customer will want to look for drug (scaled from 1-100)
    public string description;

    public Drug(string name, int price, int chance, string description)
    {
        this.name = name;
        this.price = price;
        this.chance = chance;
        amount = 0;
        this.description = description;
    }
}

[System.Serializable]
public class Employee
{
    public string name;
    public bool isUnlocked;
    public int wage;
    public string description;

    public Employee(string name, int wage, string description)
    {
        this.name = name;
        this.wage = wage;
        isUnlocked = false;
        this.description = description;
    }
}