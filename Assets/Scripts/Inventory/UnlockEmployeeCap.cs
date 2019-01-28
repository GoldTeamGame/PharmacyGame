/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/28/2019
 * Description: Attach to button in expansions. It will allow players to hire additional employees.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockEmployeeCap : MonoBehaviour {

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Unlock());
    }

    void Unlock()
    {
        int cost = Globals.platCap;
        if (Globals.playerPlatinum >= cost)
        {
            Globals.employeeCap = 3;
        }
    }
}
