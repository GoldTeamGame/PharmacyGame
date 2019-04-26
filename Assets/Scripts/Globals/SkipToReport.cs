using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipToReport : MonoBehaviour {

    public static bool isSkip;

    public void skip()
    {
        isSkip = true;
        this.gameObject.SetActive(false);
    }
}
