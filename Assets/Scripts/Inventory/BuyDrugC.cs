/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.3
 * Date: 2/4/2019
 * Description: Attach to button in store. It adds a unit of DRUG C "Lyrica" to the player's stock.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDrugC : MonoBehaviour
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
        int price = Globals.Lyrica.price;
        if (Globals.playerGold >= price)
        {
            Globals.Lyrica.amount += 1; //buy 1 unit
            Globals.playerGold -= price; //at the cost of 10 gold
        }
    }
}
