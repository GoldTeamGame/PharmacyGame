/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.2
 * Date: 2/24/2019
 * Description: Displays the inventory items alongside their amount. The items displayed are both drugs and employees.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DisplayInventory : MonoBehaviour {

    public Text drugAtext;
    public Text drugBtext;
    public Text drugCtext;
    public Text employeeAtext;
    public Text employeeBtext;
    public Text employeeCtext;

    public Button fluShotBtn;

    void Start()
    {
        //Globals.unlockedFluShotStation = true;
        if(Globals.unlockedFluShotStation)
        {
            
            fluShotBtn.onClick.AddListener(PlaceFluShot);
        }
    }

    public void PlaceFluShot()
    {
        //scene change to storefront
        Globals.inEditMode = true;
        //get transform location from mouse click
        //return to inventory
    }

    void Update()
    {
        //check to see if you even have the flu shot in your inventory; if so, display it
        if (Globals.unlockedFluShotStation)
        {
            fluShotBtn.gameObject.SetActive(true);
        }
        else
        {
            fluShotBtn.gameObject.SetActive(false);
        }

        



        drugAtext.text = Globals.Ventolin.name + ": " + Globals.Ventolin.amount.ToString() + " Units";
        drugBtext.text = Globals.Vyvanse.name + ": " + Globals.Vyvanse.amount.ToString() + " Units";
        drugCtext.text = Globals.Lyrica.name + ": " + Globals.Lyrica.amount.ToString() + " Units";
        if (Globals.Jon.isHired)
        {
            employeeAtext.text = Globals.Jon.name + ": " + Globals.Jon.wage.ToString() + "g/hr";
        }
        else
        {
            employeeAtext.text = Globals.Jon.name + ": Hire me!";
        }
        if (Globals.Alex.isHired)
        {
            employeeBtext.text = Globals.Alex.name + ": " + Globals.Alex.wage.ToString() + "g/hr";
        }
        else
        {
            employeeBtext.text = Globals.Alex.name + ": Hire me!";
        }
        if (Globals.Ross.isHired)
        {
            employeeCtext.text = Globals.Ross.name + ": " + Globals.Ross.wage.ToString() + "g/hr";
        }
        else
        {
            employeeCtext.text = Globals.Ross.name + ": Hire me!";
        }
    }
}
