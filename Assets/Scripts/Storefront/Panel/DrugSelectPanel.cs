using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugSelectPanel : MonoBehaviour {

    public GameObject panel;
    public Button b;
    public GameObject selectedButton;
    public static bool needToUpdate;
    public bool[] exist;

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
