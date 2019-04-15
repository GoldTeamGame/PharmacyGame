using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfPanel : MonoBehaviour
{
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
        Text t = ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>();
        int i = ShowGameObject.si.amount[index];

        if (i < 10)
            i++;

        ShowGameObject.si.amount[index] = i;
        t.text = "" + i;
    }

    public void decrement(int index)
    {
        Text t = ShowGameObject.button[index].transform.GetChild(1).GetComponent<Text>();
        int i = ShowGameObject.si.amount[index];

        if (i > 0)
            i--;

        ShowGameObject.si.amount[index] = i;
        t.text = "" + i;
    }

}
