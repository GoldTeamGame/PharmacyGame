using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public Canvas myCanvas;
	Vector3 startPosition;
	Vector2 pos;

	#region IBeginDragHandler implementation

	public void OnBeginDrag(PointerEventData eventData){
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}
	
	#endregion
	
	#region IDragHandler implementation

	public void OnDrag(PointerEventData eventData){
		float x = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x;
        float y = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y;
		Vector3 test = new Vector3(x,y);
		//RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(test);
	}
	
	#endregion
	
	#region IEndDragHandler implementation

	public void OnEndDrag(PointerEventData eventData){
		itemBeingDragged = null;
		transform.position = startPosition;
	}
	
	#endregion
	


// 	// Use this for initialization
// 	void Start () {
		
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
		
// 	}
}
