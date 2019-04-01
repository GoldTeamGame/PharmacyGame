using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameObject : MonoBehaviour {

    public static GameObject selectedObject;
    private void OnMouseUp()
    {
        if (!(ItemPlacer.isPlacing || ItemPlacer.isSelecting) && SceneChanger.isAtStorefront)
        {
            ObjectReference.staticGo.SetActive(true);
            selectedObject = gameObject;
        }
    }
}
