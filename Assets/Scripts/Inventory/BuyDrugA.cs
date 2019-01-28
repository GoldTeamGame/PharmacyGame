/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.1
 * Date: 1/28/2019
 * Description: Attach to button in store. It adds a unit of DRUG A to the player's stock.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDrugA : MonoBehaviour
{

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Buy());
    }

    void Buy()
    {
        int price = Globals.priceA;
        if (Globals.playerGold >= price)
        {
            Globals.drugA += 1; //buy 1 unit
            Globals.playerGold -= price; //at the cost of 5 gold
        }
    }
}