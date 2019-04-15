/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.1
 * Date: 4/11/2019
 * Description: Handles updating the current statistics screen
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllStats : MonoBehaviour {

    public Text sumInvText;
    public Text sumEquText;
    public Text sumSalText;

    //Sums up your stock that has yet to be purchased by a customer at the end of the month
    public static int SumInventory()
    {
        int sum = 0;
        for(int i = 0; i < Globals.drugList.Count; i++)
        {
            sum += Globals.drugList[i].price * Globals.drugList[i].amount;
        }
        return sum;
    }

    //checks to see if you own a service; if you do, add the cost
    public static int SumEquipment()
    {
        int sum = 0;
        if(Globals.unlockedFluShotStation)
        {
            sum += Globals.platFlu;
        }
        if(Globals.unlockedVaccineStation)
        {
            sum += Globals.platVac;
        }
        return sum;
    }

    
    //the wage of each employee is considered their monthly cost
    public static int SumSalaries()
    {
        int sum = 0;
        for(int i = 0; i < Globals.employeeList.Count; i++)
        {
            if(Globals.employeeList[i].isUnlocked)
            {
                sum += Globals.employeeList[i].wage;
            }
        }
        return sum;
    }
	
	
    // Update is called once per frame
	void Update () {
        sumInvText.text = SumInventory().ToString();
        sumEquText.text = SumEquipment().ToString();
        sumSalText.text = SumSalaries().ToString();
	}
}
