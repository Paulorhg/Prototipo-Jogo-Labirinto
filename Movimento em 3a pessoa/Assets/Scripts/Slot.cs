using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

    [SerializeField]
    private string type;
    public GameObject Item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }

            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        ItemIcon itemIcon = eventData.pointerDrag.GetComponent<ItemIcon>();

        if (type.Equals("Slot"))
        {
            if(Item == null)
            {
                itemIcon.ChangeParent(transform);
            }
            else
            {
                Transform otherParent = itemIcon.GetParentToReturn();
                Item.transform.parent = otherParent;
                itemIcon.ChangeParent(transform);
            }
        }
        if (type.Equals("Weapon"))
        {
            if (itemIcon.item.type.Equals("Weapon"))
            {
                if (Item == null)
                {
                    itemIcon.ChangeParent(transform);
                }
                else
                {
                    Transform otherParent = itemIcon.GetParentToReturn();
                    Item.transform.parent = otherParent;
                    itemIcon.ChangeParent(transform);
                }
            }
        }
        if (type.Equals("Armor"))
        {
            if (itemIcon.item.type.Equals("Armor"))
            {
                if (Item == null)
                {
                    itemIcon.ChangeParent(transform);
                }
                else
                {
                    Transform otherParent = itemIcon.GetParentToReturn();
                    Item.transform.parent = otherParent;
                    itemIcon.ChangeParent(transform);
                }
            }
        }
        if (type.Equals("Shield"))
        {
            if (itemIcon.item.type.Equals("Shield"))
            {
                if (Item == null)
                {
                    itemIcon.ChangeParent(transform);
                }
                else
                {
                    Transform otherParent = itemIcon.GetParentToReturn();
                    Item.transform.parent = otherParent;
                    itemIcon.ChangeParent(transform);
                }
            }
        }
    }

}
