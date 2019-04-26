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
    public static string cScene;


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

        cScene = scene;
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

        cScene = "Storefront";
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
        cScene = "InventoryStorefront";
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
        cScene = "Inventory";
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
        cScene = "Report";
    }

    public void reportToStore()
    {
        isAtStorefront = true;
        Clock.start(); // start timer
        Globals_Customer.limit = Globals_Customer._limit; // set limit back to what it was before
        Calendar.isReport = false;

        staticMainPanel.SetActive(true);
        Globals.loadTime = Globals.globalTime;
        

        Globals.sem = false;
        SceneManager.UnloadSceneAsync("Report");
        currentScene = "Storefront";
        cScene = "Storefront";
    }

    public static void forceToStore(GameObject reportPanel)
    {
        if (ItemPlacer.isPlacing || ItemPlacer.isSelecting)
        {
            staticInventoryPanel.SetActive(false);
            ItemPlacer.isPlacing = false;
            ItemPlacer.isSelecting = false;
        }
        if (ItemPlacer.current != null)
            ItemPlacer.delete();
        isAtStorefront = true;
        if (staticMainPanel != null)
            staticMainPanel.SetActive(false);
        reportPanel.SetActive(true);

        if(currentScene != null && currentScene != "Storefront")
            SceneManager.UnloadSceneAsync(currentScene);
        currentScene = "Storefront";
        cScene = "ReportStorefront";

        // Reset mood
        Globals_Customer.globalMood = 50;
        Globals_Customer.cumulativeMood = 0;
        Globals_Customer.customersServed = 0;
    }

    // Button-Click function
    // Displays the approriate tutorial based on the current scene
    public void showTutorial()
    {
        if (Globals_Tutorials.tutorialIndex > 17)
        {
            Globals_Tutorials.tutorialIndex = findIndex(); // set index
            Globals_Tutorials.pageIndex = 0; // reset page index
            Globals_Tutorials.tutorial[Globals_Tutorials.tutorialIndex].showCurrentPage(); // show currently selected tutorial
            Globals_Tutorials.go[4].SetActive(true); // show panel
        }
    }

    // Determine the index that will be used based on the current scene
    private int findIndex()
    {
        switch (cScene)
        {
            case "Storefront":
                return 18;
            case "InventoryStorefront":
                return 19;
            case "ReportStorefront":
                return 20;
            case "Customers":
                return 21;
            case "Inventory":
                return 22;
            case "Shop":
                return 23;
            case "Expansion":
                return 24;
            case "PreviousReports":
                return 25;
            case "Statistics":
                return 26;
            case "Report":
                return 27;
            default:
                return 18;
        }
    }
}
