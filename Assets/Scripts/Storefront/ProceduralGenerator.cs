﻿// File: ProceduralGenerator
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
            Vector3 v = new Vector3(Globals_Customer.customerData[i].locationX, Globals_Customer.customerData[i].locationY, 0);
            instantiateObject(v);
        }

        InvokeRepeating("Spawn", 0, spawnTime); // start the script and repeat it every spawnTime second
    }

    // Spawn a new customer until the limit is reached
    private void Spawn()
    {
        if (Globals_Customer.customerData.Count < Globals_Customer.LIMIT)
            instantiateObject(spawnPoint.position);
    }

    private void instantiateObject(Vector3 position)
    {
        Instantiate(customer, position, spawnPoint.rotation, parent); // spawn the customer
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
            float speed = .4f;
                //Random.Range(0.4f, 0.6f); // generate a random speed
            
            cd = new CustomerData(name, speed); // instantiate cd with name and speed
            cd.appearance = Random.Range(0, 9); // set appearance
            cd.mood = Random.Range(0, 6); // set a random mood

            // Set desires
            generateDesires(ref cd);

            Globals_Customer.customerData.Add(cd); // add cd to Globals list
        }

        CustomerScreen.updateList(-1); // update CustomerScreen button list
    }

    private static void generateDesires(ref CustomerData cd)
    {
        int maxNumberOfDesires = 3;
        int numberOfDesires = Random.Range(1, maxNumberOfDesires + 1);

        cd.desires = new string[numberOfDesires];

        // HARDCODED UNTIL PROGRESS WITH DRUGS IS MADE
        if (numberOfDesires == 1)
        {
            cd.desires[0] = "Ventolin";
        }
        else if (numberOfDesires == 2)
        {
            cd.desires[0] = "Ventolin";
            cd.desires[1] = "Vyvanse";
        }
        else if (numberOfDesires == 3)
        {
            cd.desires[0] = "Ventolin";
            cd.desires[1] = "Vyvanse";
            cd.desires[2] = "Lyrica";
        }
            
    }
}
