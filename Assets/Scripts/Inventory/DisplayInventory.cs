/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/28/2019
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
    public Text employeeAtext;
    public Text employeeBtext;
    public Text employeeCtext;

    public Button fluShotBtn;

    public Sprite currSprite;

    private void Start()
    {
        staticItems = new Sprite[items.Length];
        for (int i = 0; i < items.Length; i++)
            staticItems[i] = items[i];
    }

    void Update()
    {

        currSprite = staticItems[0]; //testing

        //check to see if you even have the flu shot in your inventory; if so, display it
        if (Globals.unlockedFluShotStation)
        {
            fluShotBtn.gameObject.SetActive(true);
        }
        else
        {
            fluShotBtn.gameObject.SetActive(false);
        }

        drugAtext.text = Globals.medicationA + ": " + Globals.drugA.ToString() + " Units";
        drugBtext.text = Globals.medicationB + ": " + Globals.drugB.ToString() + " Units";
        drugCtext.text = Globals.medicationC + ": " + Globals.drugC.ToString() + " Units";
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
