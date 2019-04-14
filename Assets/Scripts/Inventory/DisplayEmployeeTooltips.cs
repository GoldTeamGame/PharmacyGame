/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 4/8/2019
 * Description: Handles a tooltip description when the purchase button is held down for employees
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayEmployeeTooltips : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float time;

    public bool buyState;
    public bool tooltipState;

    public Employee e;

    public GameObject thePanel;
    public Text theText;

    public void OnPointerDown(PointerEventData eventData)
    {
        time = 0;
        buyState = true;
        tooltipState = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (tooltipState)
        {
            //hide tooltip
            Debug.Log("hiding tooltip");
            thePanel.SetActive(false);
        }
        else
        {
            //buy item
            BuyItem.hire(e.name);
        }

        tooltipState = false;
        buyState = false;

        //isHoldingDown = false;
    }

    void Start()
    {
        string employeeNamePlusExtra = gameObject.GetComponentInChildren<Text>().text;
        employeeNamePlusExtra = employeeNamePlusExtra.Substring(5);
        string[] slice = employeeNamePlusExtra.Split(':');;
        e = Globals.findEmployee(slice[0]);
    }

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
                string theTooltip = e.name + ": " + e.description;
                Debug.Log(e.name + ": " + e.description);
                theText.text = theTooltip;
                thePanel.SetActive(true);
            }
        }
    }
}