/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 3/19/2019
 * Description: Displays the shop items alongside their price. Buttons are used as tabs, limiting the display.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayShop : MonoBehaviour {

    public Button drugAbtn;
    public Text drugAtext;
    public Button drugBbtn;
    public Text drugBtext;
    public Button drugCbtn;
    public Text drugCtext;
    public Button vitaminAbtn;
    public Text vitaminAtext;
    public Button employeeAbtn;
    public Text employeeAtext;
    public Button employeeBbtn;
    public Text employeeBtext;
    public Button employeeCbtn;
    public Text employeeCtext;

    /* The selector [0,1] is the int used to designate which parts of the scrollbar are displayed
    *  0: Stock
    *  1: Staff
    *  Note: No fixtures because they are exclusively in Expansions (Platinum Shop)
    */
    public int selector;

    public Button[] tabButtons;

    public void SetSelector(int sel)
    {
        selector = sel;
    }

    void Update()
    {
        //Testing Limited Display
        //Reminder: 0 === Stock
        if (selector == 0)
        {
            drugAbtn.gameObject.SetActive(true);
            drugBbtn.gameObject.SetActive(true);
            drugCbtn.gameObject.SetActive(true);
            vitaminAbtn.gameObject.SetActive(true);
            employeeAbtn.gameObject.SetActive(false);
            employeeBbtn.gameObject.SetActive(false);
            employeeCbtn.gameObject.SetActive(false);
        }
        //Reminder: 1 === Staff
        else if (selector == 1)
        {
            drugAbtn.gameObject.SetActive(false);
            drugBbtn.gameObject.SetActive(false);
            drugCbtn.gameObject.SetActive(false);
            vitaminAbtn.gameObject.SetActive(false);
            employeeAbtn.gameObject.SetActive(true);
            employeeBbtn.gameObject.SetActive(true);
            employeeCbtn.gameObject.SetActive(true);
        }

        

        drugAtext.text = Globals.drugList[0].name + ": " + Globals.drugList[0].price + " Gold/Unit";
        drugBtext.text = Globals.drugList[1].name + ": " + Globals.drugList[1].price + " Gold/Unit";
        drugCtext.text = Globals.drugList[2].name + ": " + Globals.drugList[2].price + " Gold/Unit";
        vitaminAtext.text = Globals.overCounterList[0].name + ": " + Globals.overCounterList[0].price + " Gold/Unit";

        if(!Globals_Pharmacist.pharmacistList[0].isUnlocked)
        {
            employeeAtext.text = Globals_Pharmacist.pharmacistList[0].name + ": " + Globals_Pharmacist.pharmacistList[0].wage + " Gold/Hour";

        }
        if(!Globals_Pharmacist.pharmacistList[1].isUnlocked)
        {
            employeeBtext.text = Globals_Pharmacist.pharmacistList[1].name + ": " + Globals_Pharmacist.pharmacistList[1].wage + " Gold/Hour";

        }
        if(!Globals_Pharmacist.pharmacistList[2].isUnlocked)
        {
            employeeCtext.text = Globals_Pharmacist.pharmacistList[2].name + ": " + Globals_Pharmacist.pharmacistList[2].wage + " Gold/Hour";
        }
    }
}
