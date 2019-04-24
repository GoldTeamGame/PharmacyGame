using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prevReportViewer : MonoBehaviour {

	// Use this for initialization

	public int reportToView = 0;
	public Text [] toDisplay = new Text [24];

	void Start () {
		for(int i = 0; i < 12; i++){
			toDisplay[i*2].text = Globals.reports[reportToView, i];
		}
		toDisplay[1].text = "Cash";
		toDisplay[3].text = "Inventory";
		toDisplay[5].text = "Accounts Rec";
		toDisplay[7].text = "Equipment";
		toDisplay[9].text = "Property";
		toDisplay[11].text = "Plant";
		toDisplay[13].text = "Salaries";
		toDisplay[15].text = "Obligations";
		toDisplay[17].text = "Stock";
		toDisplay[19].text = "Capital";
		toDisplay[21].text = "Retained";
		toDisplay[23].text = "Equity";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
