/* 
 * Authors: Dylan Cyphers, Alexander Jacks
 * Version 1.2
 * Date: 4/17/2019
 * Description: Handles a tooltip description when the purchase button is held down for drugs
 * 
 */
 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayTooltips : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float time;

    public bool buyState;
    public bool tooltipState;

    string upgrade;
    Drug d;
    Service s;
    public GameObject thePanel;
    public Text theText;
    public string[] listOfDrugs;
    public string description;
    /*
     * Actions...
     * 0: Interact with prescription drug
     * 1: Interact with over the counter drug
     * 2: Interact with prescription drug set
     * 3: Interact with over the counter drug set
     * 4: Interact with upgrades
     * 5: Interact with services
     */
    public int action;

    public void OnPointerDown(PointerEventData eventData)
    {
        time = 0;
        buyState = true;
        tooltipState = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (tooltipState)
        {
            //hide tooltip
            Debug.Log("hiding tooltip");
            thePanel.SetActive(false);
        }
        else
        {
            if (Globals_Tutorials.tutorialIndex == 1 || Globals_Tutorials.tutorialIndex == 3)
            {
                Globals_Tutorials.tutorialIndex++;
                TutorialMonitor.isPopup = true;
            }
            //buy item
            if (action == 0)
                BuyItem.buyPrescription(d.name);
            else if (action == 1)
                BuyItem.buyOverCounter(d.name);
            else if (action == 2)
                BuyItem.unlockPrescription(listOfDrugs);
            else if (action == 3)
                BuyItem.unlockOverCounter(listOfDrugs);
            else if (action == 4)
                Upgrades.upgrade(upgrade);
            else if (action == 5)
                if (s != null)
                    s.increaseAmount(1);
        }

        tooltipState = false;
        buyState = false;
    }

    void Start()
    {
        if (action == 0 || action == 1)
        {
            string drugNamePlusExtra = gameObject.GetComponentInChildren<Text>().text;
            string[] slice = drugNamePlusExtra.Split(':');
            if (action == 0)
                d = Globals.findDrug(slice[0], Globals.prescriptionList);
            else if (action == 1)
                d = Globals.findDrug(slice[0], Globals.overCounterList);
        }
        else if (action == 4)
        {
            string name = gameObject.GetComponentInChildren<Text>().text;
            string[] slice = name.Split(':');
            upgrade = slice[0];
        }
        else if (action == 5)
        {
            string name = gameObject.GetComponentInChildren<Text>().text;
            string[] slice = name.Split(':');
            s = Globals_Items.findService(slice[0]);
        }
    }

    void Update()
    {
        if (buyState)
        {
            time++;
            if (time > 15)
            {
                tooltipState = true;
                buyState = false;
                //show tooltip
                string theTooltip = "";
                if (action == 0 || action == 1)
                    theTooltip = d.description;
                if (action == 2 || action == 3 || action == 4)
                    theTooltip = description;
                else if (action == 5)
                    if (s != null)
                        theTooltip = s.description;
                theText.text = theTooltip;
                thePanel.SetActive(true);
            }
        }
    }
}