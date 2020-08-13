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
        Debug.Log(distancia);
        if(distancia <= maxChaseDistance && distancia >= minChaseDistance && !anim.GetBool("attack") && !anim.GetBool("getHit") && !anim.GetBool("dead"))
        {
            agent.SetDestination(player.transform.position);
            anim.SetBool("walk", true);
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
            StartCoroutine("Attack");
            player.Hitted(_damage);
        }
    }

    public void Hitted(float damage)
    {
        if (!_hitted)
        {
            healthBar.TakeDamage(damage);
            StartCoroutine("SingleHit");
            if (healthBar.GetHealth() <= 0)
            {
                enemyRespawn.RespawnEnemy();
                Debug.Log("morreu");
                anim.SetBool("dead", true);
                GetComponent<CapsuleCollider>().enabled = false;
                Destroy(gameObject, 3.5f);
            }
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
        if (anim.GetBool("walk"))
            anim.SetBool("walk", false);
        _hit = true;
        anim.SetBool("attack", true);
        yield return new WaitForSeconds(.90f);
        _hit = false;
        anim.SetBool("attack", false);
    }

}
