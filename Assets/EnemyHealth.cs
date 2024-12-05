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

        if (other.CompareTag("Bullet"))
        {
            currentHealth -= damage;
            Convert.ToInt32(healthBar.value);
            
            healthBar.value = currentHealth;
            
            Debug.Log(healthBar.value);
            
            

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
