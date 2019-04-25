// File: TutorialMonitor
// Authors: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.0.1
// Description: Monitors state of tutorial and takes tutorial related data from the inspector.
//          Also holds various tutorial related functions.

using UnityEngine;
using UnityEngine.UI;

public class TutorialMonitor : MonoBehaviour
{
    public static bool doesSaveExist;
    public static bool isActive; // is the tutorial activated from the inspector?
    public bool _isActive; 
    public static bool isPopup; // will the Tutorial Panel need to pop up?
    public static bool isConfirm; // has the last page of a tutorial been clicked?
    public GameObject[] go; // holds parts of the tutorial panel
    public Sprite[] sprite; // holds all sprites used in tutorial panels
    public Sprite[] sprite_Button; // holds all sprites used in tutorial_Button panels
    public static GameObject[] button; // holds buttons that need to be activated/de-activated to force player down the tutorials path
    public GameObject[] _button;

    private void Start()
    {
        isActive = _isActive; // set static isActive to what is in the inspector
        Globals_Tutorials.go = go; // set static go from Globals_Tutorials to what is in the inspector
        Globals_Tutorials.sprite = sprite; // set static sprite from Globals_Tutorials to what is in the inspector
        Globals_Tutorials.sprite_Button = sprite_Button; // set state sprite_Button from Globals_Tutorials to what is in the inspector
        button = _button; // set static button equal to what is in the inspector
        Globals_Tutorials.generateTutorials(); // generate all tutorials (Hardcoded)

        if (!doesSaveExist)
        {
            // if tutorialIndex is 0 and the isActive is checked to true, then start the game with the tutorial
            if (Globals_Tutorials.tutorialIndex == 0 && isActive)
            {
                Globals.playerGold = 7;

                // de-activate all buttons
                for (int i = 0; i < button.Length - 1; i++)
                    button[i].GetComponent<Button>().interactable = false;

                isPopup = true; // make tutorial pop-up
                button[7].GetComponent<Button>().interactable = true; // set tutorial button to active
                button[10].GetComponent<Button>().interactable = true; // set tutorial button to active
                //button[14].SetActive(true); // set tutorial button to active
            }
            // if tutorial is not active, then go into dev mode
            else if (!isActive)
            {
                Globals.playerGold = 10000;
                Globals.playerPlatinum = 100;
                Globals_Customer.limit = 10;
                Globals_Tutorials.tutorialIndex = 18;
            }
        }
    }

    // Monitors storefront activity
    void Update()
    {
        // Format...
        // When tutorialIndex is changed (usually from button click using tutorialButton script)
        // Cause the tutorial screen to pop-up.
        // When reaching the end of the tutorial (tapping OK) will cause isConfirm to trigger and will transition to the next tutorialIndex

        // Introduction
        // Objective: Go to shop
        if (Globals_Tutorials.tutorialIndex == 0)
        {
            if (isPopup)
            {
                displayTutorial();
            }
            if (isConfirm)
            {
                button[2].GetComponent<Button>().interactable = true; // shop
                isConfirm = false;
            }
        }

        // Objective: Purchase Ventolin
        else if (Globals_Tutorials.tutorialIndex == 1)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                TutorialMonitor_Extra.currentButtons[1].GetComponent<Button>().interactable = false; // over counter
                TutorialMonitor_Extra.currentButtons[2].GetComponent<Button>().interactable = false; // staff

                button[2].GetComponent<Button>().interactable = false; // shop
                isConfirm = false;
            }
        }

        // Objective: Change to over counter tab
        else if (Globals_Tutorials.tutorialIndex == 2)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                TutorialMonitor_Extra.currentButtons[1].GetComponent<Button>().interactable = true; // over counter
                isConfirm = false;
            }
        }

        // Objective: Purchase Vitamin A
        else if (Globals_Tutorials.tutorialIndex == 3)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
                isConfirm = false;
        }

        // Objective: Go to expansions
        else if (Globals_Tutorials.tutorialIndex == 4)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[3].GetComponent<Button>().interactable = true; // expansions
                isConfirm = false;
            }
        }

        // Objective: Switch to Services Tab
        else if (Globals_Tutorials.tutorialIndex == 5)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[3].GetComponent<Button>().interactable = false; // expansions
                isConfirm = false;
            }
        }

        // Objective: Unlock Shelf
        else if (Globals_Tutorials.tutorialIndex == 6)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                isConfirm = false;
            }
        }

        // Objective: Go to Inventory
        else if (Globals_Tutorials.tutorialIndex == 7)
        {
            if (isPopup)
            {
                displayTutorial();
            }
            if (isConfirm)
            {
                button[1].GetComponent<Button>().interactable = true; // inventory
                isConfirm = false;
            }
        }

        // Objective: switch to Services Tab
        else if (Globals_Tutorials.tutorialIndex == 8)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[1].GetComponent<Button>().interactable = false; // inventory
                TutorialMonitor_Extra.currentButtons[3].GetComponent<Button>().interactable = false; // edit mode
                isConfirm = false;
            }
        }

        // Objective: Tap Shelf button
        else if (Globals_Tutorials.tutorialIndex == 9)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                isConfirm = false;
            }
        }

        // Objective: Place shelf
        else if (Globals_Tutorials.tutorialIndex == 10)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[10].GetComponent<Button>().interactable = true; // rotiation
                button[11].GetComponent<Button>().interactable = true; // rotation
                button[12].GetComponent<Button>().interactable = true; // confirm
                isConfirm = false;
            }
        }

        // Objective: Go back to inventory
        else if (Globals_Tutorials.tutorialIndex == 11)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[8].GetComponent<Button>().interactable = true; // back to inventory
                isConfirm = false;
            }
        }

        // Objective: Enter edit mode
        else if (Globals_Tutorials.tutorialIndex == 12)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[8].GetComponent<Button>().interactable = false; // back to inventory
                TutorialMonitor_Extra.currentButtons[3].GetComponent<Button>().interactable = true; // edit mode
                isConfirm = false;
            }
        }

        
        else if (Globals_Tutorials.tutorialIndex == 13)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                
                isConfirm = false;
            }
        }

        // Objective: Move shelf
        else if (Globals_Tutorials.tutorialIndex == 13)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                isConfirm = false;
            }
        }

        // Objective: Go back to storefront
        else if (Globals_Tutorials.tutorialIndex == 14)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                button[13].GetComponent<Button>().interactable = true; // back to storefront
                isConfirm = false;
            }
        }

        // Objective: Assign drug to shelf
        else if (Globals_Tutorials.tutorialIndex == 15)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                isConfirm = false;
            }
        }

        // Objective: Stock the shelf
        else if (Globals_Tutorials.tutorialIndex == 16)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                isConfirm = false;
            }
        }
        
        // The Store is open!
        else if (Globals_Tutorials.tutorialIndex == 17)
        {
            if (isPopup)
                displayTutorial();
            if (isConfirm)
            {
                Globals.playerGold = 50;
                Globals_Customer.limit = 2;
                for (int i = 0; i < button.Length; i++)
                    button[i].GetComponent<Button>().interactable = true;
                button[14].SetActive(false);
                button[6].GetComponent<Button>().interactable = false;
                isConfirm = false;
                Globals_Tutorials.tutorialIndex++;
                Clock.start(); // start timer
            }
        }
    }

    // Displays the appropriate Tutorial screen, then sets isPopup to false that way this function is not repeatedly called
    public static void displayTutorial()
    {
        Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
        Globals_Tutorials.go[4].SetActive(true);
        isPopup = false;
    }

    // Shows the tutorial screen, and resets the page index
    public void viewCurrentTutorial()
    {
        if (Globals_Tutorials.tutorialIndex < 18)
        {
            Globals_Tutorials.pageIndex = 0;
            Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
            Globals_Tutorials.go[4].SetActive(true);
        }
    }

    // Used on various buttons to progress the tutorial to the next state
    public void tutorialButton(int state)
    {
        staticTutorialButton(state);
    }

    public static void staticTutorialButton(int state)
    {
        if (state - 1 == Globals_Tutorials.tutorialIndex)
        {
            Globals_Tutorials.tutorialIndex++;
            Debug.Log("Current State: " + Globals_Tutorials.tutorialIndex);
            isPopup = true;
        }
    }

    // Flip to next page in the tutorial
    public void nextPage()
    {
        if (Globals_Tutorials.pageIndex == Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].numberOfPages)
        {
            // hide panel
            Globals_Tutorials.go[4].SetActive(false);
            Globals_Tutorials.pageIndex = 0;
            isConfirm = true;
        }
        else
        {
            Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
        }
    }
}
