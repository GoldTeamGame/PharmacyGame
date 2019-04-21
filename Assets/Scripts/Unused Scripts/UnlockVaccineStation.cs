/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/28/2019
 * Description: Attach to button in expansions. It will allow players to purchase a vaccine station to drop onto the storefront
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockVaccineStation : MonoBehaviour {

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Unlock());
    }

    void Unlock()
    {
        int cost = Globals.platVac;
        if (Globals.playerPlatinum >= cost)
        {
            Globals.unlockedVaccineStation = true;
        }
    }
}
