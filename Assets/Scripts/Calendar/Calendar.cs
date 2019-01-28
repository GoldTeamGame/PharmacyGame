/*
	Author: Jon Hearn
	Ver.: 1.0
	Date: 1/16/19

	Desc.:
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour {

	public static int inGameTime;
	public Text calendar;
	public const int timePerMonth = 30;
	// Use this for initialization
	void Start () {
		inGameTime = (Globals.getInGameTime()) % timePerMonth;
		switch(Globals.month){
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
		// calendar.text = inGameTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(!Globals.newMonth){
			inGameTime = Globals.getInGameTime() % timePerMonth;
			//calendar.text = inGameTime.ToString();
			if(inGameTime == timePerMonth - 1){
				Globals.newMonth = true;
				Globals.month = (Globals.month + 1) % 12;
			}
		}
		switch(Globals.month){
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
}
