// File: Item
// Author: Alexander Jacks
// Last Modified: 4/22/19
// Version: 1.0.1
// Description: Abstract class which defines functionality needed by almost all save-able
//              classes in the game.

[System.Serializable]
public abstract class Item
{
    public string name; // name of item
    public int price; // price of item
    public string description; // description of item
    public bool isUnlocked; // is the item unlocked

    public abstract void action(); // action of button on click
    public abstract string generateTooltip(); // returns tooltip

    // Find item in the specified list
    public static Item find(int listIndex, string name)
    {
        // Search through list for name
        for (int i = 0; i < Globals_Items.item[listIndex].Length; i++)
            if (name.Contains(Globals_Items.item[listIndex][i].name))
                return Globals_Items.item[listIndex][i];

        // If name wasn't found, report to Console
        DebugTool.Log("Trying to find: " + name + "\nCan only find...");
        for (int i = 0; i < Globals_Items.item[listIndex].Length; i++)
            DebugTool.Log(Globals_Items.item[listIndex][i].name);

        return null;
    }
}
