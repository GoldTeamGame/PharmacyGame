using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMonitor : MonoBehaviour
{
    public static bool isPopup;
    public static bool isConfirm;
    public GameObject[] go; // holds parts of the tutorial panel
    public Sprite[] sprite; // holds all sprites used in tutorial panels
    public static GameObject[] button;
    public GameObject[] _button;

    private void Start()
    {
        Globals_Tutorials.go = go;
        Globals_Tutorials.sprite = sprite;
        button = _button;
        Globals_Tutorials.generateTutorials();
        isPopup = true;
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
                for (int i = 0; i < button.Length - 1; i++)
                    button[i].GetComponent<Button>().interactable = false;
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
                button[8].GetComponent<Button>().interactable = false; // back to inventory
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
                isConfirm = false;
            }
        }
    }

    static void displayTutorial()
    {
        Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
        Globals_Tutorials.go[4].SetActive(true);
        isPopup = false;
    }

    public void viewCurrentTutorial()
    {
        Globals_Tutorials.pageIndex = 0;
        Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
        Globals_Tutorials.go[4].SetActive(true);
    }

    public void tutorialButton(int state)
    {
        if (state - 1 == Globals_Tutorials.tutorialIndex)
        {
            Globals_Tutorials.tutorialIndex++;
            isPopup = true;
        }
    }

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
