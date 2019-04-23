using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CounterInteraction : MonoBehaviour, IPointerClickHandler
{
    public static string name;

    public void OnPointerClick(PointerEventData data)
    {
        name = transform.parent.gameObject.name;
        ObjectReference.staticGo[1].SetActive(true);
    }
}
