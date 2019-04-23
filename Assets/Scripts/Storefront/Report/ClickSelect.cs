using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSelect : MonoBehaviour {

	public static GameObject clicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void testing(GameObject sent){

		if(sent.GetComponent<Text>().text != ""){
			ReportMainanence.selectedObj = sent.GetComponent<Text>();
			// ReportMainanence.selectedType = type;
			ReportMainanence.selectedText = sent.GetComponent<Text>().text;
			Debug.Log("picked up a selected phrase");

		}
		if(sent.GetComponent<Text>().text == ""){
			// ReportMainanence.selectedText =  sent.GetComponent<Text>().text;
			// ReportMainanence.selectedObj = sent.GetComponent<Text>();
			// Debug.Log("test");
			
			//store selected string to answer slot from solution

			sent.GetComponent<Text>().text = ReportMainanence.selectedText;
			ReportMainanence.selectedObj.text = "";
			ReportMainanence.selectedObj = null;
			// ReportMainanence.selectedType = "";
			ReportMainanence.selectedText = "";

		}
	}
}
