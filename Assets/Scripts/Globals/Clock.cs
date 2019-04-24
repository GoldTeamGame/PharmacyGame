using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    static Timer t;
    static string displayTime; // time in 0:00 format
    public static int time; // ellapsed time
    static int minutes;
    static int seconds;
    static int currentSecond; // used so that setTime isn't called every frame

	// Use this for initialization
	void Start ()
    {
        t = new Timer(time);

        // Do not start clock if tutorial is ongoing
        if (Globals_Tutorials.tutorialIndex > 17)
            t.start();

        setTime();
        GetComponent<Text>().text = displayTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        time = t.getTimeInSeconds();

        // Only update Text once per second
        if (currentSecond != time)
        {
            setTime();
            GetComponent<Text>().text = displayTime;
        }
	}

    static void setTime()
    {
        int minutes = t.getTimeInSeconds() / 60;
        int seconds = t.getTimeInSeconds() % 60;
        string displaySeconds = "";
        if (seconds < 10)
            displaySeconds = "0" + seconds;
        else displaySeconds = "" + seconds;
        displayTime = "" + minutes + ":" + displaySeconds;
        currentSecond = time;
    }

    // Reset timer to 0 and set the time
    public static void reset()
    {
        t.stopAndReset();
        setTime();
    }

    // Start timer
    public static void start()
    {
        t.start();
    }
}
