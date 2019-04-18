using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteraction : MonoBehaviour
{
    public static string name;

    private void OnMouseUp()
    {
        name = transform.parent.gameObject.name;
        ObjectReference.staticGo[1].SetActive(true);
    }
}
