using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameObject : MonoBehaviour {

    public static GameObject selectedObject;
    public static int clicks = 0;
    private void OnMouseDown()
    {
        if (!(ItemPlacer.isPlacing || ItemPlacer.isSelecting) && SceneChanger.isAtStorefront)
        {
            ObjectReference.staticGo.SetActive(true);
            selectedObject = gameObject;
        }
    }
}
