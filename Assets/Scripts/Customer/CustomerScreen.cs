// File: CustomerScreen
// Version: 1.0.7
// Last Updated: 2/4/19
// Authors: Alexander Jacks
// Description: Script to manage activity on the Customer Screen

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomerScreen : MonoBehaviour
{
    public Button button; // The button template which are added to the list of buttons
    private static Button staticButton; // Will be set as button (needed for use in static functions)
    private static Transform staticTransform; // Needed as an arguement for instantiating button (needed for use in static functions)

    // The list of buttons currently being shown
    // NOTE: buttonList List elements corresponds with Globals_Customer.customerData List elements
    private static List<Button> buttonList; 

    public RectTransform panel; // Panel that shows extra customer information
    public static RectTransform staticPanel; // Will be set as panel (needed for use in static functions)

    public static int currentCustomer = -1; // Holds the index of the currently selected customer

    public static bool isAtCustomerScene = false; // Says if customer screen is open

	// Use this for initialization
	void Start ()
    {
        // Instiate buttonList
        buttonList = new List<Button>();

        // Set static variables equal to the objects being passed
        staticButton = button;
        staticPanel = panel;
        staticTransform = transform;

        // Fill the buttonList with customers (from customerData saved in Globals_Customer)
        updateList();
    }

    // Generates buttons for every existing customer
    void updateList()
    {
        // Add a button for every item in Globals_Customer.customerData list
        int numberOfCustomers = Globals_Customer.customerData.Count; // create integer to store current amount of customers
        for (int i = 0; i < numberOfCustomers; i++)
        {
            createButton(i);
        }
    }

    // Creates or removes a customer whenever a customer enters the store or leaves
    public static void updateList(int num)
    {
        if (isAtCustomerScene)
        {
            // Add new customer to the end of the list
            if (num == -1)
                createButton(buttonList.Count);
            // Remove the specified customer from list
            else if (num > -1)
            {
                Destroy(buttonList[num].gameObject); // remove gameobject from scene
                buttonList.RemoveAt(num); // remove data from list
            }
        }
    }

    // Generate a button using Globals_Customer.customerData[index]
    private static void createButton(int index)
    {
        Button newButton = Instantiate(staticButton, staticTransform); // Instantiate button into object (scroll panel)
        CustomerData cd = Globals_Customer.customerData[index]; // set cd equal to whatever is in Globals_Customer

        // Set button variables
        newButton.GetComponentsInChildren<Text>()[0].text = cd.name; // set name
        newButton.GetComponentsInChildren<Text>()[1].text = Globals_Customer.mood[Globals_Customer.customerData[index].mood]; // set mood
        newButton.GetComponentsInChildren<Image>()[1].sprite = ProceduralGenerator.staticAppearanceList[cd.appearance]; // set image

        // Add Listener to button
        newButton.onClick.AddListener(viewInformation);

        // Add button to buttonList
        buttonList.Add(newButton);
    }

    // Opens the customer information screen
    public static void viewInformation()
    {
        // Show panel
        staticPanel.gameObject.SetActive(true);

        // Find the index of the button selected
        int numberOfCustomers = buttonList.Count;
        int index = -1;
        for (int i = 0; i < buttonList.Count; i++)
            if (EventSystem.current.currentSelectedGameObject.transform.position.y == buttonList[i].transform.position.y)
                index = i;

        // Set the panel information with Globals_Customer.customerData[index]
        if (index > -1)
        {
            currentCustomer = index; // set global index to index
            staticPanel.GetComponentsInChildren<Image>()[2].sprite = ProceduralGenerator.staticAppearanceList[Globals_Customer.customerData[index].appearance]; // set image
            staticPanel.GetComponentsInChildren<Text>()[0].text = Globals_Customer.customerData[index].name; // set name
            staticPanel.GetComponentsInChildren<Text>()[1].text = Globals_Customer.mood[Globals_Customer.customerData[index].mood]; // set mood
            staticPanel.GetComponentsInChildren<Text>()[3].text = Globals_Customer.customerData[index].thoughts; // set current thoughts

            // List desires
            listDesires(Globals_Customer.customerData[index]);
        }
    }

    // Sets the desires list on the customer info panel
    public static void listDesires(CustomerData cd)
    {
        // Fill string with desires
        string listOfDesires = "";
        for (int i = 0; i < cd.numberOfDesires; i++)
            listOfDesires += cd.desires[i] + "\n";
        for (int i = 0; i < cd.numberOfPrescriptionDesires; i++)
            listOfDesires += cd.prescriptionDesires[i] + "\n";

        staticPanel.GetComponentsInChildren<Text>()[5].text = listOfDesires; // set desires
    }
}
