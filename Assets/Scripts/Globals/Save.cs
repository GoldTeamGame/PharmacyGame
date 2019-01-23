using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{

    public List<int> CustomerPositions = new List<int>();

    public int p = 0;
    public int g = 0;

    public object shots { get; internal set; }
}