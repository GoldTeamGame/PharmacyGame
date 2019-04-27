// File: Globals_Tutorials
// Authors: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.0.1
// Description: Holds tutorial data that is used everywhere else.
//          It is also where all the tutorials are progrmatically generated (hard-coded)

using UnityEngine;

public class Globals_Tutorials
{
    public static Sprite[] sprite; // holds all sprites used in the tutorials
    public static Sprite[] sprite_Button; // holds all sprites for tutorial_Button

    public static GameObject[] go; // holds important parts of the Tutorial Screen

    public static Tutorial[] tutorial; // holds all tutorials
    public static int tutorialIndex; // the current tutorial[] element being viewed 
    public static int pageIndex; // the current page in the tutorial[] element being viewed
    static int counter; // a count variable used to match every sprite[] element with every tutorial page

    // Programmatically generate all tutorials (Hard-coded)
    public static void generateTutorials()
    {
        int tutorialIndex = 0;
        pageIndex = 0;
        counter = 0;
        tutorial = new Tutorial[30];
        Tutorial[] t = tutorial;

        // 0
        tutorial[tutorialIndex] = new Tutorial(7);
        tutorial[tutorialIndex].addPage(pageIndex++, "Welcome to the Pharmacy!", sprite[counter++], 0, "In this game, you will manage and grow your pharmacy.\n\nBut first, lets introduce you to the basics.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Note on Saving", sprite[counter++], 0, "This game only autosaves and cannot be manually saved. You can close out of the game at any time and come back to where you were before.\n\nNOTICE: You must complete the tutorial before the game begins to autosave.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Tutorial", sprite[counter++], 0, "To start off the game, you will be taken through a tutorial where you must perform tasks after reading the directions and pressing \"OK\".\n\nTap the tutorial button on the bottom right of the screen to view the current tutorial directions at any time.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Currency", sprite[counter++], 1, "As you play, your store will generate Gold (G) via sales of drugs.\n\nPlatinum (P), on the other hand, can only be earned at the end of each month.\n\nWhat these currencies can be spent on will be explained later.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Calendar", sprite[counter++], 1, "Each month lasts for 8 minutes. Next to the Calendar is the timer which shows how far you are currently into the month.\n\nAt the end of the month, all customers will leave the store and you will have to complete a report before starting the next month.");
        tutorial[tutorialIndex].addPage(pageIndex++, "UI", sprite[counter++], 2, "There are several buttons which will lead you to different interfaces.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Shop Button", sprite[counter++], 0, "The shelves in your pharmacy are currently empty. Before you can open the store, you will need products before you can serve your customers.\n\nTo purchase drugs, you need to go to the shop. After clicking/tapping OK, click/tap on the Shop Button.");
        tutorialIndex++;
        pageIndex = 0;

        // 1
        tutorial[tutorialIndex] = new Tutorial(3);
        tutorial[tutorialIndex].addPage(pageIndex++, "Shop", sprite[counter++], 0, "You are now at the Shop. The Shop is where you can purchase drugs and hire staff. The shop is where gold is spent");
        tutorial[tutorialIndex].addPage(pageIndex++, "Tooltips", sprite[counter++], 1, "You can tap a drug (or any item) to purchase it.\n\nAlternatively, you can hold down the button to view a description of the drug.\n\nAlmost every button in the game has a tooltip, so if you need more information on something, hold the button down to find out more about it.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Purchase Drugs", sprite[counter++], 0, "After clicking OK, purchase Amlodipine Besylate 10mg by clicking on it. (Notice your gold count at the top-left of the screen will decrease afting purchasing the drug)");
        tutorialIndex++;
        pageIndex = 0;

        // 2
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Switch Tabs", sprite[counter++], 1, "You have just purchased Amlodipine Besylate 10mg. The drug you have just purchased was a prescription drug, but customers will also be interested in over-the-counter drugs.\n\nAfter clicking OK, select the over-the-counter tab to view the list of available over-the-counter drugs you can buy.");
        tutorialIndex++;
        pageIndex = 0;

        // 3
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Purchase Drugs", sprite[counter++], 0, "Now that you have clicked the Over Counter tab, you can see the over-the-counter drugs available for purchase.\n\nAfter clicking OK, tap the Vitamin A button to purchase it.");
        tutorialIndex++;
        pageIndex = 0;

        // 4
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Select Expansions Button", sprite[counter++], 0, "You have just purchased an over-the-counter drug. Prescription drugs will be sold by the pharmacists, but over-the-counter drugs must be stocked onto shelves. Currently, you have not unlocked shelves.\n\nTo unlock shelves, go to the Expansions Screen. To get there, first click OK, then click the Expansions Button.");
        tutorialIndex++;
        pageIndex = 0;

        // 5
        tutorial[tutorialIndex] = new Tutorial(4);
        tutorial[tutorialIndex].addPage(pageIndex++, "Expansions", sprite[counter++], 0, "Now you are at the Expansions Screen. The Expansions Screen is where you can unlock things for your pharmacy with Platinum (P).\n\nPlatinum (P) can be spent to unlock things such as new Drugs, Store Upgrades, and Services.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Sets Tab", null, 1, "The Sets Tab shows you drug sets that you can unlock. Unlocking drug sets will allow you to purchase additional drugs in the shop screen.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Upgrades Tab", null, 1, "The Upgrades Tab shows you store upgrades that you can unlock. Upgrades are permanant bonuses for your stores.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Services Tab", sprite[counter++], 1, "The Services Tab shows you placeable objects that you can unlock. This is the tab where you will be able to unlock shelves.\n\nTo unlock shelves for your store, first click the OK button, then click on the Services Tab.");
        tutorialIndex++;
        pageIndex = 0;

        // 6
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Unlock Shelf", sprite[counter++], 0, "You will now see a list of unlockable services. After clicking OK, click the Shelf button to unlock the shelf");
        tutorialIndex++;
        pageIndex = 0;

        // 7
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Inventory Button", sprite[counter++], 0, "Now that you have unlocked shelves, you need to place it.\n\nTo do so, first click OK, then go to the Inventory Screen by clicking the Inventory Button.");
        tutorialIndex++;
        pageIndex = 0;

        // 8
        tutorial[tutorialIndex] = new Tutorial(2);
        tutorial[tutorialIndex].addPage(pageIndex++, "Inventory", sprite[counter++], 0, "You are now at the Inventory Screen. The Inventory Screen allows you to view the drugs you have in stock and the employees you have hired.\n\nIt is also where you can place the services you have unlocked from the Expansions Screen.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Select the Services Tab", sprite[counter++], 1, "After clicking OK, tap the Services Tab to find the shelf you have unlocked.");
        tutorialIndex++;
        pageIndex = 0;

        // 9
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Place a Shelf", sprite[counter++], 2, "Now that you have changed tabs, you will see the shelf button.\n\nAfter clicking OK, click the shelf button to place the shelf onto the Storefront.");
        tutorialIndex++;
        pageIndex = 0;

        // 10
        tutorial[tutorialIndex] = new Tutorial(4);
        tutorial[tutorialIndex].addPage(pageIndex++, "Placing Objects", sprite[counter++], 2, "After this part of the tutorial, you will be able to place the shelf down.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Illegal Placements", sprite[counter++], 2, "If the object is red, then it is in a location that you cannot place it.\n\nYou cannot place objects in front of the store entrance and along the bottom-most row of the store.\n\nAlso, you cannot arrange objects in a way that will cut off the path from the store entrance to the bottom-most row of the store.");
        tutorial[tutorialIndex].addPage(pageIndex++, "The Buttons", sprite[counter++], 2, "When you have found a good spot, tap the green checkmark button to confirm the object's placement.\n\nYou can use the clockwise and counter-clockwise buttons to rotate the item.\n\nYou can use the garbage can to delete the object you have selected. (but for now, lets not do that)");
        tutorial[tutorialIndex].addPage(pageIndex++, "Place the Shelf", null, 2, "After clicking OK, place your shelf by clicking anywhere on the Storefront. If the Shelf is not red, then click the green confirm arrow to confirm your shelf's position.");
        tutorialIndex++;
        pageIndex = 0;

        // 11
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Return to Inventory", sprite[counter++], 0, "Now that you have placed the shelf, you should return to the Inventory Screen by tapping the inventory button.");
        tutorialIndex++;
        pageIndex = 0;

        // 12
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Move the Shelf", sprite[counter++], 0, "Suppose you didn't like where you placed the shelf and want to move it somewhere else!\n\nTo move your shelf (or any object you place in the future), click the button on the top-right to enter edit mode. (After clicking OK)");
        tutorialIndex++;
        pageIndex = 0;

        // 13
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Move the Shelf", sprite[counter++], 2, "Now that you are back in Edit Mode, you will need to click the shelf to pick it up.\n\nOnce again decide where to place it, then click the green arrow button to confrim the location.");
        tutorialIndex++;
        pageIndex = 0;

        // 14
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Exit Edit Mode", sprite[counter++], 0, "You have just moved your shelf. Now that you are certain that your shelf is where you want it, exit Edit Mode.\n\nThis time, you should click the \"Back Button\".\n\nThis button will return your storefront interface back to normal.\n\nThe button also appears on every screen and is used universally to return you to the Storefront. Now, click OK, then click the Back Button at the top-left of the screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 15
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Assign Drugs to Shelf", sprite[counter++], 2, "You have now exited Edit Mode. You are almost ready to receive customers. There is one more thing you must do: stock the shelf with drugs.\n\nTo assign drugs to your shelf, click the shelf.\n\nClicking the shelf will open an interface which will let you assign drugs to the shelf.\n\nEach shelf can hold 2 types of drugs. Click one of the 2 buttons to assign Vitamin A to the shelf.\n\nNow click OK, then click the shelf and assign it Vitamin A");
        tutorialIndex++;
        pageIndex = 0;

        // 16
        tutorial[tutorialIndex] = new Tutorial(1);
        tutorial[tutorialIndex].addPage(pageIndex++, "Fill the Shelf", sprite[counter++], 2, "Now that the drug is assigned, you must fill the shelf.\n\nTo do so, click the \"+\" Button to increase the amount of Vitamin A on the shelf.\n\nYou can only fill the shelf if you have enough of the item in stock.\n\nKeep in mind that customers will pick drugs up off the shelves and you will need to restock them. So keep an eye out on your shelf stocks! Now click OK, then click the + button to stock the shelf.");
        tutorialIndex++;
        pageIndex = 0;

        // 17
        tutorial[tutorialIndex] = new Tutorial(2);
        tutorial[tutorialIndex].addPage(pageIndex++, "The Store's Open!", sprite[counter++], 0, "Great! Your store is ready for customers. Customers will begin entering the store now.\n\nTry to keep them satisfied by keeping your drugs in stock, reducing their traveling/waiting time, and by unlocking additional services.\n\nIf you can keep your customers happy, more will show up to your store.\n\nThe goal of the game is to make lots of gold, improve your pharmacy, and correctly complete the end of the month reports.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Continue Playing", null, 0, "Now customers will begin entering the store and buying your products.\n\nThe rest of the buttons are now unlocked, so feel free to explore the rest of the game. Remember, if you are ever confused about something, use the Tutorial Button.\n\nNow continue playing until the end of the month (8:00 minutes).");
        tutorialIndex++;
        pageIndex = 0;

        counter = 0;
        // 18
        // Storefront
        tutorial[tutorialIndex] = new Tutorial(8);
        tutorial[tutorialIndex].addPage(pageIndex++, "Storefront Screen", null, 0, "The Storefront Screen is where you can view your actual pharmacy. From here you can watch customers enter and interact with your store.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Currency", sprite_Button[counter++], 1, "As time goes by, your store will generate Gold (G) through sales.\n\nPlatinum (P), on the other hand, can only be earned at the end of each month.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Calendar", sprite_Button[counter++], 1, "Each month lasts for 10 minutes. Next to the Calendar is the timer which shows how far you are currently into the month.\n\nAt the end of the month, all customers will leave the store and you will have to fill out a report before going to the next month.");
        tutorial[tutorialIndex].addPage(pageIndex++, "UI", sprite_Button[counter++], 2, "The buttons you see below the storefront screen can be selected to bring you to other screens.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Assigning Drugs", sprite_Button[counter++], 2, "If you have a shelf on the storefront, you can assign drugs that you have unlocked to it.\n\nTo do so, tap the shelf to open the 'Assign Drug' window.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Assigning Pharmacists", sprite_Button[counter++], 2, "You can tap the pharmacist counter");
        tutorial[tutorialIndex].addPage(pageIndex++, "Tutorial", sprite_Button[counter++], 0, "You can press the tutorial button at the bottom-right to view a tutorial messsage.\n\nThe tutorial message you see will depend on the screen that you are currently on. So click on the tutorial button whenver you feel confused about something.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Note on Saving", null, 0, "This game only autosaves and cannot be manually saved. You can close out of the game at any time and come back to where you were before.");
        tutorialIndex++;
        pageIndex = 0;

        // 19
        // Storefront - Inventory
        tutorial[tutorialIndex] = new Tutorial(6);
        tutorial[tutorialIndex].addPage(pageIndex++, "Edit Mode", sprite_Button[counter++], 0, "You are currently in Edit Mode. In this mode, you can manipulate the objects that are placed on the storefront.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Picking up Objects", sprite_Button[counter++], 2, "Now that you are back in Edit Mode. Tap the shelf to pick it up.\n\nOnce again decide where to place it, then tap the green arrow button to confrim the location.");
        tutorial[tutorialIndex].addPage(pageIndex++, "The Buttons", sprite_Button[counter++], 2, "Notice the Buttons below the storefront have changed.\n\nThe green checkmark is used to confirm the location of an object you have picked up.\n\nThe clockwise\\counter-clockwise arrows can be used to rotate the object you have picked up.\n\nThe garbage can is used to delete the object you have selected.\n\nThe Inventory Button will bring you back to the inventory screen.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Placing Objects", sprite_Button[counter++], 0, "When the object you have selected is transparent, that means you can use the green checkmark to confirm the objects location.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Illegal Placements", sprite_Button[counter++], 2, "If the object is red, then it is in a location that you cannot place it.\n\nYou cannot place objects in front of the store entrance and along the bottom-most row of the store.\n\nAlso, you cannot arrange objects in a way that will cut off the path from the store entrance to the bottom-most row of the store.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "The back button will simply exit the edit mode.");
        tutorialIndex++;
        pageIndex = 0;

        // 20
        // Storefront - Report
        tutorial[tutorialIndex] = new Tutorial(3);
        tutorial[tutorialIndex].addPage(pageIndex++, "Report!", null, 0, "It has currently reached the end of the month. At this point in time, all of your customers have been kicked out of the store.");
        tutorial[tutorialIndex].addPage(pageIndex++, "The Buttons", sprite_Button[counter++], 2, "Notice the Buttons below the storefront have changed. With these buttons you can view your previous reports, view your current statistics, go the the report, and use the tutorial button.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Start Report", sprite_Button[counter++], 0, "In order to continue playing, you must tap the Report Button and fill out the report.");
        tutorialIndex++;
        pageIndex = 0;

        // 21
        // Customer
        tutorial[tutorialIndex] = new Tutorial(5);
        tutorial[tutorialIndex].addPage(pageIndex++, "Customer Screen", sprite_Button[counter++], 0, "The Customer Screen is where you can view all customers currently in your store, how they are feeling, and what they want to purchase.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Mood Rating", sprite_Button[counter++], 2, "Customer Mood Rating is a value out of 100 that indicates how happy a customer is.\n\nMood gets lower as customers cannot find what they are looking for and get higher when they can find what they are looking for.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Overall Mood Rating", null, 0, "The higher the overall mood rating is, the more customers will enter your store, thus, the more products you can sell.\n\nTry to keep your customers happy to make the store flourish.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Customer Information", null, 0, "By clicking a customer's button, you can view what they want they are currently doing and what they want to buy.\n\nTry to provide them with everything they want.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "Tap the back button to go back to the storefront screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 22
        // Inventory
        tutorial[tutorialIndex] = new Tutorial(6);
        tutorial[tutorialIndex].addPage(pageIndex++, "Inventory", sprite_Button[counter++], 0, "The Inventory Screen is where you can view everything you own as well as the people you have hired.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Stock Tab", sprite_Button[counter++], 1, "The Stock Tab is where you can view all the drugs you own.\n\nIf a drug is not unlocked, it will not show up in the list.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Staff Tab", sprite_Button[counter++], 1, "The Staff Tab is where you can view the employees you have hired at a glance.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Services Tab", sprite_Button[counter++], 1, "The Services Tab is you can place down the services that you have unlocked.\n\nTo place them, select the button and you will be sent to the storefront to place the item.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Edit Mode Button", sprite_Button[counter++], 0, "You can access edit mode by tapping the Edit Mode Button.\n\nEdit Mode will let you move items around on the storefront.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "Tap the back button to go back to the storefront screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 23
        // Shop
        tutorial[tutorialIndex] = new Tutorial(7);
        tutorial[tutorialIndex].addPage(pageIndex++, "Shop Screen", sprite_Button[counter++], 0, "The Shop Screen is where you can purchase items with gold.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Prescription Tab", sprite_Button[counter++], 1, "The Prescription Tab is where you can purchase prescription drugs that you have unlocked.\n\nPrescription drugs are held behind the Pharmacist Counters.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Over Counter Tab", sprite_Button[counter++], 1, "The Over Counter Tab is where you can purchase over the counter drugs that you have unlocked.\n]nOver the Counter drugs must be stocked on shelves in order to be sold.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Staff Tab", sprite_Button[counter++], 1, "The Staff Tab is where you can hire pharmacists to work at your store.\n\nHiring a pharmacist is a one time transaction, so they will continue working for you without needing to be paid again!");
        tutorial[tutorialIndex].addPage(pageIndex++, "Pharmacist Stats", sprite_Button[counter++], 2, "Each pharmacist has their own stats that determine how fast they process customer transactions.\n\nPharmacists with better stats can sell drugs faster to prevent long lines which will make you more money per month.\n\nYou can view a pharmacist's stats by viewing their tooltip.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Assigning Pharmacists", null, 1, "Pharmacists can be assigned while at the Storefront Screen. Assign the pharmacist by tapping the pharmacist counter and then selecting the pharmacist in the list that pops up.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "Tap the back button to go back to the storefront screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 24
        // Expansions
        tutorial[tutorialIndex] = new Tutorial(5);
        tutorial[tutorialIndex].addPage(pageIndex++, "Expansions Screen", sprite_Button[counter++], 0, "The Expansions Screen is where you can unlock items with Platinum.\n\nPlatinum is earned from reports that you do at the end of the month.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Sets Tab", sprite_Button[counter++], 1, "The Sets Tab is where you can unlock drug sets.\n\nAfter unlocking the drugs, you can then purchase them at the shop.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Upgrades Tab", sprite_Button[counter++], 1, "The Upgrades Tab is where you can unlock permanent store upgrades.\n\nThese upgrades give you a variety of benefits such increasing the value of your goods, making your pharmacist's more efficient, unlocking more pharmacist counters, and more!");
        tutorial[tutorialIndex].addPage(pageIndex++, "Services Tab", sprite_Button[counter++], 1, "The Services Tab is where you can unlock placeable services.\n\nThese services can make your customer's happier and give your store more decor.\n\nServices that have been unlocked can be placed by visiting the Inventory Screen.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "Tap the back button to go back to the storefront screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 25
        // Previous Reports
        tutorial[tutorialIndex] = new Tutorial(3);
        tutorial[tutorialIndex].addPage(pageIndex++, "Previous Reports", sprite_Button[counter++], 0, "The Previous Reports Screen is where you can view the reports that you have previously finished and see the grades you have received.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Viewing Previous Reports", sprite_Button[counter++], 2, "To View the report, tap the button");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "Tap the back button to go back to the storefront screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 26
        // Statistics
        tutorial[tutorialIndex] = new Tutorial(5);
        tutorial[tutorialIndex].addPage(pageIndex++, "Statistics Screen", sprite_Button[counter++], 0, "The Statistics Screen is where you can view various financial reports and values associated with them.\n\nEach field can be tapped and held down to view a description of the field.\n\nSome of the actions you perform will have an impact on these values while others are fixed and predetermined.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Balance Sheet Tab", sprite_Button[counter++], 1, "The Balance Sheet Tabe shows your store's balance sheet with its values being calculated real-time.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Income Statement Tab", sprite_Button[counter++], 1, "The Income Statement Tab shows your store's income statement with its values being calculated real-time.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Ratios Tab", sprite_Button[counter++], 1, "The Ratios Tab shows important financial ratios.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Back Button", sprite_Button[counter++], 0, "Tap the back button to go back to the storefront screen.");
        tutorialIndex++;
        pageIndex = 0;

        // 27
        // Report
        tutorial[tutorialIndex] = new Tutorial(8);
        tutorial[tutorialIndex].addPage(pageIndex++, "The Report", sprite_Button[counter++], 0, "The report screen is where you fill out a financial report.\n\nYour report's correctness will be assessed and you will earn platinum based on your score.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Balance Sheet", null, 0, "In this report you will build each part of the Balance Sheet (ie. Assets, liabilities, owners equity).");
        tutorial[tutorialIndex].addPage(pageIndex++, "The Answer Slots", sprite_Button[counter++], 2, "The blank spaces on each part of the report are answer slots. You must fill these blanks with phrases from the word bank.");
        tutorial[tutorialIndex].addPage(pageIndex++, "The Word Bank", sprite_Button[counter++], 2, "All of the possible answers are stored in the word bank below.\n\nYou can scroll left and right to view all the options.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Selecting an Answer", sprite_Button[counter++], 2, "To fill an answer slot, first select a phrase from the word bank by tapping it, then tap the answer slot where you want to place the phrase.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Arrow Navigation", sprite_Button[counter++], 2, "Use the Left and Right arrows to navigate between each part of the report.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Submit", sprite_Button[counter++], 1, "When you have finished filling out the report, tap the submit button on the last screen.");
        tutorial[tutorialIndex].addPage(pageIndex++, "Note on Saving", null, 0, "Your progress on reports are not saved until you submit it.\n\nIf you exit the game during a report, you will be sent back to the moment right before starting the report when you come back to the game.");
        tutorialIndex = 0;
        pageIndex = 0;

        // 28
        // Actual Previous Report
    }
}
