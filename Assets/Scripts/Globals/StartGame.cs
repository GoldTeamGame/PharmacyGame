using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public void startGame()
    {
        Globals_Customer.limit = 5;
        this.gameObject.SetActive(false);
    }
}
