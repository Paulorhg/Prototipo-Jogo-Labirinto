using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{

    private Transform slot1;
    private Transform slot2;
    public HealthBar health;

    private void Start()
    {
        slot1 = transform.GetChild(0).GetChild(0);
        slot2 = transform.GetChild(1).GetChild(0);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && health.health > 0)
        {
            if(slot1.childCount != 0)
            {
                ItemIcon potion = slot1.GetChild(0).GetComponent<ItemIcon>();
                
                if (potion.item.typePotion.Equals("Health"))
                {
                    health.RestoreHealth(potion.item.value);
                    potion.PotionUsed();
                }
                else
                {
                    //fazer para potion de mana
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.X) && health.health > 0)
        {
            if (slot2.childCount != 0)
            {
                ItemIcon potion = slot2.GetChild(0).GetComponent<ItemIcon>();
                potion.PotionUsed();
                if (potion.item.typePotion.Equals("Health"))
                {
                    health.RestoreHealth(potion.item.value);
                }
                else
                {
                    //fazer para potion de mana
                }
            }

        }
    }
}
