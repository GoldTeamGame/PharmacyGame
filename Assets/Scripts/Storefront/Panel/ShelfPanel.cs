using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfPanel : MonoBehaviour
{
    public static int totalAmount;
    public GameObject drugPanel;
    public static int selectedIndex;
    public Sprite sprite;
    
    public void remove(GameObject go)
    {
        go.SetActive(false);
    }

    // Show DrugSelectPanel
    public void showDrugs(int index)
    {
        selectedIndex = index;
        drugPanel.SetActive(true);
    }

    public void increment(int index)
    {
        string drug = ShowGameObject.button[index].transform.GetChild(0).GetComponent<Text>().text;
        Text t = ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>();
        int i = ShowGameObject.si.amount[index];

        Drug d = Globals.findDrug(drug, Globals.overCounterList);

        if (d != null)
        {
            int remainingDrugs = d.amount - getTotalAmount(d.name);
            if (remainingDrugs > 0 && i < 10)
            {
                i++;
                ShowGameObject.si.amount[index] = i;
            }
        }
        
        t.text = "" + i;
    }

    public void decrement(int index)
    {
        Text t = ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>();
        int i = ShowGameObject.si.amount[index];

        if (i > 0)
        {
            i--;
            ShowGameObject.si.amount[index] = i;
        }

        t.text = "" + i;
    }

    // Gets the total number of "s" placed on all shelves
    public static int getTotalAmount(string s)
    {
        totalAmount = 0;
        for (int i = 0; i < Globals_Items.storeData.Count; i++)
        {
            if (Globals_Items.storeData[i].drug[0].Equals(s))
                totalAmount += Globals_Items.storeData[i].amount[0];
            if (Globals_Items.storeData[i].drug[1].Equals(s))
                totalAmount += Globals_Items.storeData[i].amount[1];
        }
        return totalAmount;
    }

}
