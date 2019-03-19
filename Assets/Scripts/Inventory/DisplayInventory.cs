/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.2
 * Date: 3/6/2019
 * Description: Displays the inventory items alongside their amount. The items displayed are both drugs and employees.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour {

    public Sprite[] items;
    public static Sprite[] staticItems;
    public Text drugAtext;
    public Text drugBtext;
    public Text drugCtext;
    public Text vitaminAtext;
    public Text employeeAtext;
    public Text employeeBtext;
    public Text employeeCtext;

    public Button fluShotBtn;
    public Button shelfBtn;
    public Button vacBtn;


    public Sprite currSprite;


    /* The selector [0,2] is the int used to designate which parts of the scrollbar are displayed
    *  0: Stock
    *  1: Staff
    *  2: Fixtures
    */
    public int selector;

    public Button[] tabButtons;

    public void SetSelector(int sel)
    {
        selector = sel;
    }

    private void Start()
    {
        staticItems = new Sprite[items.Length];
        for (int i = 0; i < items.Length; i++)
            staticItems[i] = items[i];
    }

    void Update()
    {

        //Testing Limited Display
        //Reminder: 0 === Stock
        if(selector == 0)
        {
            drugAtext.gameObject.SetActive(true);
            drugBtext.gameObject.SetActive(true);
            drugCtext.gameObject.SetActive(true);
            vitaminAtext.gameObject.SetActive(true);
            employeeAtext.gameObject.SetActive(false);
            employeeBtext.gameObject.SetActive(false);
            employeeCtext.gameObject.SetActive(false);
            fluShotBtn.gameObject.SetActive(false);
            shelfBtn.gameObject.SetActive(false);
            vacBtn.gameObject.SetActive(false);
        }
        //Reminder: 1 === Staff
        else if (selector == 1)
        {
            drugAtext.gameObject.SetActive(false);
            drugBtext.gameObject.SetActive(false);
            drugCtext.gameObject.SetActive(false);
            vitaminAtext.gameObject.SetActive(false);
            employeeAtext.gameObject.SetActive(true);
            employeeBtext.gameObject.SetActive(true);
            employeeCtext.gameObject.SetActive(true);
            fluShotBtn.gameObject.SetActive(false);
            shelfBtn.gameObject.SetActive(false);
            vacBtn.gameObject.SetActive(false);
        }
        //Reminder: 2 === Fixtures
        else if (selector == 2)
        {
            drugAtext.gameObject.SetActive(false);
            drugBtext.gameObject.SetActive(false);
            drugCtext.gameObject.SetActive(false);
            vitaminAtext.gameObject.SetActive(false);
            employeeAtext.gameObject.SetActive(false);
            employeeBtext.gameObject.SetActive(false);
            employeeCtext.gameObject.SetActive(false);
            if (Globals.unlockedFluShotStation)
            {
                fluShotBtn.gameObject.SetActive(true);
            }
            shelfBtn.gameObject.SetActive(true);
            if (Globals.unlockedVaccineStation)
            {
                vacBtn.gameObject.SetActive(true);
            }
        }


        currSprite = staticItems[0]; //testing


        //check to see if you even have the flu shot in your inventory; if so, display it
        /*
        if (Globals.unlockedFluShotStation)
        {
            fluShotBtn.gameObject.SetActive(true);
        }
        else
        {
            fluShotBtn.gameObject.SetActive(false);
        }
        */
        drugAtext.text = Globals.medicationA + ": " + Globals.drugA.ToString() + " Units";
        drugBtext.text = Globals.medicationB + ": " + Globals.drugB.ToString() + " Units";
        drugCtext.text = Globals.medicationC + ": " + Globals.drugC.ToString() + " Units";
        vitaminAtext.text = Globals.vitaminAName + ": " + Globals.vitaminA + " Units";
        if (Globals.hiredA)
        {
            employeeAtext.text = Globals.nameA + ": " + Globals.wageA.ToString() + "g/hr";
        }
        else
        {
            employeeAtext.text = Globals.nameA + ": Hire me!";
        }
        if (Globals.hiredB)
        {
            employeeBtext.text = Globals.nameB + ": " + Globals.wageB.ToString() + "g/hr";
        }
        else
        {
            employeeBtext.text = Globals.nameB + ": Hire me!";
        }
        if (Globals.hiredC)
        {
            employeeCtext.text = Globals.nameC + ": " + Globals.wageC.ToString() + "g/hr";
        }
        else
        {
            employeeCtext.text = Globals.nameC + ": Hire me!";
        }
    }
}
