using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died.");
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
    }

    public void Heal(int healing)
    {
        int lostHealth = maxHealth - currentHealth;
        if (lostHealth < healing)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healing;
        }
    }
}
