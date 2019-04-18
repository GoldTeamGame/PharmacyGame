using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPharmacist : MonoBehaviour
{
    public GameObject pharmacist;
    public GameObject panel;
    public Button b;
    public GameObject selectedButton;


    private void Start()
    {
        // Find counter to assign customers to
        string name = CounterInteraction.name;
        int index = -1;
        if (name.Equals("PharmacistZone1"))
            index = 0;
        else if (name.Equals("PharmacistZone2"))
            index = 1;
        else if (name.Equals("PharmacistZone3"))
            index = 2;

        for (int i = 0; i < Globals_Pharmacist.pharmacistList.Count; i++)
        {
            if (Globals_Pharmacist.pharmacistList[i].isUnlocked)
            {
                Button newButton = Instantiate(b, transform);
                string s = Globals_Pharmacist.pharmacistList[i].name;
                newButton.transform.GetChild(0).GetComponent<Text>().text = s;
                newButton.onClick.AddListener(delegate { assign(s, index); });
            }
        }
    }

    public void remove(GameObject go)
    {
        go.SetActive(false);
    }

    public void assign(string name, int counter)
    {
        Pharmacist p = Globals_Pharmacist.findPharmacist(name);

        // Do not instantiate customer if they are not assigned to a counter
        if (p.counter == -1)
        {
            p.counter = counter;
            // Find position of pharmacist
            Position pos;
            if (p.currentState == -1 || p.currentState > 2)
                pos = Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[0];
            else
                pos = Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[p.currentState];
            
            GameObject go = Instantiate(pharmacist, ObjectReference.staticGo[2].transform); // instantiate object
            go.transform.localPosition = new Vector3(pos.x, pos.y); // set position
            go.GetComponent<PharmacistController>().p = p; // set Pharmacist
            go.GetComponent<SpriteRenderer>().sprite = PharmacistGenerator.STATIC_APPEARANCE[p.appearance];
            go.transform.localScale = new Vector3(2.25f, 2.25f, 0); // set customer sprite size (make it bigger)
        }
        //selectedButton = ShowGameObject.button[ShelfPanel.selectedIndex];
        //selectedButton.GetComponentInChildren<Text>().text = s;
        //ShowGameObject.si.drug[ShelfPanel.selectedIndex] = s;
        //ShowGameObject.si.amount[ShelfPanel.selectedIndex] = 0;
        panel.SetActive(false);
    }
}
