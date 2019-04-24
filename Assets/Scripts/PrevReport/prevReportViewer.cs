// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class prevReportViewer : MonoBehaviour {

// 	// Use this for initialization

// 	public int reportToView = 0;
// 	public Text [] toDisplay = new Text [24];
// 	public GameObject screen1;
// 	public GameObject screen2;
// 	public GameObject screen3;
// 	public GameObject screen4;
// 	public GameObject screen5;

// 	public void pageLeftPrev(){
// 		if(screen2.active){
// 			screen2.SetActive(false);
// 			screen1.SetActive(true);
// 		}
// 		else if(screen3.active){
// 			screen3.SetActive(false);
// 			screen2.SetActive(true);
// 		}
// 		else if(screen4.active){
// 			screen4.SetActive(false);
// 			screen3.SetActive(true);
// 		}
// 		else if(screen5.active){
// 			screen5.SetActive(false);
// 			screen4.SetActive(true);
// 		}
		
// 	}
// 	public void pageRightPrev(){
// 		if(screen1.active){
// 			screen1.SetActive(false);
// 			screen2.SetActive(true);
// 		}
// 		else if(screen2.active){
// 			screen2.SetActive(false);
// 			screen3.SetActive(true);
// 		}
// 		else if(screen3.active){
// 			screen3.SetActive(false);
// 			screen4.SetActive(true);
// 		}
// 		else if(screen4.active){
// 			screen4.SetActive(false);
// 			screen5.SetActive(true);
// 		}
// 	}

// 	public void displayReport(){
// 		for(int i = 0; i < 12; i++){
// 			toDisplay[i*2].text = Globals.reports[reportToView, i];
// 		}
// 		toDisplay[1].text = "Cash";
// 		toDisplay[3].text = "Inventory";
// 		toDisplay[5].text = "Accounts Rec";
// 		toDisplay[7].text = "Equipment";
// 		toDisplay[9].text = "Property";
// 		toDisplay[11].text = "Plant";
// 		toDisplay[13].text = "Salaries";
// 		toDisplay[15].text = "Obligations";
// 		toDisplay[17].text = "Stock";
// 		toDisplay[19].text = "Capital";
// 		toDisplay[21].text = "Retained";
// 		toDisplay[23].text = "Equity";
// 	}

// 	void Start () {
		
		
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
		
// 	}
// }
