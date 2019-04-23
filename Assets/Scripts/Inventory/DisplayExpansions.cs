/* 
 * File: DisplayExpansions
 * Authors: Dylan Cyphers, Alexander Jacks
 * Version 1.0.2
 * Date: 4/17/2019
 * Description: Display buttons on expansions scene depending on the selected tab
 * 
 */
 
using UnityEngine;
using UnityEngine.UI;

public class DisplayExpansions : MonoBehaviour
{
    public static int selected = 0;
    public Button[] set;
    public Button[] upgrade;
    public Button[] service;

    // sel == 0 -> display merchandise sets
    // sel == 1 -> display upgrades
    // sel == 2 -> display services
    public void SetSelector(int sel)
    {
        selected = sel;

        if (sel == 0)
        {
            display(set, true);
            display(upgrade, false);
            display(service, false);
        }
        else if (sel == 1)
        {
            display(set, false);
            display(upgrade, true);
            display(service, false);
        }
        else if (sel == 2)
        {
            display(set, false);
            display(upgrade, false);
            display(service, true);
        }
    }

    private void Start()
    {
        Globals_Items.createIsUnlocked(set.Length, upgrade.Length, service.Length); // Create isUnlocked if it hasn't been created

        // Disable items in set if that have been unlocked
        for (int i = 0; i < Globals_Items.isUnlocked[0].Length; i++)
            if (Globals_Items.isUnlocked[0][i])
                set[i].interactable = false;

        // Disable items in upgrades if that have been unlocked
        for (int i = 0; i < Globals_Items.isUnlocked[1].Length; i++)
            if (Globals_Items.isUnlocked[1][i])
                set[i].interactable = false;

        // Disable items in services if that have been unlocked
        for (int i = 0; i < Globals_Items.isUnlocked[2].Length; i++)
            if (Globals_Items.isUnlocked[2][i])
                set[i].interactable = false;

        // Disable all buttons
        display(set, false);
        display(upgrade, false);
        display(service, false);

        // Display set buttons
        SetSelector(0);
    }

    // Display all buttons in the passed in list
    public void display(Button[] list, bool willShow)
    {
        for (int i = 0; i < list.Length; i++)
            list[i].gameObject.SetActive(willShow);
    }
}
