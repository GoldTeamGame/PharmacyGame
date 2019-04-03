/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.1
 * Date: 4/3/2019
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
                string theTooltip = d.name + ": " + d.description;
                Debug.Log(d.name + ": " + d.description);
                
            }
        }
    }

    void OnGUI()
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
                theTooltip = "I'M THE TOOLTIP";
                //Camera _camera = Camera.main;
                GUI.contentColor = Color.black;
                var position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                position.z = 0;
                var textSize = GUI.skin.label.CalcSize(new GUIContent(theTooltip));
                GUI.Label(new Rect(position.x, Screen.height - position.y, textSize.x, textSize.y), theTooltip);
                //(-65, -70)
            }
        }
    }
}
