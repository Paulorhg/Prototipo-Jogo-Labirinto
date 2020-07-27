using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public float maxHealth;
    public float health;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;

            healthBar.fillAmount = health / maxHealth;
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
