using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private float damage;


    //public void ChangeWeapon(string name)
    //{
        
    //}

    public float GetDamage()
    {
        return damage;
    }
}
