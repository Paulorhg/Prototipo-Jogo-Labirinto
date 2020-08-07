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


    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / maxHealth;
    }

    public void RestoreHealth(float restore)
    {
        health += restore;

        if (health > maxHealth)
            health = maxHealth;

        healthBar.fillAmount = health / maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }
}
