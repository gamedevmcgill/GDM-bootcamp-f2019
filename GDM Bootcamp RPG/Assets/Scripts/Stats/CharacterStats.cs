using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Stat damage;
    public Stat armor;


    private void Awake()
    {
        SetCurrentHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {

        int a = armor.GetValue();

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten.
        Debug.Log("Dead!");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void SetCurrentHealth(int health)
    {
        this.currentHealth = health;
    }
}
