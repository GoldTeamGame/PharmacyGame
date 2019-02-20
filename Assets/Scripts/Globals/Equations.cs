/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 2/6/2019
 * Description: Contains the list of all variables and equations needed to produce the accurate monthly report
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equations : MonoBehaviour
{
    // stock variables
    public static int gross_margin; //B
    public static int total_operating_expenses; //C
    public static int other_income; //E "interest income"
    public static double taxes; //G "certain percentage of F"

    public static int Net_Operating_Income_Before_Taxes(int gross_margin, int total_operating_expenses)
    {
        return (gross_margin - total_operating_expenses); //D
    }

    public static int Total_Net_Income_From_All_Sources(int net_operating_income_before_taxes, int other_income)
    {
        return (net_operating_income_before_taxes + other_income); //F
    }

    public static double Net_Income_After_Taxes(int total_net_income_from_all_sources, double taxes)
    {
        return (total_net_income_from_all_sources - taxes); //H
    }
}
