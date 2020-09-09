using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

    public string type;

    private ItensManager ItensManager;
    public GameObject Item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    private void Start()
    {
        ItensManager = GameObject.FindGameObjectWithTag("ItensManager").GetComponent<ItensManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {

        ItemIcon itemIcon = eventData.pointerDrag.GetComponent<ItemIcon>();

        if (type.Equals("Slot"))
        {
            string typeSlotAnterior = itemIcon.GetParentToReturn().gameObject.GetComponent<Slot>().type;

            //se colocar em um slot do inventario vazio
            if (Item == null)
            {
                //se tirar o item de algum slot do character
                if (typeSlotAnterior.Equals("Weapon"))
                {
                    ItensManager.ChangeWeapon(404);
                }
                else if (typeSlotAnterior.Equals("Shield"))
                {
                    ItensManager.ChangeShield(404);
                }
                else if (typeSlotAnterior.Equals("Armor"))
                {
                    return;
                }

                itemIcon.ChangeParent(transform);
            }

            //se colocar em um slot do inventario com outro item
            else
            {
                ItemIcon itemNoSlot = transform.GetChild(0).GetComponent<ItemIcon>();

                if (itemIcon.item.type.Equals("Potion") && itemNoSlot.item.type.Equals("Potion"))
                {
                    if (itemIcon.item.typePotion.Equals(itemNoSlot.item.typePotion))
                    {
                        itemNoSlot.JuntarPotion(itemIcon.amount);
                        Destroy(itemIcon.gameObject);
                        return;
                    }
                }

                else if (typeSlotAnterior.Equals("Potion") && itemNoSlot.item.type != "Potion")
                    return;

                //se tirar o item de algum slot do character
                else if (typeSlotAnterior.Equals("Weapon"))
                {
                    if (itemNoSlot.item.type.Equals("Weapon"))
                        ItensManager.ChangeWeapon(itemNoSlot.item.id);
                    else
                        return;
                }
                else if (typeSlotAnterior.Equals("Shield"))
                {
                    if (itemNoSlot.item.type.Equals("Shield"))
                        ItensManager.ChangeShield(itemNoSlot.item.id);
                    else
                        return;
                }
                else if (typeSlotAnterior.Equals("Armor"))
                {
                    if (itemNoSlot.item.type.Equals("Armor"))
                        ItensManager.ChangeArmor(itemNoSlot.item.id);
                    else
                        return;
                }


                Transform otherParent = itemIcon.GetParentToReturn();
                Item.transform.parent = otherParent;
                itemIcon.ChangeParent(transform);
            }
        }

        /////////////////////////////////////////////////////////////////////////////

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
                ItensManager.ChangeWeapon(itemIcon.item.id);
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        
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
                ItensManager.ChangeArmor(itemIcon.item.id);
            }
        }

        /////////////////////////////////////////////////////////////////////

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
                ItensManager.ChangeShield(itemIcon.item.id);
            }
        }

        /////////////////////////////////////////////////////////////////////

        if (type.Equals("Potion"))
        {
            if (itemIcon.item.type.Equals("Potion"))
            {
                if (Item == null)
                {
                    itemIcon.ChangeParent(transform);
                }
                else
                {
                    ItemIcon itemNoSlot = transform.GetChild(0).GetComponent<ItemIcon>();

                    if (itemIcon.item.typePotion.Equals(itemNoSlot.item.typePotion))
                    {
                        itemNoSlot.JuntarPotion(itemIcon.amount);
                        Destroy(itemIcon.gameObject);
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
}
