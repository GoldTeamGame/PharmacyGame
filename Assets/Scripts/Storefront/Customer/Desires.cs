
using UnityEngine;
using System.Collections.Generic;

public class Desires
{
    public CartItem[] overCounter;
    public CartItem[] prescription;

    public int desiresRemaining; // number of overCounter desires remaining
    public int currentDrug; // current drug being looked for

    public Desires()
    {
        // Create empty over the counter desire array of random size
        overCounter = new CartItem[Random.Range(0, 4)];
        desiresRemaining = overCounter.Length;

        // Create empty prescription desire array of random size
        // (if overCounter was length of 0, then minimum prescription size must be 1)
        if (overCounter.Length > 0)
            prescription = new CartItem[Random.Range(0, 4)];
        else
            prescription = new CartItem[Random.Range(1, 4)];

        // Fill arrays with drugs
        generateArray(ref overCounter, Globals.overCounterList);
        generateArray(ref prescription, Globals.drugList);
    }

    // Returns the next over the counter drug from overCounter array
    // First checks if drug is available, continues to cycle through array until a valid drug is found
    public Drug getCurrentDrug()
    {
        if (desiresRemaining > 0)
        {
            desiresRemaining--;
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
