using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    //private set means only can change this value from this class, but get; means can look at its value elsewhere
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //for testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        //hover over int.MaxValue to see that it is the highest value an int can take
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(name + " takes" + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Meant to be overwritten
        Debug.Log(name + " died");
    }
}