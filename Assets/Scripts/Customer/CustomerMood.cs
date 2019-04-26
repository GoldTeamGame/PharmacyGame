using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerMood : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = "Overall Mood: " + Globals_Customer.globalMood + "%";
	}
}
