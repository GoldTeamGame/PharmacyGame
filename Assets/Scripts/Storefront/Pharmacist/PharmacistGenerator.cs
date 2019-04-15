using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistGenerator : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // Generate pharmacist counter if fresh save was used
        if (Globals_Pharmacist.pc == null)
        {
            Globals_Pharmacist.pc = new PharmacistCounter();
            Globals_Pharmacist.employeeList = new Pharmacist[4];
            Globals_Pharmacist.employeeList[0] = new Pharmacist();
        }
        else
        {

        }
	}
}
