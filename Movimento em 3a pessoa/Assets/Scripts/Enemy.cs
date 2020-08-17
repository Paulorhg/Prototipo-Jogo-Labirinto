using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _damage;
    [SerializeField]
    private HealthBar healthBar;
    private bool _hitted;
    private bool _hit;
    private bool inRange;
    private Player player;
    EnemyRespawn enemyRespawn;
    float distancia = 500;
    public float maxChaseDistance = 15;
    public float minChaseDistance = 0.5f;
    NavMeshAgent agent;
    Animator anim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyRespawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<EnemyRespawn>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if(distancia <= maxChaseDistance && distancia >= minChaseDistance && !_hit && !anim.GetBool("getHit") && !anim.GetBool("dead"))
        {
            agent.SetDestination(player.transform.position);
            anim.SetBool("walk", true);
        }
        else if(distancia <= minChaseDistance)
        {
            agent.SetDestination(transform.position);
            anim.SetBool("walk", false);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        //if(distancia <= 2)
        //{
        //    StartCoroutine("Attack");
        //}
    }

    public float GetDamage()
    {
        return _damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !anim.GetBool("getHit") && !_hit)
        {
            inRange = true;
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    public void Hitted(float damage)
    {
        if (!_hitted)
        {
            healthBar.TakeDamage(damage);
            if (healthBar.GetHealth() <= 0)
            {
                enemyRespawn.RespawnEnemy();
                Debug.Log("morreu");
                anim.SetBool("dead", true);
                GetComponent<CapsuleCollider>().enabled = false;
                Destroy(gameObject, 3.5f);
            }
            StartCoroutine("SingleHit");
        }
    }

    IEnumerator SingleHit()
    {
        if (anim.GetBool("walk"))
            anim.SetBool("walk", false);
        _hitted = true;
        anim.SetBool("getHit", true);
        yield return new WaitForSeconds(.71f);
        anim.SetBool("getHit", false);
        _hitted = false;
    }

    IEnumerator Attack()
    {
        while (inRange && healthBar.health > 0)
        {
            if (anim.GetBool("walk"))
                anim.SetBool("walk", false);
            _hit = true;
            anim.SetBool("attack", true);
            yield return new WaitForSeconds(.25f);
            player.Hitted(_damage);
            anim.SetBool("attack", false);
            yield return new WaitForSeconds(.65f);
            _hit = false;
        }
    }
}
