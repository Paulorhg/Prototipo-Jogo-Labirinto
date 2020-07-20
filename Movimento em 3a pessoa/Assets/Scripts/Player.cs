using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator anim;
    GameObject shield;
    GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        shield = GameObject.FindGameObjectWithTag("Shield");
        weapon = GameObject.FindGameObjectWithTag("Weapon");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !anim.GetBool("attack")){

            StartCoroutine("Attack");
            
        }

        if (Input.GetMouseButton(1))
        {

            anim.SetBool("defend", true);
            shield.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            anim.SetBool("defend", false);
            shield.GetComponent<BoxCollider>().enabled = false;
        }
            

    }


    IEnumerator Attack()
    {
        if (anim.GetBool("walk"))
            anim.SetBool("walk", false);

        anim.SetBool("attack", true);
        weapon.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(.8f);

        anim.SetBool("attack", false);
        weapon.GetComponent<BoxCollider>().enabled = false;
    }


}
