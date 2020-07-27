using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private float damage;


    public float GetDamage()
    {
        return damage;
    }
}
