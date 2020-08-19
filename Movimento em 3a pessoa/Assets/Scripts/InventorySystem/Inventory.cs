using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;
    private bool inventoryEnable;
    [SerializeField]
    private GameObject character;
    private bool characterEnable;


    private GameObject[] slots;
    private int allSlots;

    [SerializeField]
    private GameObject slotHolder;

    [SerializeField]
    private GameObject itemIconPrefab;

    // Start is called before the first frame update
    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slots = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnable = !inventoryEnable;

            if (inventoryEnable == true)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            characterEnable = !characterEnable;

            if (characterEnable == true)
            {
                character.SetActive(true);
            }
            else
            {
                character.SetActive(false);
            }
        }

    }


    public void PegarItem(Item item)
    {

        if (item.type.Equals("Potion"))
        {
            for (int i = 0; i < allSlots; i++)
            {

                if (slots[i].transform.childCount == 0)
                {
                    GameObject itemIcon = Instantiate(itemIconPrefab, slots[i].transform);
                    itemIcon.GetComponent<ItemIcon>().Inicializado(item);
                    Destroy(item.gameObject);
                    break;
                }

                if (slots[i].transform.GetChild(0).GetComponent<ItemIcon>().potionType == item.typePotion)
                {
                    slots[i].transform.GetChild(0).GetComponent<ItemIcon>().JuntarPotion(1);
                    Destroy(item.gameObject);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < allSlots; i++)
            {
                if (slots[i].transform.childCount == 0)
                {
                    //if (item.type.Equals("Weapon"))
                    //{
                    //    Transform weaponArm = GameObject.FindGameObjectWithTag("Weapon").transform;
                    //    for(int j = 0; j < weaponArm.childCount; j++)
                    //    {
                    //        if(weaponArm.GetChild(j).GetComponent<Item>().id == item.id)
                    //        {
                    //            item.pickedUp = true;
                    //            item.transform.SetParent(weaponArm);
                    //            item.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    //            item.gameObject.transform.rotation = item.prefab.transform.rotation;
                    //        }
                    //    }

                    //}
                    //else if(item.type.Equals("Shield"))
                    //{
                    //    Transform shieldArm = GameObject.FindGameObjectWithTag("Shield").transform;
                    //    item.pickedUp = true;
                    //    item.transform.SetParent(shieldArm);
                    //    item.transform.localPosition = new Vector3(0, 0, 0);
                    //    item.transform.rotation = item.prefab.transform.rotation;
                    //}
                    //else if (item.type.Equals("Armor"))
                    //{
                    //    Transform chest = GameObject.FindGameObjectWithTag("Chest").transform;
                    //    item.pickedUp = true;
                    //    item.transform.SetParent(chest);
                    //    item.transform.localPosition = new Vector3(0, 0, 0);
                    //    item.transform.rotation = item.prefab.transform.rotation;
                    //}

                    GameObject itemIcon = Instantiate(itemIconPrefab, slots[i].transform);
                    itemIcon.GetComponent<ItemIcon>().Inicializado(item);
                    Destroy(item.gameObject);
                    break;

                }
            }

        }
    }
}
