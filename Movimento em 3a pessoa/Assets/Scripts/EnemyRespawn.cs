using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    public void RespawnEnemy()
    {
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
