// File: Toolbox
// Version: 1.0.1
// Last Updated: 3/11/19
// Authors: Alexander Jacks
// Description: Provides various math related functions

using UnityEngine;

public class Toolbox
{
    // Returns num with the given number of digits following the decimal point
    public static float precisionConversion(float num, int numberOfDecimalPlaces)
    {
        float modifier = Mathf.Pow(10, numberOfDecimalPlaces);
        int transition = (int)(num * modifier);
        return transition / modifier;
    }
}
