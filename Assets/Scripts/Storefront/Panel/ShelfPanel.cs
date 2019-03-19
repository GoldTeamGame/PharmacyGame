using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfPanel : MonoBehaviour
{
    public GameObject drugPanel;
    GameObject selectedButton;
    public Sprite sprite;

    private void Update()
    {
        if (!DrugSelectPanel.selectedDrug.Equals(""))
        {
            selectedButton.GetComponentInChildren<Text>().text = DrugSelectPanel.selectedDrug;
            DrugSelectPanel.selectedDrug = "";
            selectedButton = null;
            ShowGameObject.selectedObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
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

    public void showDrugs(GameObject go)
    {
        selectedButton = go;
        drugPanel.SetActive(true);
    }

    public void increment(Text t)
    {
        int i = int.Parse(t.text);

        if (i < 10)
            i++;

        t.text = "" + i;
    }

    public void decrement(Text t)
    {
        int i = int.Parse(t.text);

        if (i > 0)
            i--;

        t.text = "" + i;
    }

}
