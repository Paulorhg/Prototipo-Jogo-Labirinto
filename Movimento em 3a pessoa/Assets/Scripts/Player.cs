using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)){

            StartCoroutine("Attack");
            
        }

        if (Input.GetMouseButton(1))
        {

            anim.SetBool("defend", true);

        }
        else
            anim.SetBool("defend", false);

    }


    IEnumerator Attack()
    {
        if (anim.GetBool("walk"))
            anim.SetBool("walk", false);
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(.7f);
        anim.SetBool("attack", false);
    }


}
