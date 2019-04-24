/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.1
 * Date: 4/11/2019
 * Description: Monitors the temporal state of the game. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{

    public static int inGameTime;
    public Text calendar;

    public GameObject reportPanel;

    //public Button toReports;
    
    // Use this for initialization
    void Start()
    {
        setMonth(calendar);
        // calendar.text = inGameTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Globals.globalTime = (int)Time.time;
        if (!Globals.newMonth)
        {
            //calendar.text = inGameTime.ToString();
            if (Globals.getInGameTime() == Globals.timePerMonth - 1 && Globals.sem == false)
            {
                Globals.sem = true;
                Globals.newMonth = true;
                Globals.month = (Globals.month + 1) % 24;
                reportPanel.gameObject.SetActive(true);
                Globals.newMonth = false;
                setMonth(calendar);
                SceneChanger.forceToStore(reportPanel);
            }
        }
        //Debug.Log(Globals.getInGameTime());
        

    }

    public static void setMonth(Text calendar)
    {
        switch (Globals.month % 12)
        {
            case 0:
                calendar.text = "January";
                break;

            case 1:
                calendar.text = "February";
                break;
            case 2:
                calendar.text = "March";
                break;
            case 3:
                calendar.text = "April";
                break;
            case 4:
                calendar.text = "May";
                break;
            case 5:
                calendar.text = "June";
                break;
            case 6:
                calendar.text = "July";
                break;
            case 7:
                calendar.text = "August";
                break;
            case 8:
                calendar.text = "September";
                break;
            case 9:
                calendar.text = "October";
                break;
            case 10:
                calendar.text = "November";
                break;
            case 11:
                calendar.text = "December";
                break;
            default:

                break;
        }
    }

    void PauseTimer()
    {

    }
}