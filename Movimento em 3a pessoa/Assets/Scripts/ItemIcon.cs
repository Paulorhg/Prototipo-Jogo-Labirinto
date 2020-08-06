using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public int itemId;
    public string itemType;
    public int amount = 0;
    public string potionType;

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
        itemId = item.id;
        itemType = item.type;
        gameObject.GetComponent<Image>().sprite = item.sprite;

        if (item.type.Equals("Potion"))
        {
            potionType = item.typePotion;
            amount++;
            GameObject amountDisplay = transform.GetChild(0).gameObject;
            amountDisplay.GetComponent<Text>().text = "" + amount;
            amountDisplay.SetActive(true);
        }
    }

    public void PotionUsed()
    {
        amount--;

        if(amount == 0)
        {
            Destroy(this.gameObject);
        }

        transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + amount;

    }
}
