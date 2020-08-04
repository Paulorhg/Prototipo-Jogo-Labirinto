using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Item item;
    Transform parentToReturn;
    GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturn = transform.parent;
        transform.SetParent(canvas.transform);
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

    public void ChangeParent(Transform newParent)
    {
        parentToReturn = newParent;
    }

    public Transform GetParentToReturn()
    {
        return parentToReturn;
    }

    public void Inicializado(Item item)
    {
        this.item = item;
        gameObject.GetComponent<Image>().sprite = item.sprite;
    }
}
