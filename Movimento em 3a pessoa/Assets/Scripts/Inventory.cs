using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
