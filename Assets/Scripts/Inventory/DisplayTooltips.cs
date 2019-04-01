﻿/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 4/1/2019
 * Description: Handles a tooltip description when the purchase button is held down.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayTooltips : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float time;

    public bool buyState;
    public bool tooltipState;

    public Drug d;

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
        }
        else
        {
            //buy item
            BuyItem.buyDrug(d.name);
        }

        tooltipState = false;
        buyState = false;

        //isHoldingDown = false;
    }

    void Start()
    {
        string drugNamePlusExtra = gameObject.GetComponentInChildren<Text>().text;
        string[] slice = drugNamePlusExtra.Split(':');
        d = Globals.findDrug(slice[0], Globals.drugList);
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
                Debug.Log(d.name + ": " + d.description);
            }
        }
    }
}
