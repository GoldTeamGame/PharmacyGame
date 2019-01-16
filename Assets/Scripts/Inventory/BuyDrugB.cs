/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/16/2019
 * Description: Attach to button in store. It adds a unit of DRUG B to the player's stock.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDrugB : MonoBehaviour
{

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(() => Buy());
    }

    void Buy()
    {
        Globals.drugB += 1; //buy 1 unit
        Globals.playerGold -= 7; //at the cost of 7 gold
    }
}