using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prevReportHandler : MonoBehaviour {

    public GameObject[] reportButtons = new GameObject[12];
	public Text[] reportText = new Text[24];


    // Use this for initialization
    void Start () {
		for(int i = 0; i < Globals.month; i++){
			reportButtons[i].SetActive(true);
			reportText[(2*i) + 1].text = Globals.reports[i,12] + "%";
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
