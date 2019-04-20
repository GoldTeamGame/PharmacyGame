using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globals_Tutorials
{
    public static Sprite[] sprite;

    public static GameObject[] go;

    public static Tutorial[] tutorial;
    public static int tutorialIndex;
    public static int pageIndex;

    public static Flags flags; // holds flags to save when various activities occur
    
    public static void displayTutorial()
    {

    }

    public static void generateTutorials()
    {
        tutorialIndex = 0;
        pageIndex = 0;
        tutorial = new Tutorial[1];
        tutorial[0] = new Tutorial(tutorialIndex, 7);
        tutorial[0].addPage(pageIndex, "Welcome to the Pharmacy!", sprite[pageIndex++], "In this game, you will manage and grow your pharmacy.\n\nBut first, lets introduce you to the basics.");
        tutorial[0].addPage(pageIndex, "Note on Saving", sprite[pageIndex++], "This game only autosaves and cannot be manually saved. You can close out of the game at any time and come back to where you were before.");
        tutorial[0].addPage(pageIndex, "Tutorial", sprite[pageIndex++], "To start off the game, you will be taken through a tutorial where you must follow objectives as they appear.\n\nTap the tutorial button on the bottom right of the screen to view the current tutorial objective at any time.");
        tutorial[0].addPage(pageIndex, "Currency", sprite[pageIndex++], "As you play, your store will generate Gold (G) through sales.\n\nPlatinum (P), on the other hand, can only be earned at the end of each month.");
        tutorial[0].addPage(pageIndex, "Calendar", sprite[pageIndex++], "Each month lasts for x minutes. Next to the Calendar is the timer which shows how far you are currently into the month.\n\nAt the end of the month, all customers will leave the store and you will have to fill out a report before going to the next month.");
        tutorial[0].addPage(pageIndex, "UI", sprite[pageIndex++], "There are several buttons which will lead you to different interfaces.");
        tutorial[0].addPage(pageIndex, "Select the Shop Button", sprite[pageIndex++], "Your store is currently closed. Before you can open the store, you will need products for your customers to buy.\n\nTo purchase drugs, tap on the Store Button.");

        tutorialIndex = 1;
        pageIndex = 0;



        tutorialIndex = 0;
    }
}
