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
	public const int timePerMonth = 600;
	// Use this for initialization
	void Start () {
		inGameTime = Globals.getInGameTime();
		calendar.text = "suck it";
	}
	
	// Update is called once per frame
	void Update () {
		inGameTime = Globals.getInGameTime();
		if(inGameTime >= timePerMonth){
			
		}
	}
}
