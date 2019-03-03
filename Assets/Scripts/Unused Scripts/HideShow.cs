// File: HideShow
// Description: Hides and Shows the lower panel after the arrow button is clicked/tapped

using UnityEngine;
using UnityEngine.UI;

public class HideShow : MonoBehaviour
{
    public GameObject panel; // the lower panel in canvas
    public Button button; // the arrow button
    public Sprite[] sprite = new Sprite[2]; // [0] is show sprite, [1] is hide sprite
    private bool isShowing = true; // boolean to keep track of current state of panel

    // Hide or show panel
	public void togglePanel()
    {
        // If panel is showing, then hide it
        // If panel is hiding, then show it
        if (isShowing)
        {
            button.image.sprite = sprite[0]; // set arrow button image to the "show" sprite
            panel.transform.position = new Vector3(panel.transform.position.x, -5.82f, 0); // hide the panel
        }
        else
        {
            button.image.sprite = sprite[1]; // set the arrow button image to the "hide" sprite
            panel.transform.position = new Vector3(panel.transform.position.x, -4.16f, 0); // show the panel
        }

        isShowing = !isShowing; // inverse boolean state

    }
}
