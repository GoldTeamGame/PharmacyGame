using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPharmacist : MonoBehaviour
{
    public GameObject pharmacist;
    public GameObject panel;
    public Button b;
    public static bool needToUpdate; // a check to see if the drug list needs to be updated
    public bool[] exist; // a check to see if the button has already been added to the list (this array matches up with the overCounterList)

    private void Start()
    {
        exist = new bool[Globals_Items.item[2].Length];
        needToUpdate = true;
    }

    private void Update()
    {
        // Update if gameobject is active
        if (gameObject.activeSelf)
        {
            // Update if needToUpdate is set to true
            if (needToUpdate)
            {
                // Loop through all overCounterList drugs
                for (int i = 0; i < Globals_Items.item[2].Length; i++)
                {
                    // If a button for the drug has not been added to the list
                    // and the drug has been unlocked,
                    // Then create a button and add it to the list
                    if (!exist[i] && ((Pharmacist)Globals_Items.item[2][i]).isUnlocked)
                    {
                        exist[i] = true; // set that the button exists
                        Button newButton = Instantiate(b, transform); // instantiate the button in the list
                        string s = Globals_Items.item[2][i].name; // get the name of the drug
                        newButton.transform.GetChild(0).GetComponent<Text>().text = s; // set the button text to the drug name
                        newButton.onClick.AddListener(delegate { assign(s); }); // add the function to the button
                    }
                }
                needToUpdate = false; // Set need to update to false after adding buttons to list (prevents unecessary repetition)
            }
        }
    }

    public void remove(GameObject go)
    {
        needToUpdate = true;
        go.SetActive(false);
    }

    public void assign(string name)
    {
        Pharmacist p = (Pharmacist)Item.find(2, name);

        // Find counter to assign pharmacist to
        string counterName = CounterInteraction.name;
        int counter = -1;
        if (counterName.Equals("PharmacistZone1"))
            counter = 0;
        else if (counterName.Equals("PharmacistZone2"))
            counter = 1;
        else if (counterName.Equals("PharmacistZone3"))
            counter = 2;

        // Do nothing if pharmacist is already assigned to counter
        if (p.counter != counter)
        {
            // If pharmacist has already been placed, first clear pharmacist from zone being moved from (p.counter)
            if (p.counter != -1)
            {
                Globals_Pharmacist.pharmacistCounter[p.counter].isPharmacist = false; // tell customers that there is no longer a pharmacist at the counter
                Globals_Pharmacist.pharmacistCounter[p.counter].isCustomer = false;
                Globals_Pharmacist.pharmacistCounter[p.counter].numberInLine = 0;
                //Globals_Pharmacist.pharmacistCounter[p.counter].isFinished = false;
                p.reset(counter);
                Destroy(Globals_Pharmacist.pharmacistGo[p.counter]); // destroy the gameobject
            }
            
            // If a pharmacist exists in the place being assigned a pharmacist, then remove the one who was there before
            if (Globals_Pharmacist.pharmacistGo[counter] != null)
                // Find the pharmacist who is being replaced
                for (int i = 0; i < Globals_Items.item[2].Length; i++)
                {
                    if (((Pharmacist)Globals_Items.item[2][i]).counter == counter)
                    {
                        ((Pharmacist)Globals_Items.item[2][i]).counter = -1; // set pharmacist who is being replaced to "unassigned" state
                        ((Pharmacist)Globals_Items.item[2][i]).reset(-1);
                        Destroy(Globals_Pharmacist.pharmacistGo[counter]); // destroy the game object
                        break; // break out of loop
                    }
                }
            p.counter = counter; // set new counter location

            // Find position of pharmacist
            Position pos;
            if (p.currentState == -1 || p.currentState > 2)
                pos = Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[0];
            else
                pos = Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[p.currentState];
            
            GameObject go = Instantiate(pharmacist, ObjectReference.staticGo[2].transform); // instantiate object
            go.transform.localPosition = new Vector3(pos.x, pos.y); // set position
            go.GetComponent<PharmacistController>().p = p; // set Pharmacist
            go.GetComponent<SpriteRenderer>().sprite = PharmacistGenerator.STATIC_APPEARANCE[p.appearance];
            go.transform.localScale = new Vector3(2.25f, 2.25f, 0); // set customer sprite size (make it bigger)
            Globals_Pharmacist.pharmacistGo[counter] = go; // set pharmacist game object
            Globals_Pharmacist.pharmacistCounter[counter].isPharmacist = true; // Tell customers that there is a pharmacist at the counter
        }

        panel.SetActive(false); // hide selection panel
    }
}
