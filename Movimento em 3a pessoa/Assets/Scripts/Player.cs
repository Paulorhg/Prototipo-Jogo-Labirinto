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

    public float armor;


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

        if (Input.GetMouseButtonDown(0) && !_anim.GetBool("attack") && !_anim.GetBool("defend") && !_anim.GetBool("gethit"))
        {

            StartCoroutine("Attack");
            
        }

        if (Input.GetMouseButton(1) && !_anim.GetBool("attack") && !_anim.GetBool("gethit"))
        {

            _anim.SetBool("defend", true);
            shield.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            _anim.SetBool("defend", false);
            shield.GetComponent<BoxCollider>().enabled = false;
            shield.GetComponent<Shield>().DefenseDone();
        }
            

    }


    public void Hitted(float damage)
    {
        Shield shieldScr = shield.GetComponent<Shield>();
        if (shieldScr.GetDefended())
        {
            shieldScr.DefenseDone();
            Debug.Log("Defendido");
        }
        else
        {
            Debug.Log("inimigo bateu");
            float damageTaken = damage - armor;
            if (damageTaken < 0)
            {
                health.TakeDamage(5);
                GetComponent<ThirdPersonMovement>().Hitted();
            }
            else
            {
                health.TakeDamage(damageTaken);
                GetComponent<ThirdPersonMovement>().Hitted();
            }

            if (health.GetHealth() <= 0)
            {
                _anim.SetBool("dead", true);
            }
            else
                StartCoroutine("GetHit");
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

    IEnumerator GetHit()
    {
        if (_anim.GetBool("walk"))
            _anim.SetBool("walk", false);

        _anim.SetBool("gethit", true);
        yield return new WaitForSeconds(.85f);
        _anim.SetBool("gethit", false);
    }

}
