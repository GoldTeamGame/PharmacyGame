using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMonitor : MonoBehaviour
{
    public GameObject[] go;
    public Sprite[] sprite;

    private void Start()
    {
        Globals_Tutorials.go = go;
        Globals_Tutorials.sprite = sprite;
        Globals_Tutorials.generateTutorials();
        Globals_Tutorials.tutorial[0].showCurrentPage();
    }

    // Monitors storefront activity
    void Update()
    {

    }

    public void nextPage()
    {
        if (Globals_Tutorials.pageIndex == Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].numberOfPages)
        {
            // hide panel
        }
        else
        {
            Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage();
        }
    }
}
