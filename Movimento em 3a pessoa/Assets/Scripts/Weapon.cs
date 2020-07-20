using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private bool hit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (!hit)
            {
                Debug.Log("Acertou o inimigo");
                StartCoroutine("Atacando");
            }
                
        }
    }

    IEnumerator Atacando()
    {
        hit = true;
        yield return new WaitForSeconds(.71f);
        hit = false;
    }

}
