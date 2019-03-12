﻿// File: SceneChanger
// Version: 1.0.4
// Last Updated: 2/24/19
// Authors: Alexander Jacks, Dylan Cyphers
// Description: Has button functions to change scenes

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string currentScene; // Keeps track of which scene is currently being viewed
    public static bool isAtStorefront = true; // True if focus is on storefront scene
    public Button back; // Button used to return to storefront scene
    //public Button hideShow; // Button used to hide menu interface
    public GameObject mainPanel;
    public GameObject inventoryPanel;
    public static GameObject staticMainPanel;
    public static GameObject staticInventoryPanel;

    public void Start()
    {
        if (currentScene.Equals("Storefront"))
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

        // Enable back button
        back.gameObject.SetActive(true);

        // Load scene on top of storefront if there isn't already aother scene open
        if (isAtStorefront)
        {
            isAtStorefront = false;
            currentScene = scene;

            CustomerScreen.isAtCustomerScene = scene.Equals("Customers");
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
        if (currentScene.Equals("Inventory") && ItemPlacer.isPlacing)
        {
            ItemPlacer.isPlacing = false;
            if (ItemPlacer.current != null)
                ItemPlacer.delete();
            staticInventoryPanel.SetActive(false);
            staticMainPanel.SetActive(true);
            back.gameObject.SetActive(false);
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
        }
    }

    //called when placing an item from the inventory into the storefront
    public void invToStorefront()
    {
        //Globals.inEditMode = true;
        isAtStorefront = true; 
        SceneManager.UnloadSceneAsync("Inventory"); // unload inventory scene
        ItemPlacer.rotationState = 0;

        // Replace main bottom panel with the inventory placement panel
        staticMainPanel.SetActive(false);
        staticInventoryPanel.SetActive(true);
    }

    public void storefrontToInv()
    {
        isAtStorefront = false;
        SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);

        ItemPlacer.isPlacing = false;
        if (ItemPlacer.current != null)
            ItemPlacer.delete();
        staticMainPanel.SetActive(true);
        staticInventoryPanel.SetActive(false);
    }
}
