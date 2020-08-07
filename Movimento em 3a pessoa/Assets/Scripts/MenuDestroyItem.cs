using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDestroyItem : MonoBehaviour
{

    public ItemIcon itemIcon;
    public ItensManager itensManager;
    

    public void ButtonSim()
    {
        if (itemIcon.GetParentToReturn().GetComponent<Slot>().type.Equals("Weapon"))
        {
            itensManager.ChangeWeapon(404);
        }
        if (itemIcon.GetParentToReturn().GetComponent<Slot>().type.Equals("Shield"))
        {
            itensManager.ChangeShield(404);
        }
        if (itemIcon.GetParentToReturn().GetComponent<Slot>().type.Equals("Armor"))
        {
            itensManager.ChangeArmor(404);
        }
        Destroy(itemIcon.gameObject);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ButtonNao()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
