using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Transform parentToReturn;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturn = transform.parent;
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetParent(parentToReturn);
    }

    public void changeParent(Transform newParent)
    {
        parentToReturn = newParent;
    }
}
