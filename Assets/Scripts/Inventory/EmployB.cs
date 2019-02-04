/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.3
 * Date: 2/4/2019
 * Description: Attach to button in store. It hires EMPLOYEE B "Alex" at the listed rate.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployB : MonoBehaviour
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
        if (!Globals.Alex.isHired)
        {
            int wage = Globals.Alex.wage;
            if (Globals.playerGold >= wage)
            {
                Globals.Alex.isHired = true; //worker becomes employed
                Globals.playerGold -= wage; //at the cost of 22 gold
            }
        }
        //TODO: Subtract the wage each "hour"
    }
}
