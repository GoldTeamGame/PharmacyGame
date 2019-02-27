using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	Vector3 startPosition;

	#region IBeginDragHandler implementation

	public void OnBeginDrag(PointerEventData eventData){
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}
	
	#endregion
	
	#region IDragHandler implementation

	public void OnDrag(PointerEventData eventData){
		transform.position = Input.mousePosition;
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
