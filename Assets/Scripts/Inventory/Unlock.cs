using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Unlock : MonoBehaviour {

    public void unlockExpansion()
    {

        //int numberOfButtons = transform.childCount; // number of buttons in the container
        //GameObject child = EventSystem.current.currentSelectedGameObject;

        //int index = 0; // index with respect to the parent

        //// Set index to where it needs to start based on what list is being checked
        //if (DisplayExpansions.selected == 1)
        //    index = Globals_Items.isUnlocked[0].Length; // add amount of sets
        //else if (DisplayExpansions.selected == 2)
        //    index = Globals_Items.isUnlocked[0].Length + Globals_Items.isUnlocked[1].Length; // add amounts of sets + upgrades

        //for (int i = 0; i < Globals_Items.isUnlocked[DisplayExpansions.selected].Length; i++, index++)
        //    if (transform.GetChild(index).Equals(child.transform))
        //    {
        //        Globals_Items.isUnlocked[DisplayExpansions.selected][i] = true;
        //        child.GetComponent<Button>().interactable = false;
        //    }
    }
}
