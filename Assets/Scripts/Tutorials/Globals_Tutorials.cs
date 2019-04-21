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
    static int counter;

    public static Flags flags; // holds flags to save when various activities occur
    
    public static void displayTutorial()
    {

    }

    public static void generateTutorials()
    {
        int tutorialIndex = 0;
        pageIndex = 0;
        counter = 0;
        tutorial = new Tutorial[18];
        Tutorial[] t = tutorial;

        // 0
        tutorial[tutorialIndex] = new Tutorial(7);
        tutorial[tutorialIndex].addPage(pageIndex++, "Welcome to the Pharmacy!", sprite[counter++], 0, "In this game, you will manage and grow your pharmacy.\n\nBut first, lets introduce you to the basics.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Note on Saving", sprite[counter++], 0, "This game only autosaves and cannot be manually saved. You can close out of the game at any time and come back to where you were before.\n\nNOTICE: You must complete the tutorial before the game begins to autosave.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Tutorial", sprite[counter++], 0, "To start off the game, you will be taken through a tutorial where you must follow objectives as they appear.\n\nTap the tutorial button on the bottom right of the screen to view the current tutorial objective at any time.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Currency", sprite[counter++], 1, "As you play, your store will generate Gold (G) through sales.\n\nPlatinum (P), on the other hand, can only be earned at the end of each month.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Calendar", sprite[counter++], 1, "Each month lasts for x minutes. Next to the Calendar is the timer which shows how far you are currently into the month.\n\nAt the end of the month, all customers will leave the store and you will have to fill out a report before going to the next month.");
        tutorial[tutorialIndex].addPage(pageIndex++, "UI", sprite[counter++], 2, "There are several buttons which will lead you to different interfaces.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Shop Button", sprite[counter++], 0, "Your store is currently closed. Before you can open the store, you will need products for your customers to buy.\n\nTo purchase drugs, tap on the Store Button.");
        tutorialIndex++;
        pageIndex = 0;

        // 1
        tutorial[tutorialIndex] = new Tutorial(3);
        tutorial[tutorialIndex].addPage(pageIndex++, "Shop", sprite[counter++], 0, "The shop is where you can purchase drugs and hire employees");
        tutorial[tutorialIndex].addPage(pageIndex++, "Tooltips", sprite[counter++], 1, "You can tap a drug to purchase it.\n\nAlternatively, you can hold down the button to view a description of the drug.\n\nAlmost every button in the game has a tooltip, so if you need more information on something, hold the button down to find out more about it.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Purchase Drugs", sprite[counter++], 0,"Purchase Ventolin by tapping on it.");
        tutorialIndex++;
        pageIndex = 0;

        // 2
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Switch Tabs", sprite[counter++], 1, "Select the over-the-counter tab to view the list of available over-the-counter drugs you can buy.");
        tutorialIndex++;
        pageIndex = 0;

        // 3
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Purchase Drugs", sprite[counter++], 0, "Purchase Vitamin A by tapping on the button.");
        tutorialIndex++;
        pageIndex = 0;

        // 4
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Select Expansions Button", sprite[counter++], 0, "Now that you have purchased an over-the-counter drug you will need a shelf to display it.\n\nBut you have not unlocked shelves yet!\n\nTo unlock shelves, go to the Expansions Screen by tapping the Expansions Button.");
        tutorialIndex++;
        pageIndex = 0;

        // 5
        tutorial[tutorialIndex] = new Tutorial(2);
        tutorial[tutorialIndex].addPage(pageIndex++, "Expansions", sprite[counter++], 0, "The Expansions Screen is hwere you can unlock new items with Platinum (P).\n\nPlatinum (P) can be spent to unlock things such as new Drugs, Store Upgrades, and Services.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Services Tab", sprite[counter++], 1, "To unlock more shelves, tap on the Services Tab.");
        tutorialIndex++;
        pageIndex = 0;

        // 6
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Unlock Shelf", sprite[counter++], 0, "Tap the Shelf +1 button to unlock the shelf");
        tutorialIndex++;
        pageIndex = 0;

        // 7
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Inventory Button", sprite[counter++], 0, "Now that you have unlocked a shelf, you need to place it.\n\nTo do so, go to the Inventory Screen by tapping the Inventory Button.");
        tutorialIndex++;
        pageIndex = 0;

        // 8
        tutorial[tutorialIndex] = new Tutorial(2);
        tutorial[tutorialIndex].addPage(pageIndex++, "Inventory", sprite[counter++], 0, "The Inventory screen allows you to view the drugs you have in stock and the employees you have hired.\n\nThe Services Tab allows you to place down items you have unlocked.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Services Tab", sprite[counter++], 1, "Tap the Services Tab to find the shelf you unlocked.");
        tutorialIndex++;
        pageIndex = 0;

        // 9
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Place a Shelf", sprite[counter++], 2, "To place the shelf on the Storefront, tap the Shelf button.\n\nIf you hold the button down, you can view the Shelf tooltip, which will also show you how many more shelves you can place.");
        tutorialIndex++;
        pageIndex = 0;

        // 10
        tutorial[tutorialIndex] = new Tutorial(3);
        tutorial[tutorialIndex].addPage(pageIndex++, "Placing Objects", sprite[counter++], 2, "Find a spot to place the shelf.\n\nYou can tap anywhere on the screen to choose where to place the object.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Illegal Placements", sprite[counter++], 2, "If the object is red, then it is in a location that you cannot place it.\n\nYou cannot place objects in front of the store entrance and along the bottom-most row of the store.\n\nAlso, you cannot arrange objects in a way that will cut off the path from the store entrance to the bottom-most row of the store.");
        tutorial[tutorialIndex].addPage(pageIndex++, "The Buttons", sprite[counter++], 2, "When you have found a good spot, tap the green checkmark button to confirm the object's placement.\n\nYou can use the clockwise and counter-clockwise buttons to rotate the item.\n\nYou can use the garbage can to delete the object you have selected. (but for now, lets not do that)");
        tutorialIndex++;
        pageIndex = 0;

        // 11
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Return to Inventory", sprite[counter++], 0, "Now that you have placed the shelf, you should return to the Inventory Screen by tapping the left-most button.");
        tutorialIndex++;
        pageIndex = 0;

        // 12
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "OH DARN!", sprite[counter++], 0, "You actually didn't like where you placed the shelf and want to move it somewhere else!\n\nTo move your shelf (or any object you place in the future), tap the button on the top-right to enter edit mode.");
        tutorialIndex++;
        pageIndex = 0;

        // 13
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Move the Shelf", sprite[counter++], 2, "Now that you are back in Edit Mode. Tap the shelf to pick it up.\n\nOnce again decide where to place it, then tap the green arrow button to confrim the location.");
        tutorialIndex++;
        pageIndex = 0;

        // 14
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Exit Edit Mode", sprite[counter++], 0, "Now that you are completely, 100%, without a doubt, certain that your shelf is where you want it, exit Edit Mode.\n\nThis time, tap the back arrow at the top-left of the screen.\n\nThis button will return your storefront interface back to normal.\n\nThe button also appears on every screen and is used universally to return you to the Storefront.");
        tutorialIndex++;
        pageIndex = 0;

        // 15
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Assign Drugs to Shelf", sprite[counter++], 2, "You are almost ready to receive customers. There is one more thing you must do: stock the shelf with drugs.\n\nTo assign drugs to your shelf, tap the shelf.\n\nTapping the shelf will open an interface which will let you assign drugs to the shelf.\n\nEach shelf can hold 2 types of drugs. Tap one of the 2 buttons to assign Vitamin A to the shelf.");
        tutorialIndex++;
        pageIndex = 0;

        // 16
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Fill the Shelf", sprite[counter++], 2, "Now that the drug is assigned, you must fill the shelf.\n\nTo do so, tap the \"+\" Button to increase the amount of Vitamin A on the shelf.\n\nYou can only fill the shelf if you have enough of the item in stock.\n\nKeep in mind that customers will pick drugs up off the shelves and you will need to restock them. So keep an eye out on your shelf stocks!");
        tutorialIndex++;
        pageIndex = 0;

        // 17
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "The Store's Open!", sprite[counter++], 0, "Great! Your store is ready for customers. Customers will begin entering the store now.\n\nTry to keep them satisfied by keeping your drugs in stock, reducing their traveling/waiting time, and by unlocking additional services.\n\nIf you can keep your customers happy, more will show up to your store.\n\nNow that the store is open, continue playing until the end of the month.");
        tutorialIndex++;
        pageIndex = 0;
        
        pageIndex = 0;
    }
}
