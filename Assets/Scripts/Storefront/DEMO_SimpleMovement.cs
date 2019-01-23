// File: DEMO_SimpleMovement
// Description: Moves GameObject (customer) in a square pattern and
//      then de-spawns it when it reaches the end

// NOTE: This script is connected to the original customer object which is outside the camera view.
//      When a customer is spawned via the ProceduralGenerator, it is spawned with this script
//      which allows it to move. The original customer object does not move.

using UnityEngine;
using UnityEngine.UI;

public class DEMO_SimpleMovement {

    //public Text gold;
    //public float speed = 2f; // speed of the object
    bool hasTraveledRight = false;
    bool hasTraveledDown = false;
    bool hasPurchased = false;

    // Update is called once per frame
    public void move(Transform transform, float speed, Text gold)
    {
        // Used to keep the original object from moving
        // (Although its sorting order is so low, that it wont be seen even if it did)
        if (transform.position.x < -3)
            return;
        
        // Move in a hardcoded pattern
        if (transform.position.x <= 2 && !hasTraveledRight)
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        else if (transform.position.y >= 0 && !hasTraveledDown)
        {
            hasTraveledRight = true;
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        else if (transform.position.x >= -1.022488)
        {
            hasTraveledDown = true;
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            if (!hasPurchased && transform.position.x <= 0.2123806)
            {
                gold.text = "" + (int.Parse(gold.text) + Random.Range(1, 3));
                hasPurchased = true;
            }
        }
        else
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
