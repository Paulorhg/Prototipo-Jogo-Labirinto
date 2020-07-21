using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator _anim;
    GameObject shield;
    GameObject weapon;
    [SerializeField]
    HealthBar health;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        shield = GameObject.FindGameObjectWithTag("Shield");
        weapon = GameObject.FindGameObjectWithTag("Weapon");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !_anim.GetBool("attack")){

            StartCoroutine("Attack");
            
        }

        if (Input.GetMouseButton(1))
        {

            _anim.SetBool("defend", true);
            shield.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            _anim.SetBool("defend", false);
            shield.GetComponent<BoxCollider>().enabled = false;
        }
            

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("inimigo bateu");
            health.SetHealth(20);

            if(health.GetHealth() <= 0)
            {
                _anim.SetBool("dead", true);
            }
        }
    }


    IEnumerator Attack()
    {
        if (_anim.GetBool("walk"))
            _anim.SetBool("walk", false);

        _anim.SetBool("attack", true);
        weapon.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(.71f);

        _anim.SetBool("attack", false);
        weapon.GetComponent<BoxCollider>().enabled = false;
    }


}
