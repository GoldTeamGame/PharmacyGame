// File: ProceduralGenerator
// Description: Simply spawns customers at the specified time

using UnityEngine;

public class ProceduralGenerator : MonoBehaviour {

    public GameObject customer; // object being spawned
    public Transform spawnPoint; // location the object will be spawned at
    public float spawnTime = 5; // when the object will be spawned
    public SpriteRenderer sprite; // the sprite that represents the customer

    // Use this for initialization
    void Start()
    {
        if (Globals_Customer.customerData == null)
            Globals_Customer.customerData = new CustomerData[Globals_Customer.MAX_CUSTOMERS];
        for (int i = 0; i < Globals_Customer.MAX_CUSTOMERS; i++)
        {
            if (Globals_Customer.customerData[i] != null && Globals_Customer.customerData[i].isAlive)
            {
                Vector3 v = new Vector3(Globals_Customer.customerData[i].locationX, Globals_Customer.customerData[i].locationY, 0);
                Instantiate(customer, v, spawnPoint.rotation);
            }
        }
        InvokeRepeating("Spawn", 1, spawnTime); // start the script and repeat it every spawnTime second
    }

    // Spawn the customer
    void Spawn()
    {
        // Do not Spawn customer if max capacity is reached
        if (Globals_Customer.numberOfCustomers < Globals_Customer.MAX_CUSTOMERS)
            Instantiate(customer, spawnPoint.position, spawnPoint.rotation); // spawn the customer
    }

    // Generate customer data
    public static void generate(ref CustomerData cd, ref DEMO_SimpleMovement movement)
    {
        // Find an available id
        int id = 0;
        for (int i = 0; i < Globals_Customer.MAX_CUSTOMERS; i++)
        {
            if (Globals_Customer.customerData[i] != null && Globals_Customer.customerData[i].isAlive && id < 9)
            {
                id++;
            }
        }
                string name = Globals_Customer.name[Random.Range(0, Globals_Customer.name.Length)]; // generate a name
        float speed = Random.Range(0.5f, 1f); // generate a speed

        cd = new CustomerData(id, name, speed);

        movement = new DEMO_SimpleMovement(); // instantiate movement class
        Globals_Customer.numberOfCustomers++; // increment number of customers
    }

}
