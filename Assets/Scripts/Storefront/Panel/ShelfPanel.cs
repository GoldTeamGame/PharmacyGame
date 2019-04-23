// File: ShelfPanel
// Author: Alexander Jacks
// Last Modified: 4/17/19
// Version: 1.0.2
// Description: Displays shelf panel and contains shelf panel functions

using UnityEngine;
using UnityEngine.UI;

public class ShelfPanel : MonoBehaviour
{
    public static int totalAmount; // the number of a particular drug currently being displayed on the storefront
    public GameObject drugPanel; // the drug panel gameobject
    public static int selectedIndex; // the index of the button that was clicked (0 = first button, 1 = second button)
    public Sprite sprite; // the sprite representing the shelf

    // Remove panel
    public void remove(GameObject go)
    {
        ShowGameObject.isShowing = false; // Set to hiding state
        go.SetActive(false);
    }

    // Show DrugSelectPanel
    public void showDrugs(int index)
    {
        selectedIndex = index;
        ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>().text = "" + ShowGameObject.si.amount[0]; // set amount on first shelf panel
        ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>().text = "0";
        drugPanel.SetActive(true);
    }

    // Increase text amount
    public void increment(int index)
    {
        string drug = ShowGameObject.button[index].transform.GetChild(0).GetComponent<Text>().text;
        Text t = ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>();
        int i = ShowGameObject.si.amount[index];

        Drug d = (Drug)Item.find(1, drug);

        if (d != null)
        {
            int remainingDrugs = d.amount - getTotalAmount(d.name);
            if (remainingDrugs > 0 && i < 10)
            {
                if (Globals_Tutorials.tutorialIndex == 16)
                {
                    Globals_Tutorials.tutorialIndex++;
                    TutorialMonitor.isPopup = true;
                }

                i++;
                ShowGameObject.si.amount[index] = i;
            }
        }
        
        t.text = "" + i;
    }

    // Decrease text amount
    public void decrement(int index)
    {
        Text t = ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>();
        int i = ShowGameObject.si.amount[index];

        if (i > 0)
        {
            i--;
            ShowGameObject.si.amount[index] = i;
        }

        t.text = "" + i;
    }

    // Gets the total number of "s" placed on all shelves
    public static int getTotalAmount(string s)
    {
        totalAmount = 0;
        for (int i = 0; i < Globals_Items.storeData.Count; i++)
        {
            if (Globals_Items.storeData[i].drug[0].Equals(s))
                totalAmount += Globals_Items.storeData[i].amount[0];
            if (Globals_Items.storeData[i].drug[1].Equals(s))
                totalAmount += Globals_Items.storeData[i].amount[1];
        }
        return totalAmount;
    }
}
