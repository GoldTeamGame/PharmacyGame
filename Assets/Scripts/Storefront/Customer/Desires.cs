// File: Desires
// Author: Alexander Jacks
// Last Modified: 4/15/19
// Version: 1.0.2
// Description: Holds a customer's desires for what they want in the store

[System.Serializable]
public class Desires
{
    public CartItem[] overCounter;
    public CartItem[] prescription;

    public int desiresRemaining; // number of overCounter desires remaining
    public int currentDrug; // current drug being looked for
    public bool willBuyOverCounter;

    public Desires(int overCounterSize, int prescriptionSize)
    {
        // Create empty over the counter desire array of random size
        overCounter = new CartItem[overCounterSize];
        desiresRemaining = overCounter.Length;

        prescription = new CartItem[prescriptionSize];

        // Fill arrays with drugs
        //generateArray(ref overCounter, Globals.overCounterList);
        //generateArray(ref prescription, Globals.drugList);
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

            if (currentDrug == overCounter.Length)
                return null;

            return overCounter[currentDrug].drug;
        }
        else
            return null;
    }
}
