/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 2/24/2019
 * Description: Displays the four areas to drop an expansion item. These zones are hidden unless the player enters the edit mode.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAreas : MonoBehaviour {

    public GameObject go;
    public Button topLeft;
    public Button topRight;
    public Button botLeft;
    public Button botRight;

    public Sprite currSprite;

    public void Place(Button btn)
    {
        //make a game object out of a sprite (sprites don't have transforms!)
        go.GetComponent<SpriteRenderer>().sprite = currSprite;
        go.transform.position = btn.transform.position;
        //NOTE: Made the button transform z position 138!!! prevents the game object from appearing across different scenes
        //leave edit mode 
        Globals.inEditMode = false;
    }

    void Update () {
		if(Globals.inEditMode)
        {
            topLeft.gameObject.SetActive(true);
            topRight.gameObject.SetActive(true);
            botLeft.gameObject.SetActive(true);
            botRight.gameObject.SetActive(true);
        }
        else
        {
            topLeft.gameObject.SetActive(false);
            topRight.gameObject.SetActive(false);
            botLeft.gameObject.SetActive(false);
            botRight.gameObject.SetActive(false);
        }
	}
}
