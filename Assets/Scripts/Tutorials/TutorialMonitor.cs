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
        if (Globals_Tutorials.tutorialIndex == 0)
        {
            if (isPopup)
            {
                for (int i = 0; i < button.Length - 1; i++)
                    button[i].GetComponent<Button>().interactable = false;
                Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
                Globals_Tutorials.go[4].SetActive(true);
                isPopup = false;
            }
            if (isConfirm)
            {
                button[2].GetComponent<Button>().interactable = true;
                isConfirm = false;
            }
        }
        else if (Globals_Tutorials.tutorialIndex == 1)
        {
            if (isPopup)
            {
                Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
                Globals_Tutorials.go[4].SetActive(true);
                isPopup = false;
            }
            if (isConfirm)
            {
                for (int i = 0; i < TutorialMonitor_Extra.currentButtons.Length; i++)
                {
                    TutorialMonitor_Extra.currentButtons[i].GetComponent<Button>().interactable = false;
                }
                
                isConfirm = false;
            }
        }
        else if (Globals_Tutorials.tutorialIndex == 2)
        {
            if (isPopup)
            {
                Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
                Globals_Tutorials.go[4].SetActive(true);
                isPopup = false;
            }
            if (isConfirm)
            {
                TutorialMonitor_Extra.currentButtons[1].GetComponent<Button>().interactable = true;
                isConfirm = false;
            }
        }
        else if (Globals_Tutorials.tutorialIndex == 3)
        {
            if (isPopup)
            {
                Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
                Globals_Tutorials.go[4].SetActive(true);
                isPopup = false;
            }
            if (isConfirm)
            {
                isConfirm = false;
            }
        }
        else if (Globals_Tutorials.tutorialIndex == 4)
        {
            if (isPopup)
            {
                Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
                Globals_Tutorials.go[4].SetActive(true);
                isPopup = false;
            }
            if (isConfirm)
            {
                button[3].GetComponent<Button>().interactable = true;
                isConfirm = false;
            }
        }

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
