using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensManager : MonoBehaviour
{

    [SerializeField]
    Item[] weapons = new Item[5];
    [SerializeField]
    Item[] shields = new Item[5];
    [SerializeField]
    Item[] potions = new Item[5];

    GameObject weaponArm;
    GameObject shieldArm;



    // Start is called before the first frame update
    void Start()
    {
        weaponArm = GameObject.FindGameObjectWithTag("Weapon");
        shieldArm = GameObject.FindGameObjectWithTag("Shield");

        if (weaponArm.transform.childCount == 0)
        {
            Instantiate(weapons[0].gameObject, weaponArm.transform);
        }
        if (shieldArm.transform.childCount == 0)
        {
            Instantiate(shields[0].gameObject, shieldArm.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(1);
        }
    }


    void ChangeWeapon(int newId)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i].id == newId)
            {
                Destroy(weaponArm.transform.GetChild(0).gameObject);
                Instantiate(weapons[i].gameObject, weaponArm.transform);
                return;
            }
        }
    }
}
