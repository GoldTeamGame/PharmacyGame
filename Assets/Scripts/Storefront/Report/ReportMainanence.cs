using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using AllStats;

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

	public Text [] wordBankList = new Text[12];
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

	public void saveReport(){
		
	}
	
	public void randomizeWordBank(){
		System.Random rand = new System.Random();
		int nextRand;

		// gold
		nextRand = rand.Next(12);
		wordBankList[nextRand].text = "Cash: " + Globals.getGold().ToString();

		// inventory
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Inventory: " + AllStats.SumInventory().ToString();
		
		// accounts recievable Embellish
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Accounts Rec: 157";

		// equipment
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Equipment: " + AllStats.SumEquipment().ToString();

		// property Embellish
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Property: 120000";

		//plant Embellish
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Plant: 12000";

		// salaries 
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Accrued Salaries Payable: " + AllStats.SumSalaries().ToString();

		// obligations Embellish the rest
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Obligations: 13000";

		// stock
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Stock: 534";

		// capital
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text ="Capital: 1500";

		// retained
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Retained: 753";

		// equity
		nextRand = rand.Next(12);
		while(wordBankList[nextRand].text != ""){
			nextRand = rand.Next(12);
		}
		wordBankList[nextRand].text = "Equity: 16000";


	}

	// Use this for initialization
	void Start () {
		randomizeWordBank();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
