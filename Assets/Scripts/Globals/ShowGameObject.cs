// File: ShowGameObject
// Author: Alexander Jacks
// Last Modified: 4/17/19
// Version: 1.0.2
// Description: Script that goes on the shelf prefab. When the prefab is clicked, it will open the shelf menu
//                  and set the static gameobject as selected

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowGameObject : MonoBehaviour, IPointerClickHandler
{

    public static bool isShowing;
    public static StoreItems si;
    public static GameObject selectedObject; // the shelf currently being viewed (can be accessed from anywhere)
    public static GameObject[] button;


    // Function that fires when a shelf is clicked
    public void OnPointerClick(PointerEventData data)
    {
        //if (Globals_Tutorials.tutorialIndex == 15)
        //{
        //    Globals_Tutorials.tutorialIndex++;
        //    TutorialMonitor.isPopup = true;
        //}

        // Perform action if the game is not in the itemplacing state
        if (!(ItemPlacer.isPlacing || ItemPlacer.isSelecting) && SceneChanger.isAtStorefront)
        {
            // Get StoreItems component from gameobject
            si = GetComponent<Items>().s;

            // Get the 2 buttons from the ShelfPanel
            button = new GameObject[2];
            button[0] = ObjectReference.staticGo[0].transform.GetChild(1).gameObject; // get first button on shelf panel
            button[0].transform.GetChild(1).GetComponent<Text>().text = "" + si.amount[0]; // set amount on first shelf panel
            button[1] = ObjectReference.staticGo[0].transform.GetChild(2).gameObject; // get second button on shelf panel
            button[1].transform.GetChild(1).GetComponent<Text>().text = "" + si.amount[1]; // set amount on second shelf panel

            // Set the text of the buttons according to the drug information stored in StoreItems variable
            button[0].GetComponentInChildren<Text>().text = si.drug[0]; // set name of first button
            button[1].GetComponentInChildren<Text>().text = si.drug[1]; // set name of second button

            // Show the ShelfPanel
            ObjectReference.staticGo[0].SetActive(true);
            isShowing = true;
            selectedObject = gameObject; // set selectedObject
        }
    }

    public static void updateAmount()
    {
        if (isShowing)
        {
            button[0].transform.GetChild(1).GetComponent<Text>().text = "" + si.amount[0]; // set amount on first shelf panel
            button[1].transform.GetChild(1).GetComponent<Text>().text = "" + si.amount[1]; // set amount on second shelf panel
        }
    }
}
