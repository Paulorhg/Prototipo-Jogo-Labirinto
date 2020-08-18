using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Item weaponEquipped;
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(weaponEquipped == null)
                other.GetComponent<Enemy>().Hitted(damage);
            else
                other.GetComponent<Enemy>().Hitted(weaponEquipped.value);

        }
    }
}
