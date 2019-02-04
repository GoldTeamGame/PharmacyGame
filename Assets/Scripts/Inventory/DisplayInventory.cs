/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.1
 * Date: 2/4/2019
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

    void Update()
    {
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
