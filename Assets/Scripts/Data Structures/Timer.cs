// File: Timer
// Author: Alexander Jacks
// Version 1.0.1
// Last Modified: 4/17/19
// Description: A basic timer to keep track of time

using UnityEngine;

public class Timer
{
    private float timeAtStart = 0; // time that is set when timer starts
    private float totalTime = 0; // total accumulated time
    private bool isActive = false;

    // Empty constructor
    public Timer()
    {

    }

    // Constructor sets totalTime
    public Timer(float totalTime)
    {
        this.totalTime = totalTime;
    }

    // Start the timer
    public void start()
    {
        timeAtStart = Time.time; // set timeAtStart to global ellapsed time (Time.time)
        isActive = true; // set timer to active
    }

    // Stop the timer
    public void stop()
    {
        // Set time, then deactivate
        totalTime += Time.time - timeAtStart; // Add current ellapsed time to total time
        isActive = false; // deactivate timer
    }

    // Reset timer
    public void reset()
    {
        timeAtStart = Time.time; // set timeAtStart to global ellapsed time (Time.time)
        totalTime = 0; // reset total time
    }

    // Stops timer and resets it
    public void stopAndReset()
    {
        stop();
        reset();
    }

    public float getTime()
    {
        if (isActive)
            return Time.time - timeAtStart + totalTime; // return currentEllapsedTime + totalTime
        else
            return totalTime; // if timer is deactivated, just return the total time currently stored
    }

    // return time in seconds
    public int getTimeInSeconds()
    {
        return (int)getTime();
    }

    // return time in miliseconds
    public int getTimeInMiliseconds()
    {
        return (int)(getTime() * 1000);
    }

    public bool getIsActive()
    {
        return isActive;
    }
}
