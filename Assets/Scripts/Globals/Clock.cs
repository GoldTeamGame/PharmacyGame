using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    Timer t;
    string displayTime;
    public static int time;
    int minutes;
    int seconds;

	// Use this for initialization
	void Start ()
    {
        int awef = time;
        t = new Timer(time);
        t.start();
        time = Globals.getInGameTime();
	}
	
	// Update is called once per frame
	void Update ()
    {
        time = t.getTimeInSeconds();
        setTime();
        GetComponent<Text>().text = displayTime;
	}

    void setTime()
    {
        int minutes = t.getTimeInSeconds() / 60;
        int seconds = t.getTimeInSeconds() % 60;
        string displaySeconds = "";
        if (seconds < 10)
            displaySeconds = "0" + seconds;
        else displaySeconds = "" + seconds;
        displayTime = "" + minutes + ":" + displaySeconds;
    }
}
