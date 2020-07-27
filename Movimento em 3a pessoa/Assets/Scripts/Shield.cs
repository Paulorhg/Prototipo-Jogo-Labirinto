using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool defended;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            defended = true;
        }
    }

    public bool GetDefended()
    {
        return defended;
    }

    public void DefenseDone()
    {
        defended = false;
    }
}
