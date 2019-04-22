/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/28/2019
 * Description: Attach to button in expansions. It will allow players to purchase an additional store
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockStore : MonoBehaviour {

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Unlock());
    }

    void Unlock()
    {
        int cost = Globals.platStore;
        if (Globals.playerPlatinum >= cost)
        {
            if (Globals.storeB) //has the player already purchased an additional store (store B)?
            Globals.storeC = true;
        }
        else
        {
            Globals.storeB = true;
        }
    }
}
