using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI; // Dit is nodig om Image te gebruiken
using UnityEngine.AI;


public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarFill;

    void UpdateHealthBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Death()
    {
        NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.enabled = false;
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
}

