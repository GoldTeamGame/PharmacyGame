using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCurency : MonoBehaviour
{

    public Text gold;
    public Text platinum;
    // Update is called once per frame
    void Update()
    {
        gold.text = Globals.getGold().ToString();
        platinum.text = Globals.getPlatinum().ToString();

    }
}
