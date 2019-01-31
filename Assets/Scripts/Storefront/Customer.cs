using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {

    CustomerData cd;
    DEMO_SimpleMovement movement;
    
    
    // Generate Customer Data
    private void Start()
    {
        ProceduralGenerator.generate(ref cd, ref movement); // pass variables to ProceduralGenerator
        GetComponent<SpriteRenderer>().sprite = ProceduralGenerator.appearance[cd.appearance];
        transform.localScale = new Vector3(1.5f, 1.5f, 0);
    }

    // Dictates a customer's actions
    private void Update()
    {
        movement.move(transform, 1); // Move
        cd.locationX = transform.position.x;
        cd.locationY = transform.position.y;

        // Delete the object after it has reached the end
        if (transform.position.y > 4)
        {
            Globals_Customer.customerData.Remove(cd);
            Destroy(gameObject);
            cd.isAlive = false; // set customer to "dead" allowing its id to be replaced
        }
    }
}
