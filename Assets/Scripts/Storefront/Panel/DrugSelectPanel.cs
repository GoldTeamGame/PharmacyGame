// File: DrugSelectPanel
// Authors: Alexander Jacks
// Version: 1.0.1
// Last Modified: 4/18/19
// Description: Handles displaying assignable over the counter drugs while assigning drugs to shelves

using UnityEngine;
using UnityEngine.UI;

public class DrugSelectPanel : MonoBehaviour {

    public GameObject panel; // the panel being shown
    public Button b; // a Button (Probably doesnt need to be passed in from inspector)
    public GameObject selectedButton; // the button that was used to enter the DrugSelectPanel
    public static bool needToUpdate; // a check to see if the drug list needs to be updated
    public bool[] exist; // a check to see if the button has already been added to the list (this array matches up with the overCounterList)

    // Instantiate exist list (DO NOT SAVE THIS LIST)
    private void Start()
    {
        exist = new bool[Globals.overCounterList.Count];
        needToUpdate = true;
    }

    // Continuously update
    private void Update()
    {
        // Update if gameobject is active
        if (gameObject.activeSelf)
        {
            // Update if needToUpdate is set to true
            if (needToUpdate)
            {
                // Loop through all overCounterList drugs
                for (int i = 0; i < Globals.overCounterList.Count; i++)
                {
                    // If a button for the drug has not been added to the list
                    // and the drug has been unlocked,
                    // Then create a button and add it to the list
                    if (!exist[i] && Globals.overCounterList[i].isUnlocked)
                    {
                        exist[i] = true; // set that the button exists
                        Button newButton = Instantiate(b, transform); // instantiate the button in the list
                        string s = Globals.overCounterList[i].name; // get the name of the drug
                        newButton.transform.GetChild(0).GetComponent<Text>().text = s; // set the button text to the drug name
                        newButton.onClick.AddListener(delegate { selectDrug(s); }); // add the function to the button
                    }
                }
                needToUpdate = false; // Set need to update to false after adding buttons to list (prevents unecessary repetition)
            }
        }
    }

    // Hide panel and set needToUpdate to true
    public void remove(GameObject go)
    {
        needToUpdate = true;
        go.SetActive(false);
    }

    // Function connected to buttons in drug panel list
    public void selectDrug(string s)
    {
        selectedButton = ShowGameObject.button[ShelfPanel.selectedIndex]; // get the button that was selected to reach the drug select panel
        selectedButton.GetComponentInChildren<Text>().text = s; // set text of the button to the drug that has been assigned
        ShowGameObject.si.drug[ShelfPanel.selectedIndex] = s; // set the shelf data's name to the drug that has been assigned
        ShowGameObject.si.amount[ShelfPanel.selectedIndex] = 0; // reset amount to 0
        panel.SetActive(false); // hide panel after selection
    }
}
