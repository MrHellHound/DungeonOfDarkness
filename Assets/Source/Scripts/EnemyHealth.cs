using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    
    [SerializeField] int healthMax = 100;
    [SerializeField] int currentHealth;
    
    [SerializeField] int damage = 50;

    private EnemyCounter _enemyCounter;

    private void Awake()
    {
        _enemyCounter = GameObject.FindWithTag("GameLogic").GetComponent<EnemyCounter>();
        
        currentHealth = healthMax;
        
        healthBar.maxValue = healthMax;
        healthBar.value = currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerMelee"))
        {
            _enemyCounter.UpdateUI();
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
                _enemyCounter.UpdateUI();
                Destroy(gameObject);
            }
        }
    }
}
