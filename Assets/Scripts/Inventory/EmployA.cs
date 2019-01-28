/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.2
 * Date: 1/28/2019
 * Description: Attach to button in store. It hires EMPLOYEE A at the listed rate.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployA : MonoBehaviour
{

    Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Hire());
    }

    void Hire()
    {
        if (!Globals.hiredA)
        {
            int wage = Globals.wageA;
            if (Globals.playerGold >= wage)
            {
                Globals.hiredA = true; //worker becomes employed
                Globals.playerGold -= wage; //at the cost of 15 gold
            }
        }
        
        //TODO: Subtract the wage each "hour"
    }
}
