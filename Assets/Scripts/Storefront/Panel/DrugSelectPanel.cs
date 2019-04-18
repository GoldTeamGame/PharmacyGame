// File: DrugSelectPanel
// Authors: Alexander Jacks
// Version: 1.0.1
// Last Modified: 4/18/19
// Description: Handles displaying assignable over the counter drugs while assigning drugs to shelves

using UnityEngine;
using UnityEngine.UI;

public class DrugSelectPanel : MonoBehaviour {

    public GameObject panel; // The panel being shown
    public Button b; // A Button (Probably doesnt need to be passed in from inspector)
    public GameObject selectedButton; // The button that was used to enter the DrugSelectPanel
    public static bool needToUpdate; // A check to see if the drug list needs to be updated
    public bool[] exist; // a check to see if the button has already been added to the list

    private void Start()
    {
        exist = new bool[Globals.overCounterList.Count];
        needToUpdate = true;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (needToUpdate)
            {
                for (int i = 0; i < Globals.overCounterList.Count; i++)
                {
                    if (!exist[i] && Globals.overCounterList[i].isUnlocked)
                    {
                        exist[i] = true;
                        Button newButton = Instantiate(b, transform);
                        string s = Globals.overCounterList[i].name;
                        newButton.transform.GetChild(0).GetComponent<Text>().text = s;
                        newButton.onClick.AddListener(delegate { selectDrug(s); });
                    }
                }
                needToUpdate = false;
            }
        }
    }

    public void remove(GameObject go)
    {
        needToUpdate = true;
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
