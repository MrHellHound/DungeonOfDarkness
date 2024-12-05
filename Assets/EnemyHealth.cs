using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthBar;
    
    public int healthMax = 100;
    public int currentHealth;
    
    public int damage = 50;

    private void Awake()
    {
        currentHealth = healthMax;
        
        healthBar.maxValue = healthMax;
        healthBar.value = currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerMelee"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= damage;
            Convert.ToInt32(healthBar.value);
            
            healthBar.value = currentHealth;
            
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
