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
	

	public void pageLeft(){
		if(screen2.active){
			screen2.SetActive(false);
			screen1.SetActive(true);
		}
	}
	public void pageRight(){
		if(screen1.active){
			screen1.SetActive(false);
			screen2.SetActive(true);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
