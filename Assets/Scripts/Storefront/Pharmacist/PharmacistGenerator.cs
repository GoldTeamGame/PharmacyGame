using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistGenerator : MonoBehaviour
{
    public static Sprite[] STATIC_APPEARANCE;
    public Sprite[] APPEARANCE; // Hardcoded sprite array
    public GameObject pharmacist; // passed in gameObject prefab for pharmacist
    public Transform parent; // The tilemap transform the pharmacist will belong to

    public GameObject[] zone;
    public GameObject[] block;

	// Use this for initialization
	void Start()
    {
        Globals_Pharmacist.zone = zone;
        Globals_Pharmacist.block = block;
        STATIC_APPEARANCE = APPEARANCE;
        // If pharmacistCounter is null, then the game is new,
        // so generate counters and pharmacists and assign an employee to the counter
        if (Globals_Pharmacist.pharmacistCounter == null)
        {
            // Generate global data
            Globals_Pharmacist.pharmacistGo = new GameObject[3];
            generateCounters();

            // Create and assign pharmacist to counter
            ((Pharmacist)Globals_Items.item[2][0]).isUnlocked = true;
            ((Pharmacist)Globals_Items.item[2][0]).counter = 0;
            generatePharmacist(((Pharmacist)Globals_Items.item[2][0]));
        }
        else
        {
            Globals_Pharmacist.pharmacistGo = new GameObject[3];
            if (Globals_Pharmacist.pharmacistCounter[1].isUnlocked)
            {
                block[0].SetActive(false);
                zone[0].SetActive(true);
            }

            if (Globals_Pharmacist.pharmacistCounter[2].isUnlocked)
            {
                block[1].SetActive(false);
                zone[1].SetActive(true);
            }

            for (int i = 0; i < Globals_Items.item[2].Length; i++)
                generatePharmacist(((Pharmacist)Globals_Items.item[2][i]));
        }

	}

    // Prepare and instantiate gameobject
    void generatePharmacist(Pharmacist p)
    {
        // Do not instantiate customer if they are not assigned to a counter
        if (p.counter >= 0)
        {
            // Find position of pharmacist
            Position pos;
            if (p.currentState == -1 || p.currentState > 2)
                pos = Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[0];
            else
                pos = Globals_Pharmacist.pharmacistCounter[p.counter].pharmacistZone[p.currentState];

            GameObject go = Instantiate(pharmacist, parent); // instantiate object
            go.transform.localPosition = new Vector3(pos.x, pos.y); // set position
            go.GetComponent<PharmacistController>().p = p; // set Pharmacist
            go.GetComponent<SpriteRenderer>().sprite = APPEARANCE[p.appearance];
            go.transform.localScale = new Vector3(2.25f, 2.25f, 0); // set customer sprite size (make it bigger)
            Globals_Pharmacist.pharmacistGo[p.counter] = go; // set globals gameobject
        }
    }

    // Generate pharmacist counters on new save
    void generateCounters()
    {
        Globals_Pharmacist.pharmacistCounter = new PharmacistCounter[Globals_Pharmacist.STARTING_LOCATIONS.Length];

        // Instantiate pharmacistCounter list using predefined locations
        for (int i = 0; i < Globals_Pharmacist.STARTING_LOCATIONS.Length; i++)
        {
            Globals_Pharmacist.pharmacistCounter[i] = new PharmacistCounter(Globals_Pharmacist.STARTING_LOCATIONS[i]);
        }

        Globals_Pharmacist.pharmacistCounter[0].isPharmacist = true;
    }

    public static void resetPharmacist()
    {
        // Reset all pharmacist counters
        for (int i = 0; i < Globals_Pharmacist.pharmacistCounter.Length; i++)
        {
            if (Globals_Pharmacist.pharmacistCounter[i].isUnlocked)
            {
                Globals_Pharmacist.pharmacistCounter[i].isCustomer = false;
                Globals_Pharmacist.pharmacistCounter[i].isFinished = false;
                Globals_Pharmacist.pharmacistCounter[i].numberInLine = 0;
            }
        }
    }
}
