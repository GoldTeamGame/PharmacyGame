/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 3/6/2019
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

        

        drugAtext.text = Globals.medicationA + ": " + Globals.priceA.ToString() + " Gold/Unit";
        drugBtext.text = Globals.medicationB + ": " + Globals.priceB.ToString() + " Gold/Unit";
        drugCtext.text = Globals.medicationC + ": " + Globals.priceC.ToString() + " Gold/Unit";
        vitaminAtext.text = Globals.vitaminAName + ": " + Globals.vitaminAPrice.ToString() + " Gold/Unit";

        if(!Globals.hiredA)
        {
            employeeAtext.text = Globals.nameA + ": " + Globals.wageA.ToString() + " Gold/Hour";

        }
        if(!Globals.hiredB)
        {
            employeeBtext.text = Globals.nameB + ": " + Globals.wageB.ToString() + " Gold/Hour";

        }
        if(!Globals.hiredC)
        {
            employeeCtext.text = Globals.nameC + ": " + Globals.wageC.ToString() + " Gold/Hour";
        }
    }
}
