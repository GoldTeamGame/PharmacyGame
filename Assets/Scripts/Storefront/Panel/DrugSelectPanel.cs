using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugSelectPanel : MonoBehaviour {

    public static string selectedDrug = "";

    public void remove(GameObject go)
    {
        if (ShowGameObject.clicks == 1)
        {
            go.SetActive(false);
            ShowGameObject.clicks = 0;
        }
        else
            ShowGameObject.clicks++;
    }

    public void selectDrug(string s)
    {
        selectedDrug = s;
        gameObject.SetActive(false);
    }
}
