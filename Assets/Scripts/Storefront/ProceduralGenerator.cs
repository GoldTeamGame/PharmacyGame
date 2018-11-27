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
        InvokeRepeating("Spawn", 0, spawnTime); // start the script and repeat it every spawnTime seconds
    }
    
    // Spawn the customer
    void Spawn()
    {
        sprite.sortingOrder = -3; // move sprite sorting order up so that it can be seen
        sprite.size.Scale(new Vector2(1, 1)); // set the size of the sprite, just in case it isn't set properly
        Instantiate(customer, spawnPoint.position, spawnPoint.rotation); // spawn the customer
    }
}
