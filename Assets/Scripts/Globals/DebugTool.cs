// File: DebugTool
// Version: 1.0.1
// Last Updated: 3/1/19
// Authors: Alexander Jacks
// Description: Provides static functions for debugging purposes

using UnityEngine;

public class DebugTool
{
    // Show string in console
    // (Used for scripts that don't have UnityEngine header
    public static void Log(string message)
    {
        Debug.Log(message);
    }
}
