// File: TutorialMonitor_Extra
// Author: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.0.1
// Description: Just like TutorialMonitor, but used on scenes that aren't Storefront

using UnityEngine;

public class TutorialMonitor_Extra : MonoBehaviour {

    public static GameObject[] currentButtons; // Buttons on the currently opened scene
    public GameObject[] _currentButtons; // Buttons passed in from the inspector

	// Use this for initialization
	void Start ()
    {
        currentButtons = _currentButtons; // set static array equal to what was passed in from inspector
	}

    // Used on various buttons to progress the tutorial to the next state
    public void tutorialButton(int state)
    {
        if (state - 1 == Globals_Tutorials.tutorialIndex)
        {
            Globals_Tutorials.tutorialIndex++;
            TutorialMonitor.isPopup = true;
        }
    }
}
