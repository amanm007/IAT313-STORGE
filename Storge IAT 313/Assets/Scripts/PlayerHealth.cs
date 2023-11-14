using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.SetHealth(health);
        if (health<=0)
        {
            Die();

        }
    }
    private void Die()
    {
        // Handle death (play animation, trigger game over, etc.)
        Destroy(gameObject);
    }
}
