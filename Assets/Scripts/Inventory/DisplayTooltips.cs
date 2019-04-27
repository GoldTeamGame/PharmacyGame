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
    public GameObject thePanel;
    public Text theText;

    Item item;

    float time;

    bool buyState;
    bool tooltipState;

    /*
     * Actions...
     * 0: Interact with prescription drug
     * 1: Interact with over the counter drug
     * 2: Interact with pharmacist list
     * 3: Interact with prescription drug set
     * 4: Interact with over the counter drug set
     * 5: Interact with upgrades
     * 6: Interact with services
     */
    public int action;

    public static Vector3 mousePosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        time = 0;
        buyState = true;
        tooltipState = false;
        mousePosition = Input.mousePosition;
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
            if (mousePosition.Equals(Input.mousePosition))
            {
                if (Globals_Tutorials.tutorialIndex == 1 || Globals_Tutorials.tutorialIndex == 3)
                {
                    Globals_Tutorials.tutorialIndex++;
                    TutorialMonitor.isPopup = true;
                }

                if (item.name.Equals("Shelf"))
                    TutorialMonitor.staticTutorialButton(7);

                GameObject child = EventSystem.current.currentSelectedGameObject; // button clicked

                // Buy Item
                if (action <= 1)
                    item.action();
                else if (child != null && Item.canBeUnlocked(action, item.name))
                {
                    if (item.isUnlocked)
                        for (int i = 0; i < Globals_Items.item[action].Length; i++)
                            if (item.name.Equals(Globals_Items.item[action][i].name))
                                item = Globals_Items.item[action][i];

                    item.action();

                    if (item.isUnlocked)
                        child.GetComponent<Button>().interactable = false;
                }
            }
        }

        tooltipState = false;
        buyState = false;
    }

    void Start()
    {
        // Figure out what item has been selected...
        // Grab text from button
        string drugNamePlusExtra = gameObject.GetComponentInChildren<Text>().text;

        // Split text so that slice[0] will hold just the name of the item
        string[] slice = drugNamePlusExtra.Split(':');

        // Find and set item equal to the item found using Item.find()
        // Item.find will use the action integer to decide which list to search to find the name (slice[0])
        item = Item.find(action, slice[0]);
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
                string theTooltip = item.generateTooltip();
                theText.text = theTooltip;
                thePanel.SetActive(true);
            }
        }
    }
}