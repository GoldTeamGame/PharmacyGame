using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags
{
    // [0] = First time starting game
    // [1] = UI Explainaition
    // Explain currencies
    // Explain calender/game goal
    // Placing items
    // Assigning drugs
    // Customer introduction
    // Pharmacist Introduction
    // Pharmacist Assigning
    // Report
    public static bool[] storefront;

    // First time entering customers scene
    public static bool[] customers;

    public static bool[] inventory;

    public static bool[] shop;

    public static bool[] expansions;

    public static bool[] previousReports;

    public static bool[] statistics;

    public static bool[] quests;

    public static bool[] settings;

    public static bool[] report;

    public Flags()
    {
        storefront = new bool[100];
        customers = new bool[10];
        inventory = new bool[10];
        shop = new bool[10];
        expansions = new bool[10];
        previousReports = new bool[10];
        statistics = new bool[10];
        quests = new bool[10];
        settings = new bool[10];
        report = new bool[100];
    }
	
}
