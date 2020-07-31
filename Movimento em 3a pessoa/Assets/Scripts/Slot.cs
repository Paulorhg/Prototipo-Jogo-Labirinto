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
        if (type.Equals("Slot"))
        {
            if(Item == null)
            {
                eventData.pointerDrag.GetComponent<ItemIcon>().changeParent(transform);
            }
            else
            {

            }
        }
        if (eventData.pointerDrag.CompareTag("Slot"))
        {

        }
    }
}
