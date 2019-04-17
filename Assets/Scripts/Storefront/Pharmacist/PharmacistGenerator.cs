using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacistGenerator : MonoBehaviour
{
    public Sprite[] APPEARANCE; // Hardcoded sprite array
    public GameObject pharmacist; // passed in gameObject prefab for pharmacist
    public Transform parent; // The tilemap transform the pharmacist will belong to

	// Use this for initialization
	void Start()
    {
        // If pharmacistCounter is null, then the game is new,
        // so generate counters and pharmacists and assign an employee to the counter
        if (Globals_Pharmacist.pharmacistCounter == null)
        {
            // Generate global data
            generateCounters();
            generatePharmacistList();

            // Create and assign pharmacist to counter
            Globals_Pharmacist.pharmacistList[0].isUnlocked = true;
            Globals_Pharmacist.pharmacistList[0].counter = 0;
            generatePharmacist(Globals_Pharmacist.pharmacistList[0]);
        }
        else
        {
            for (int i = 0; i < Globals_Pharmacist.pharmacistList.Count; i++)
                generatePharmacist(Globals_Pharmacist.pharmacistList[i]);
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
        }
    }

    // Generate pharmacist list on new game
    void generatePharmacistList()
    {
        Globals_Pharmacist.pharmacistList = new List<Pharmacist>();

        Globals_Pharmacist.pharmacistList.Add(new Pharmacist("Dylan", 0, "A dude that works for free", 0, 3, 3, 3, 3, 0.005f, 0));
        Globals_Pharmacist.pharmacistList.Add(new Pharmacist("Jon", 15, "Works at his own pace", 1, 3, 3, 3, 3, 0.005f, 0));
        Globals_Pharmacist.pharmacistList.Add(new Pharmacist("Ross", 19, "Standard skilled employee", 2, 3, 3, 3, 3, 0.005f, 0));
        Globals_Pharmacist.pharmacistList.Add(new Pharmacist("Alex", 22, "Hard working and reliable", 3, 3, 3, 3, 3, 0.005f, 0));
    }

    // Generate pharmacist counters on new save
    void generateCounters()
    {
        // Instantiate pharmacistCounter list using predefined locations
        for (int i = 0; i < Globals_Pharmacist.STARTING_LOCATIONS.Length; i++)
        {
            Globals_Pharmacist.pharmacistCounter = new PharmacistCounter[Globals_Pharmacist.STARTING_LOCATIONS.Length];
            Globals_Pharmacist.pharmacistCounter[i] = new PharmacistCounter(Globals_Pharmacist.STARTING_LOCATIONS[i]);
        }
    }
}
