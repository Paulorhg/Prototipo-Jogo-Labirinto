using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public int amount = 0;
    public Item item;

    Transform parentToReturn;
    GameObject canvas;

    GameObject destroyMenu;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        destroyMenu = GameObject.FindGameObjectWithTag("DestroyMenu");
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
        Debug.Log(eventData.pointerEnter.name);
        if (eventData.pointerEnter.CompareTag("Inventory"))
        {
            destroyMenu.GetComponent<DestroyItemMenu>().itemIcon = this;
            destroyMenu.transform.GetChild(0).gameObject.SetActive(true);
        }
        
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
        this.item = gameObject.AddComponent<Item>();
        gameObject.GetComponent<Item>().enabled = false;
        this.item.id = item.id;
        this.item.type = item.type;
        this.item.value = item.value;
        this.item.prefab = item.prefab;
        this.item.sprite = item.sprite;
        this.item.pickedUp = true;


        if (item.type.Equals("Potion"))
            this.item.typePotion = item.typePotion;
        gameObject.GetComponent<Image>().sprite = item.sprite;

        if (item.type.Equals("Potion"))
        {
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


    public void JuntarPotion(int amountNewPotion)
    {
        if (amountNewPotion < 0)
            amountNewPotion = 0;
        amount += amountNewPotion;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + amount;
    }
}
