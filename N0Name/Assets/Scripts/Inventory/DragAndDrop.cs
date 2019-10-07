using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 public static GameObject item; //itemBeingDragged

 Vector3 startPosition;
public static Transform startParent;
public static ItemStack itemMoved;
public static GameObject origin;


public void OnBeginDrag(PointerEventData eventData){
    itemMoved = transform.parent.parent.GetComponent<Slot>().itemStack;
    item = gameObject;
    startPosition = transform.position;
    startParent = transform.parent;
    origin = transform.parent.parent.parent.gameObject;
    GetComponent<CanvasGroup>().blocksRaycasts = false;
    transform.SetParent(transform.root);
}

public void OnDrag(PointerEventData eventData){
    transform.position = Input.mousePosition;
}

public void OnEndDrag(PointerEventData eventData){
    item = null;
    if(transform.parent == startParent || transform.parent == transform.root) {
        transform.position = startPosition;
        transform.SetParent (startParent); 
    }
    GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

