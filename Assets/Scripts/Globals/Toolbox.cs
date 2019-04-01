// File: Toolbox
// Version: 1.0.2
// Last Updated: 3/31/19
// Authors: Alexander Jacks
// Description: Provides helpful functions and variables

using UnityEngine;

public class Toolbox
{
    public static Vector3 zero = new Vector3(-100, -100, -100); // represents a null vector value

    // Returns num with the given number of digits following the decimal point
    public static float precisionConversion(float num, int numberOfDecimalPlaces)
    {
        float modifier = Mathf.Pow(10, numberOfDecimalPlaces);
        int transition = (int)(num * modifier);
        return transition / modifier;
    }

    // https://stackoverflow.com/questions/16543751/unity3d-font-with-strikethrough
    // Credit to Tim Maytom
    public static string StrikeThrough(string s)
    {
        if (s != null)
        {
            string strikethrough = "";
            foreach (char c in s)
            {
                strikethrough = strikethrough + c + '\u0336';
            }

            return strikethrough;
        }

        return s;
    }

    // Randomly returns true or false based on chance
    // chance should be 0-100
    // Anything 100 and above will always be true
    // Anything 0 and below will always be false
    public static bool randomBool(int chance)
    {
        int randomNumber = Random.Range(1, 101);

        return randomNumber <= chance;
    }
}
