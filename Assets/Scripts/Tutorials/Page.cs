// File: Page
// Authors: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.0.1
// Description: A page of a tutorial. Holds data that will be shown on tutorial screen.

using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour {

    // All variables are self-explainatory
    public string header;
    public Sprite sprite;
    public string body;
    public string buttonText;

    public int size; // how wide the sprite should be (0: small, 1: medium, 2:large)

    public Page(string header, Sprite sprite, int size, string body, string buttonText)
    {
        this.header = header;
        this.sprite = sprite;
        this.size = size;
        this.body = body;
        this.buttonText = buttonText;
    }

    // Sets the tutorial screen using variables from the page
    public void setPage()
    {
        Globals_Tutorials.go[6].GetComponent<Scrollbar>().value = 1; // bring scrollbar to top
        Globals_Tutorials.go[0].GetComponent<Text>().text = header; // set contents of header
        
        // Enlarge parts of tutorial screen if there is no image
        if (sprite == null)
        {
            // Hide Image
            Globals_Tutorials.go[1].transform.parent.gameObject.SetActive(false);

            // Set background color size
            Globals_Tutorials.go[7].GetComponent<RectTransform>().sizeDelta = new Vector2(524, 550);
            Globals_Tutorials.go[7].GetComponent<RectTransform>().localPosition = new Vector3(0, 9);

            // Set scrollbar size
            Globals_Tutorials.go[6].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 550);

            // Set text panel size
            Globals_Tutorials.go[8].GetComponent<RectTransform>().sizeDelta = new Vector2(475, 550);
        }
        // Shrink parts of tutorial screen to make room for image
        else
        {
            // Show image
            Globals_Tutorials.go[9].SetActive(true);

            // Set images to appropriate size
            // Small Size
            if (size == 0)
            {
                Globals_Tutorials.go[9].GetComponent<RectTransform>().sizeDelta = new Vector2(335, 260);
                Globals_Tutorials.go[1].GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);
            }
            // Medium Size
            else if (size == 1)
            {
                Globals_Tutorials.go[9].GetComponent<RectTransform>().sizeDelta = new Vector2(525, 260);
                Globals_Tutorials.go[1].GetComponent<RectTransform>().sizeDelta = new Vector2(325, 150);
            }
            // Large Size
            else if (size == 2)
            {
                Globals_Tutorials.go[9].GetComponent<RectTransform>().sizeDelta = new Vector2(850, 260);
                Globals_Tutorials.go[1].GetComponent<RectTransform>().sizeDelta = new Vector2(500, 150);
            }

            // Set background color size
            Globals_Tutorials.go[7].GetComponent<RectTransform>().sizeDelta = new Vector2(524, 400);
            Globals_Tutorials.go[7].GetComponent<RectTransform>().localPosition = new Vector3(0, -130);

            // Set Scrollbar size
            Globals_Tutorials.go[6].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 390);

            // Set text panel size
            Globals_Tutorials.go[8].GetComponent<RectTransform>().sizeDelta = new Vector2(475, 400);

            Globals_Tutorials.go[1].GetComponent<Image>().sprite = sprite; // set contents of image
        }

        Globals_Tutorials.go[2].GetComponent<Text>().text = body; // set contents of body
        Globals_Tutorials.go[3].GetComponent<Text>().text = buttonText; // set contents of button
    }
}
