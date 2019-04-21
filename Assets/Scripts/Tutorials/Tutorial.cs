// File: Tutorial
// Authors: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.0.1
// Description: A Tutorial class which has multiple pages and functions for viewing the pages.

using UnityEngine;

public class Tutorial
{
    public int numberOfPages; // length of page
    Page[] page; // the pages of the tutorial

    public Tutorial(int numberOfPages)
    {
        this.numberOfPages = numberOfPages;
        page = new Page[numberOfPages];
    }

    // Reset tutorial
    public void setToStart()
    {
        Globals_Tutorials.pageIndex = 0;
    }

    // Show current tutorial and then move index to prep for the next tutorial page
    public void showCurrentPage()
    {
        page[Globals_Tutorials.pageIndex++].setPage();
    }

    // Instantiates a page[] element
    public void addPage(int index, string header, Sprite sprite, int size, string body)
    {
        string buttonText = "Next";
        if (index == page.Length - 1)
            buttonText = "OK";

        page[index] = new Page(header, sprite, size, body, buttonText);
    }
}
