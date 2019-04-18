using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportMainanence : MonoBehaviour {

	public static string selectedText;
	public static Text selectedObj;
	public static string selectedType;
	public GameObject test;
	public GameObject screen1;
	public GameObject screen2;
	public GameObject screen3;
	public GameObject screen4;
	public GameObject screen5;
	public GameObject screen6;
	//public GameObject screen4;
	//public GameObject screen5;
	//public GameObject screen6;
	//public GameObject screen7;
	//public GameObject screen8;
	

	public void pageLeft(){
		if(screen2.active){
			screen2.SetActive(false);
			screen1.SetActive(true);
		}
		else if(screen3.active){
			screen3.SetActive(false);
			screen2.SetActive(true);
		}
		else if(screen4.active){
			screen4.SetActive(false);
			screen3.SetActive(true);
		}
		else if(screen5.active){
			screen5.SetActive(false);
			screen4.SetActive(true);
		}
		else if(screen6.active){
			screen6.SetActive(false);
			screen5.SetActive(true);
		}
	}
	public void pageRight(){
		if(screen1.active){
			screen1.SetActive(false);
			screen2.SetActive(true);
		}
		else if(screen2.active){
			screen2.SetActive(false);
			screen3.SetActive(true);
		}
		else if(screen3.active){
			screen3.SetActive(false);
			screen4.SetActive(true);
		}
		else if(screen4.active){
			screen4.SetActive(false);
			screen5.SetActive(true);
		}
		else if(screen5.active){
			screen5.SetActive(false);
			screen6.SetActive(true);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
