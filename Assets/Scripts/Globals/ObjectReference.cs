using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReference : MonoBehaviour {

    public static GameObject[] staticGo;
    public GameObject[] go;

	// Use this for initialization
	void Start ()
    {
        staticGo = go;
	}
}
