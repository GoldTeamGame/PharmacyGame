/* 
 * Authors: Dylan Cyphers, Alexander Jacks
 * Version 1.1.1
 * Date: 4/16/2019
 * Description: Displays buttons so the player can buy items. Buttons that are viewable depend on the tab
 */
 
using UnityEngine;
using UnityEngine.UI;

public class DisplayShop : MonoBehaviour {

    // IMPORTANT - both drug lists much match up with the order that the drugs are generated in Globals script
    public Button[] prescriptionDrugList; // Array of prescription drug buttons
    public Button[] overTheCounterList; // Array of over the counter drug buttons
    public Button[] employeeList; // 
    
    // sel = 0 -> Show all drugs
    // sel = 1 -> Show employees
    public void SetSelector(int sel)
    {
        // Show drugs, hide employees
        if (sel == 0)
        {
            for (int i = 0; i < prescriptionDrugList.Length; i++)
                if (Globals.prescriptionList[i].isUnlocked)
                    prescriptionDrugList[i].gameObject.SetActive(true);
            for (int i = 0; i < overTheCounterList.Length; i++)
                if (Globals.overCounterList[i].isUnlocked)
                    overTheCounterList[i].gameObject.SetActive(true);
            for (int i = 0; i < employeeList.Length; i++)
                employeeList[i].gameObject.SetActive(false);
        }
        // Hide drugs, show employees
        else if (sel == 1)
        {
            for (int i = 0; i < prescriptionDrugList.Length; i++)
                prescriptionDrugList[i].gameObject.SetActive(false);
            for (int i = 0; i < overTheCounterList.Length; i++)
                overTheCounterList[i].gameObject.SetActive(false);
            for (int i = 0; i < employeeList.Length; i++)
                employeeList[i].gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        // Hide all buttons
        for (int i = 0; i < prescriptionDrugList.Length; i++)
            prescriptionDrugList[i].gameObject.SetActive(false);
        for (int i = 0; i < overTheCounterList.Length; i++)
            overTheCounterList[i].gameObject.SetActive(false);
        for (int i = 0; i < employeeList.Length; i++)
            employeeList[i].gameObject.SetActive(false);

        // Show drugs
        SetSelector(0);
    }
}
