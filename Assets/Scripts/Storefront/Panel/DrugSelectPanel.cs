using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugSelectPanel : MonoBehaviour {

    public GameObject panel;
    public Button b;
    public GameObject selectedButton;

    private void Start()
    {
        for (int i = 0; i < Globals.overCounterList.Count; i++)
        {
            if (Globals.overCounterList[i].isUnlocked)
            {
                Button newButton = Instantiate(b, transform);
                string s = Globals.overCounterList[i].name;
                newButton.transform.GetChild(0).GetComponent<Text>().text = s;
                newButton.onClick.AddListener(delegate { selectDrug(s); });
            }
        }
    }

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
        panel.SetActive(false);
    }
}
