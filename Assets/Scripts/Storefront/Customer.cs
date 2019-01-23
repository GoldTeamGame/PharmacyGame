using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
    
    public Text gold;

    public int id; // unique id to find customer in its array
    public string name; // name of customer
    public float speed; // speed that customer moves
    public string[] desires; // what a customer wants to buy
    public int happiness; // how happy a customer is
    DEMO_SimpleMovement movement;
    //public double wallet; // amount of money a customer has
    

    private void Start()
    {
        id = Globals_Customer.currentID++;
        name = ProceduralGenerator.generateName();
        speed = ProceduralGenerator.generateSpeed();
        movement = new DEMO_SimpleMovement();
        //Globals_Customer.customerData[id] = this;
    }

    private void Update()
    {
        movement.move(transform, speed, gold);

        // Delete the object after it has reached the end
        if (transform.position.y > 4)
            Destroy(gameObject);
    }
}
