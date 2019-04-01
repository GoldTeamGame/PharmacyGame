using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugSelectPanel : MonoBehaviour {

    public static string selectedDrug = "";

    public void remove(GameObject go)
    {
        go.SetActive(false);
    }

    public void selectDrug(string s)
    {
        selectedDrug = s;
        gameObject.SetActive(false);
    }
}
