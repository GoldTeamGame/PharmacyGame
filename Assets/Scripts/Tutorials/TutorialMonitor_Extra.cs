using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMonitor_Extra : MonoBehaviour {

    public static GameObject[] currentButtons;
    public GameObject[] _currentButtons;

	// Use this for initialization
	void Start ()
    {
        currentButtons = _currentButtons;
	}

    public void tutorialButton(int state)
    {
        if (state - 1 == Globals_Tutorials.tutorialIndex)
        {
            Globals_Tutorials.tutorialIndex++;
            TutorialMonitor.isPopup = true;
        }
    }
}
