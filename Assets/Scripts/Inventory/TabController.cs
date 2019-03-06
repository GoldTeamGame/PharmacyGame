/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 3/4/2019
 * Description: Handles the tab display for looking at the inventory.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TabController : MonoBehaviour {

    /*
     * Currently attached to canvas
     * Needs to add scrollbar dynamically?
     * Then add items to said scrollbar?
     */

    private int iTabSelected = 0;

    private void OnGUI()
    {
        GUILayout.BeginVertical();
        {
            GUILayout.Space(40); //go below the gold/plat bar
            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Toggle(iTabSelected == 0, "Stock", EditorStyles.toolbarButton))
                {
                    iTabSelected = 0;
                }

                if (GUILayout.Toggle(iTabSelected == 1, "Employees", EditorStyles.toolbarButton))
                {
                    iTabSelected = 1;
                }

                if (GUILayout.Toggle(iTabSelected == 2, "Structures", EditorStyles.toolbarButton))
                {
                    iTabSelected = 2;
                }
            }
            GUILayout.EndHorizontal();

            DoGUI(iTabSelected);
        }
    }

    private void DoGUI(int iTabSelected)
    {
        if(iTabSelected == 0) //0 = Stock
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            {
                GUILayout.Button("Stock.Label1");
                GUILayout.Button("Stock.Label2");
                /*
                 * Add scrollbar
                 * Call Display Inventory? OR
                 * Loop 0 .. All Drugs
                 * Add label to the scrollbar
                 */
            }
            GUILayout.EndVertical();
        }

        if (iTabSelected == 1) //1 = Employees
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            {
                //loop to add employees
            }
            GUILayout.EndVertical();
        }

        if (iTabSelected == 2) //2 = Structures
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            {
                //loop to add structures
            }
            GUILayout.EndVertical();
        }
    }
}
