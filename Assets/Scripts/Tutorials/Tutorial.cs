using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial
{
    int startIndex;
    public int numberOfPages;
    Page[] page;

    public Tutorial(int startIndex, int numberOfPages)
    {
        this.startIndex = startIndex;
        this.numberOfPages = numberOfPages;
        page = new Page[numberOfPages];
    }

    public void setToStart()
    {
        Globals_Tutorials.tutorialIndex = startIndex;
    }

    public void showCurrentPage()
    {
        page[Globals_Tutorials.pageIndex++].setPage(0, 0);
    }

    public void addPage(int index, string header, Sprite sprite, string body)
    {
        string buttonText = "Next";
        if (index == page.Length - 1)
            buttonText = "OK";

        page[index] = new Page(header, sprite, body, buttonText);
    }
}
