﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerCounter : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = "Number of Customers: " + Globals_Customer.customerData.Count;
	}
}
