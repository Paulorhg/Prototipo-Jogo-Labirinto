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
    private bool _hit;
    private Player player;
    EnemyRespawn enemyRespawn;
    float distancia = 500;
    public float chaseDistance = 15;
    NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyRespawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<EnemyRespawn>();
        agent = GetComponent<NavMeshAgent>();


    }

    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);

        if(distancia <= chaseDistance)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if(!_hit)
            {
                healthBar.TakeDamage(player.GetDamage());
                StartCoroutine("SingleHit");
                if(healthBar.GetHealth() <= 0)
                {
                    enemyRespawn.RespawnEnemy();
                    Debug.Log("morreu");
                    Destroy(gameObject, 0.2f);
                }
            }
        }
    }

    public float GetDamage()
    {
        return _damage;
    }

    IEnumerator SingleHit()
    {
        _hit = true;
        yield return new WaitForSeconds(.71f);
        _hit = false;
    }
}
