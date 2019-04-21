using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour {

    public string header;
    public Sprite sprite;
    public int size;
    public string body;
    public string buttonText;

    public Page(string header, Sprite sprite, int size, string body, string buttonText)
    {
        this.header = header;
        this.sprite = sprite;
        this.size = size;
        this.body = body;
        this.buttonText = buttonText;
    }

    public void setPage()
    {
        Globals_Tutorials.go[6].GetComponent<Scrollbar>().value = 1;
        Globals_Tutorials.go[0].GetComponent<Text>().text = header;
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
        else
        {
            // Show image
            Globals_Tutorials.go[9].SetActive(true);

            // Set images to appropriate size
            if (size == 0)
            {
                Globals_Tutorials.go[9].GetComponent<RectTransform>().sizeDelta = new Vector2(335, 260);
                Globals_Tutorials.go[1].GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);
            }
            else if (size == 1)
            {
                Globals_Tutorials.go[9].GetComponent<RectTransform>().sizeDelta = new Vector2(525, 260);
                Globals_Tutorials.go[1].GetComponent<RectTransform>().sizeDelta = new Vector2(325, 150);
            }
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

            Globals_Tutorials.go[1].GetComponent<Image>().sprite = sprite;
        }
        Globals_Tutorials.go[2].GetComponent<Text>().text = body;
        Globals_Tutorials.go[3].GetComponent<Text>().text = buttonText;
    }
}
