/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/28/2019
 * Description: Attach to button in expansions. It will allow players to purchase additional items in the gold store.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockItemSetC : MonoBehaviour {

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Unlock());
    }

    void Unlock()
    {
        int cost = Globals.platC;
        if (Globals.playerPlatinum >= cost)
        {
            Globals.unlockedC = true;
        }
    }
}
