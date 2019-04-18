// File: SceneChanger
// Version: 1.1
// Last Updated: 4/11/19
// Authors: Alexander Jacks, Dylan Cyphers
// Description: Has button functions to change scenes

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public static string currentScene; // Keeps track of which scene is currently being viewed
    public static bool isAtStorefront = true; // True if focus is on storefront scene
    public Button back; // Button used to return to storefront scene
    //public Button hideShow; // Button used to hide menu interface
    public GameObject mainPanel;
    public GameObject inventoryPanel;
    public GameObject shelfPanel;
    public GameObject drugListPanel;
    public static GameObject staticMainPanel;
    public static GameObject staticInventoryPanel;
    private GameObject currentButton;
    private Color originalColor;


    public void Start()
    {
        if (mainPanel != null && inventoryPanel != null)
        {
            staticMainPanel = mainPanel;
            staticInventoryPanel = inventoryPanel;
        } 
    }

    // Change from currentScene to scene
    public void changeScene(string scene)
    {
        Globals.inEditMode = false;
        // Disable hide/show button
        //hideShow.gameObject.SetActive(false);

        // If a button is already selected, then reset its color before continuing
        if (currentButton != null)
            currentButton.GetComponent<Image>().color = originalColor;

        // Set current button, save its color, and then set its new color
        currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        originalColor = currentButton.GetComponent<Image>().color;
        currentButton.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);

        // Enable back button
        back.gameObject.SetActive(true);

        // Load scene on top of storefront if there isn't already aother scene open
        if (isAtStorefront)
        {
            isAtStorefront = false;
            currentScene = scene;

            CustomerScreen.isAtCustomerScene = scene.Equals("Customers");
            shelfPanel.SetActive(false);
            drugListPanel.SetActive(false);
            DrugSelectPanel.needToUpdate = true;
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
        // Or close the current scene and load the new scene
        // (if the scene selected is not already open)
        else if (!scene.Equals(currentScene))
        {
            CustomerScreen.isAtCustomerScene = scene.Equals("Customers");
            SceneManager.UnloadSceneAsync(currentScene);
            currentScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    // Return focus to storefront scene
    public void backToStorefront()
    {
        // Return from Inventory placement back to normal storefront
        if (ItemPlacer.isPlacing || ItemPlacer.isSelecting)
        {
            ItemPlacer.setInteractionState(false, false); // Set to "null" state
            if (ItemPlacer.current != null)
                ItemPlacer.delete();
            staticInventoryPanel.SetActive(false);
            staticMainPanel.SetActive(true);
            back.gameObject.SetActive(false);
            currentScene = "Storefront";
        }
        // Or unload a scene
        else
        {
            isAtStorefront = true; // reset boolean to true
            CustomerScreen.isAtCustomerScene = false;
            CustomerScreen.currentCustomer = -1;

            SceneManager.UnloadSceneAsync(currentScene); // unload currentScene

            //hideShow.gameObject.SetActive(true); // re-activate hide/show button
            back.gameObject.SetActive(false); // de-activate backToStorefront button
            currentScene = "Storefront";
        }

        currentButton.GetComponent<Image>().color = originalColor;
        currentButton = null;
    }

    //called when placing an item from the inventory into the storefront
    public void invToStorefront()
    {
        //Globals.inEditMode = true;
        isAtStorefront = true;
        SceneManager.UnloadSceneAsync("Inventory"); // unload inventory scene
        ItemPlacer.rotationState = 0;

        // If staticItem is null, that means player will enter inventory placement mode in its "Selection" state
        if (PlaceItem.staticItem == null)
            ItemPlacer.setInteractionState(false, true);

        // Replace main bottom panel with the inventory placement panel
        staticMainPanel.SetActive(false);
        staticInventoryPanel.SetActive(true);
        currentScene = "Storefront";
    }

    public void storefrontToInv()
    {
        shelfPanel.SetActive(false);
        drugListPanel.SetActive(false);
        DrugSelectPanel.needToUpdate = true;
        isAtStorefront = false;
        SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);

        ItemPlacer.isPlacing = false;
        ItemPlacer.isSelecting = false;
        if (ItemPlacer.current != null)
            ItemPlacer.delete();
        staticMainPanel.SetActive(true);
        staticInventoryPanel.SetActive(false);
        currentScene = "Inventory";
    }

    //assumes on storefront for now
    //perhaps button from storefront becomes available when next month begins (pause when button becomes setactive(true)?
    public void storeToReport(Button myButton)
    {
        shelfPanel.SetActive(false);
        drugListPanel.SetActive(false);
        DrugSelectPanel.needToUpdate = true;
        currentScene = "Report";
        isAtStorefront = false;       
        staticMainPanel.SetActive(false);
        GameObject myPanel = myButton.transform.parent.gameObject;
        myPanel.gameObject.SetActive(false);
        SceneManager.LoadScene("Report", LoadSceneMode.Additive);
    }

    public void reportToStore()
    {
        

        isAtStorefront = true;
        
        staticMainPanel.SetActive(true);
        Globals.loadTime = Globals.globalTime;
        

        Globals.sem = false;
        SceneManager.UnloadSceneAsync("Report");
        currentScene = "Storefront";
        
    }

    public static void forceToStore(GameObject reportPanel)
    {
        staticInventoryPanel.SetActive(false);
        ItemPlacer.isPlacing = false;
        ItemPlacer.isSelecting = false;
        if (ItemPlacer.current != null)
            ItemPlacer.delete();
        isAtStorefront = true;
        staticMainPanel.SetActive(false);
        reportPanel.SetActive(true);
        
        if(currentScene != "Storefront")
            SceneManager.UnloadSceneAsync(currentScene);
        currentScene = "Storefront";
    }
}
