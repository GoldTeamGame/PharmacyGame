/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.3
 * Date: 2/4/2019
 * Description: Attach to button in store. It adds a unit of DRUG B "Vyvnase" to the player's stock.
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
        button.onClick.AddListener(() => Buy());
    }

    void Buy()
    {
        int price = Globals.Vyvanse.price;
        if(Globals.playerGold >= price)
        {
            Globals.Vyvanse.amount += 1; //buy 1 unit
            Globals.playerGold -= price; //at the cost of 7 gold        
        }
    }
}