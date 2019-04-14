
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Desires
{
    public CartItem[] overCounter;
    public CartItem[] prescription;

    public int desiresRemaining; // number of overCounter desires remaining
    public int currentDrug; // current drug being looked for
    public bool willBuy;

    public Desires(int overCounterSize, int prescriptionSize)
    {
        // Create empty over the counter desire array of random size
        overCounter = new CartItem[overCounterSize];
        desiresRemaining = overCounter.Length;

        prescription = new CartItem[prescriptionSize];

        // Fill arrays with drugs
        generateArray(ref overCounter, Globals.overCounterList);
        generateArray(ref prescription, Globals.drugList);
    }

    // Returns the next over the counter drug from overCounter array
    // First checks if drug is available, continues to cycle through array until a valid drug is found
    public Drug getCurrentDrug()
    {
        // Check to see if there IS a current drug
        if (desiresRemaining > 0)
        {
            // count helps cycle through the entire list only once
            int count = 0;

            // Find index of a drug that has not been picked up
            while (count < overCounter.Length)
            {
                if (currentDrug >= overCounter.Length)
                    currentDrug = 0;

                // Stop when a drug that has not been picked up has been found
                if (!overCounter[currentDrug].hasPickedUp)
                    break;
                else
                    currentDrug++;

                count++;
            }

            return overCounter[currentDrug].drug;
        }
        else
            return null;
    }

    // Fill array with drugs
    private void generateArray(ref CartItem[] array, List<Drug> drugList)
    {
        int desireCount = 0; // current number of desires in array

        // Continue filling array while there are remaining available drugs
        // and while there is still remaining space in the array
        for (int i = 0; i < drugList.Count && desireCount < array.Length; i++)
            // Add drug to array if it passes the check
            if (Toolbox.randomBool(drugList[i].chance))
                array[desireCount++] = new CartItem(drugList[i]);

        // If no desires were added, but the array length is 1, then forcefully add item to list
        if (desireCount == 0 && array.Length == 1)
        {
            array[0] = new CartItem(drugList[0]);
            desireCount++;
        }

        // If desire count is less than size of array, refactor array to match size of desire count
        if (desireCount < array.Length)
        {
            CartItem[] temp = new CartItem[desireCount];
            for (int i = 0; i < desireCount; i++)
                temp[i] = array[i];
            array = temp;
        }
    }
}
