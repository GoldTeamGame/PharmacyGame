using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScreen : MonoBehaviour {

    public GameObject button;
    private static GameObject staticButton;
    private static Transform staticTransform;
    private static List<GameObject> buttonList;
    public static bool isCustomerScreen = false;

	// Use this for initialization
	void Start () {
        isCustomerScreen = true;
        buttonList = new List<GameObject>();
        staticButton = button;
        staticTransform = transform;
        updateList();
        //Text[] names = button.GetComponents<Text>();
        //names[0].text = "Hi";
        //names[1].text = "Bad";

    }

    void updateList()
    {
        CustomerData cd;
        for (int i = 0; i < Globals_Customer.customerData.Count; i++)
        {
            GameObject newButton = Instantiate(button, transform);
            cd = Globals_Customer.customerData[i];
            newButton.GetComponentsInChildren<Text>()[0].text = cd.name;
            newButton.GetComponentsInChildren<Image>()[1].sprite = ProceduralGenerator.appearance[cd.appearance];
            buttonList.Add(newButton);
        }
    }

    public static void updateList(int num)
    {
        CustomerData cd;

        if (isCustomerScreen)
        {
            // Add new customer to list
            if (num == -1)
            {
                GameObject newButton = Instantiate(staticButton, staticTransform);
                cd = Globals_Customer.customerData[Globals_Customer.customerData.Count - 1]; // Last element in customerData is the new customer
                newButton.GetComponentsInChildren<Text>()[0].text = cd.name;
                newButton.GetComponentsInChildren<Image>()[1].sprite = ProceduralGenerator.appearance[cd.appearance];
                buttonList.Add(newButton);
            }
            // Remove the specified customer from list
            else if (num > -1)
            {
                Destroy(buttonList[num]);
                buttonList.RemoveAt(num);
            }
        }
    }
}
