﻿/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 1/16/2019
 * Description: Attach to button in store. It hires EMPLOYEE C at the listed rate.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployC : MonoBehaviour
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
        button.onClick.AddListener(() => Hire());
    }

    void Hire()
    {
        Globals.hiredC = true; //worker becomes employed
        Globals.playerGold -= 19; //at the cost of 19 gold
        //TODO: Subtract the wage each "hour"
    }
}
