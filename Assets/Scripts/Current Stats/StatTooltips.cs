/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 4/10/2019
 * Description: Handles a tooltip description when the statistic button is held down
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatTooltips : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static string[] descriptions = {
        "Inventory: Sum of (Drugs Currently Owned) x Their Price",
        "Equipment: Sum of the cost of each owned service",
        "Salaries Payable: Sum of all the employee salaries"
    };

    public float time;
    public string toolTip;

    public bool buyState;
    public bool tooltipState;

    public Text btnText;

    public GameObject thePanel;
    public Text theText;

    public void OnPointerDown(PointerEventData eventData)
    {
        selectText();
        thePanel.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        thePanel.SetActive(false);

        //isHoldingDown = false;
    }

    /*
    void Start()
    {
        string drugNamePlusExtra = gameObject.GetComponentInChildren<Text>().text;
        string[] slice = drugNamePlusExtra.Split(':');
        d = Globals.findDrug(slice[0], Globals.drugList);
    }
    */
    /*
    void Update()
    {
        if (buyState)
        {
            time++;
            if (time > 120)
            {
                tooltipState = true;
                buyState = false;
                //show tooltip
                string theTooltip = d.name + ": " + d.description;
                Debug.Log(d.name + ": " + d.description);
                theText.text = theTooltip;
                thePanel.SetActive(true);
            }
        }
    }
    */

    void selectText()
    {
        string text = gameObject.GetComponentInChildren<Text>().text;
        theText.text = toolTip;
        //if (text.Equals("Inventory"))
        //{
        //    //theText.text = descriptions[0];
        //    theText.text = "Inventory: Sum of (Drugs Currently Owned) x Their Price";
        //} 
        //else if(text.Equals("Equipment"))
        //{
        //    theText.text = "Equipment: Sum of the cost of each owned service";
        //}
        //else if(text.Equals("Salaries Payable\n"))
        //{
        //    theText.text = "Salaries Payable: Sum of all the employee salaries";
        //}
    }
}