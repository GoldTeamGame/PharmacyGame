using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugSelectPanel : MonoBehaviour {

    public GameObject selectedButton;

    public void remove(GameObject go)
    {
        go.SetActive(false);
    }

    public void selectDrug(string s)
    {
        selectedButton = ShowGameObject.button[ShelfPanel.selectedIndex];
        selectedButton.GetComponentInChildren<Text>().text = s;
        ShowGameObject.si.drug[ShelfPanel.selectedIndex] = s;
        ShowGameObject.si.amount[ShelfPanel.selectedIndex] = 0;
        gameObject.SetActive(false);
    }
}
