// File: ProceduralGenerator
// Version: 1.0.9
// Last Updated: 2/13/19
// Authors: Alexander Jacks
// Description: Spawns customers into game world

using UnityEngine;
using System.Collections.Generic;

public class ProceduralGenerator : MonoBehaviour
{
    public Transform parent; // The container that the customer will be spawned into
    public Sprite[] appearanceList; // contains sprites passed in from unity editor
    public static Sprite[] staticAppearanceList; // Static version of appearanceList which can be used in static functions
    public GameObject customer; // object being spawned
    public Transform spawnPoint; // location the object will be spawned at
    public float spawnTime = 5; // when the object will be spawned
    public SpriteRenderer sprite; // the sprite that represents the customer (will be overwritten)
    public static float xSpawnPoint; // the x-coordinate of the spawn point

    // Use this for initialization
    void Start()
    {
        Globals.setPlatinum(50);
        xSpawnPoint = spawnPoint.localPosition.x;

        // Instantiate customerData list if none currently exists
        if (Globals_Customer.customerData == null)
            Globals_Customer.customerData = new List<CustomerData>();

        // Copy non-static appearanceList into staticAppearanceList
        staticAppearanceList = new Sprite[appearanceList.Length];
        for (int i = 0; i < appearanceList.Length; i++)
            staticAppearanceList[i] = appearanceList[i];

        // Spawn all customers currently in customerData into the game world
        int numberOfCustomers = Globals_Customer.customerData.Count;
        for (int i = 0; i < numberOfCustomers; i++)
        {
            Vector3 v;
            CustomerData o = Globals_Customer.customerData[i];
            if (!Globals_Customer.customerData[i].isWaiting)
                v = new Vector3(Globals_Customer.customerData[i].path.getCurrentNode().position.x, Globals_Customer.customerData[i].path.getCurrentNode().position.y, 0);
            else
                v = new Vector3(Globals_Customer.customerData[i].locationX, Globals_Customer.customerData[i].locationY);
            instantiateObject(v);
        }

        InvokeRepeating("Spawn", 0, spawnTime); // start the script and repeat it every spawnTime second
    }

    // Spawn a new customer until the limit is reached
    private void Spawn()
    {
        if (Globals_Customer.customerData.Count < Globals_Customer.LIMIT)
            instantiateObject(spawnPoint.localPosition);
    }

    private void instantiateObject(Vector3 position)
    {
        GameObject go = Instantiate(customer, position, spawnPoint.rotation, parent); // spawn the customer
        go.transform.localPosition = position;
    }

    // Generate customer data
    public static void generate(ref CustomerData cd)
    {
        // Set cd equal to the last element in customerData
        // (This if-statement is for the sake of loading in customers that were saved in customerData)
        // (In other words, set cd equal to existing customerData element that exists in Globals_Customer)
        // (When currentNumberOfCustomers catches up to numberOfCustomers, that symbolizes that all customers have been loaded)
        if (Globals_Customer.numberOfCustomers < Globals_Customer.currentNumberOfCustomers)
        {
            cd = Globals_Customer.customerData[Globals_Customer.numberOfCustomers];
            Globals_Customer.numberOfCustomers++;
        }
        // Generate new customerData element and then add it to Globals_Customer.customerData
        else
        {
            string name = Globals_Customer.name[Random.Range(0, Globals_Customer.name.Length)]; // generate a random name
            float speed = .009f;
                //Random.Range(0.4f, 0.6f); // generate a random speed
            
            cd = new CustomerData(name, speed); // instantiate cd with name and speed
            cd.appearance = Random.Range(0, 9); // set appearance
            cd.mood = Random.Range(0, 6); // set a random mood
            cd.positionInLine = -1;
            // Set desires
            int overCounterSize = Toolbox.random(0, 3); // 0-3 overcounter drugs
            int prescriptionSize;

            // If overcounter amount is 0, then number of prescription drugs must be at least 1
            // (or the customer would have no reason to be in the store)
            if (overCounterSize > 0)
                prescriptionSize = Toolbox.random(0, 3);
            else
                prescriptionSize = Toolbox.random(1, 3);

            cd.desires = new Desires(overCounterSize, prescriptionSize);
            generateArray(ref cd.desires.overCounter, Globals.overCounterList, false);
            generateArray(ref cd.desires.prescription, Globals.drugList, true);

            if (cd.desires.overCounter.Length > 0)
                cd.thoughts = "Looking For: " + cd.desires.overCounter[0].drug.name;
            else
                cd.thoughts = "Going to pick up prescriptions";

            Globals_Customer.customerData.Add(cd); // add cd to Globals list
        }

        CustomerScreen.updateList(-1); // update CustomerScreen button list
    }

    // Fill array with drugs
    public static void generateArray(ref CartItem[] array, List<Drug> drugList, bool isPrescription)
    {
        int desireCount = 0; // current number of desires in array

        // Continue filling array while there are remaining available drugs
        // and while there is still remaining space in the array
        for (int i = 0; i < drugList.Count && desireCount < array.Length; i++)
            // Add drug to array if it passes the check
            // Customers may have over counter drugs on their list of desires that havent been unlocked yet,
            //      but as for prescription drugs, they will ONLY have it on their list if the player has it unlocked
            // (A person would not go to a store to pick up a prescription without first knowing it the store has the drug)
            // Of course, it is still possible that the store has none of the prescribed drug in stock, in which case, the customer will not be able to buy it,
            //      but it would still show up on their list of desires.
            if (Toolbox.randomBool(drugList[i].chance) || (isPrescription && drugList[i].isUnlocked))
                array[desireCount++] = new CartItem(drugList[i]);

        // If no desires were added, but the array length is 1, then forcefully add item to list
        if (desireCount == 0 && array.Length == 1)
        {
            array[0] = new CartItem(drugList[0]);
            desireCount++;
        }

        // If desire count is less than size of array, refactor array to match size of desire count
        if (desireCount < array.Length)
        {
            CartItem[] temp = new CartItem[desireCount];
            for (int i = 0; i < desireCount; i++)
                temp[i] = array[i];
            array = temp;
        }
    }
}
