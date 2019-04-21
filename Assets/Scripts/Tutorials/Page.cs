using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour {

    public string header;
    public Sprite sprite;
    public string body;
    public string buttonText;

    public Page(string header, Sprite sprite, string body, string buttonText)
    {
        this.header = header;
        this.sprite = sprite;
        this.body = body;
        this.buttonText = buttonText;
    }

    public void setPage(float width, float height)
    {
        Globals_Tutorials.go[0].GetComponent<Text>().text = header;
        Globals_Tutorials.go[1].GetComponent<Image>().sprite = sprite;
        Globals_Tutorials.go[2].GetComponent<Text>().text = body;
        Globals_Tutorials.go[3].GetComponent<Text>().text = buttonText;
    }
}
