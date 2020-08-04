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

        for(int i = 0; i < allSlots; i++)
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

        if(inventoryEnable == true || characterEnable == true)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }


    public void PegarItem(Item item)
    {
        for(int i = 0; i < allSlots; i++)
        {
            if(slots[i].gameObject.GetComponent<Slot>().Item == null)
            {
                item.gameObject.SetActive(false);
                GameObject itemIcon = Instantiate(itemIconPrefab, slots[i].gameObject.transform);
                itemIcon.GetComponent<ItemIcon>().Inicializado(item);
                break;
            }
        }
    }
}
