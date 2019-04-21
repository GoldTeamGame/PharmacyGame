/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.4
 * Date: 3/19/2019
 * Description: Displays the inventory items alongside their amount. The items displayed are both drugs and employees.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public static GameObject editModeButton;
    public GameObject _editModeButton;

    public static Text[] prescriptionStock;
    public static Text[] overCounterStock;

    public Text[] _prescriptionStock;
    public Text[] _overCounterStock;
    public Text[] employee;
    public Button[] service;

    public void SetSelector(int sel)
    {
        // Display Stock
        if (sel == 0)
        {
            for (int i = 0; i < prescriptionStock.Length; i++)
                if (Globals.prescriptionList[i].isUnlocked)
                    prescriptionStock[i].gameObject.SetActive(true);

            for (int i = 0; i < overCounterStock.Length; i++)
                if (Globals.overCounterList[i].isUnlocked)
                    overCounterStock[i].gameObject.SetActive(true);

            for (int i = 0; i < employee.Length; i++)
                employee[i].gameObject.SetActive(false);

            for (int i = 0; i < service.Length; i++)
                service[i].gameObject.SetActive(false);
        }
        // Display Staff
        else if (sel == 1)
        {
            for (int i = 0; i < prescriptionStock.Length; i++)
                prescriptionStock[i].gameObject.SetActive(false);

            for (int i = 0; i < overCounterStock.Length; i++)
                overCounterStock[i].gameObject.SetActive(false);

            for (int i = 0; i < employee.Length; i++)
                if (Globals_Pharmacist.pharmacistList[i].isUnlocked)
                    employee[i].gameObject.SetActive(true);

            for (int i = 0; i < service.Length; i++)
                service[i].gameObject.SetActive(false);
        }
        // Display Services
        else if (sel == 2)
        {
            for (int i = 0; i < prescriptionStock.Length; i++)
                prescriptionStock[i].gameObject.SetActive(false);

            for (int i = 0; i < overCounterStock.Length; i++)
                overCounterStock[i].gameObject.SetActive(false);

            for (int i = 0; i < employee.Length; i++)
                employee[i].gameObject.SetActive(false);

            for (int i = 0; i < service.Length; i++)
                if (Globals_Items.serviceList[i].isUnlocked)
                    service[i].gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        editModeButton = _editModeButton;

        // Set static lists
        prescriptionStock = _prescriptionStock;
        overCounterStock = _overCounterStock;

        // Set text for all Text fields
        displayDrugs();

        for (int i = 0; i < employee.Length; i++)
            employee[i].text = Globals_Pharmacist.pharmacistList[i].name + ": " + Globals_Pharmacist.pharmacistList[i].wage + "g/hr";

        // Hide everything
        for (int i = 0; i < prescriptionStock.Length; i++)
            prescriptionStock[i].gameObject.SetActive(false);

        for (int i = 0; i < overCounterStock.Length; i++)
            overCounterStock[i].gameObject.SetActive(false);

        for (int i = 0; i < employee.Length; i++)
            employee[i].gameObject.SetActive(false);

        for (int i = 0; i < service.Length; i++)
            service[i].gameObject.SetActive(false);
        
        SetSelector(0); // select first tab
    }

    private void Update()
    {
        displayDrugs();
    }

    public static void displayDrugs()
    {
        for (int i = 0; i < prescriptionStock.Length; i++)
            prescriptionStock[i].text = Globals.prescriptionList[i].name + ": " + Globals.prescriptionList[i].amount + " Units";

        for (int i = 0; i < overCounterStock.Length; i++)
            overCounterStock[i].text = Globals.overCounterList[i].name + ": " + Globals.overCounterList[i].amount + " Units";
    }
}
