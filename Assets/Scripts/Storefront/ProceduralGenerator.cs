// File: ProceduralGenerator
// Description: Simply spawns customers at the specified time

using UnityEngine;
using System.Collections.Generic;

public class ProceduralGenerator : MonoBehaviour {

    public GameObject customer; // object being spawned
    public Transform spawnPoint; // location the object will be spawned at
    public float spawnTime = 5; // when the object will be spawned
    public SpriteRenderer sprite; // the sprite that represents the customer

    // Use this for initialization
    void Start()
    {
        if (Globals_Customer.customerData == null)
            Globals_Customer.customerData = new List<CustomerData>();

        int number = Globals_Customer.customerData.Count;

        for (int i = 0; i < number; i++)
        {
            Vector3 v = new Vector3(Globals_Customer.customerData[i].locationX, Globals_Customer.customerData[i].locationY, 0);
            Instantiate(customer, v, spawnPoint.rotation);
        }

        InvokeRepeating("Spawn", 0, spawnTime); // start the script and repeat it every spawnTime second
    }

    // Spawn the customer
    void Spawn()
    {
        if (Globals_Customer.customerData.Count < Globals_Customer.LIMIT)
            Instantiate(customer, spawnPoint.position, spawnPoint.rotation); // spawn the customer
    }

    // Generate customer data
    public static void generate(ref CustomerData cd, ref DEMO_SimpleMovement movement)
    {
        if (Globals_Customer.numberOfCustomers < Globals_Customer.currentNumberOfCustomers)
        {
            cd = Globals_Customer.customerData[Globals_Customer.numberOfCustomers];
            Globals_Customer.numberOfCustomers++;
        }
        else
        {
            string name = Globals_Customer.name[Random.Range(0, Globals_Customer.name.Length)]; // generate a name
            float speed = Random.Range(0.5f, 1f); // generate a speed

            cd = new CustomerData(name, speed);
            Globals_Customer.customerData.Add(cd);
        }

        movement = new DEMO_SimpleMovement(); // instantiate movement class
    }

}
