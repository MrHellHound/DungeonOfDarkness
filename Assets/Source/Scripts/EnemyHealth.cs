using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthMax;
    [SerializeField] private int randomAmount;
    [SerializeField] private int currentHealth;
    
    [SerializeField] Slider healthBar;
    [SerializeField] int damage = 50;

    private EnemyCounter _enemyCounter;

    [SerializeField] private GameObject lightModel;
    [SerializeField] private GameObject heavyModel;
    
    [SerializeField] private GameObject locationModel;

    private void Awake()
    {
        locationModel.SetActive(false);
        
        _enemyCounter = GameObject.FindWithTag("GameLogic").GetComponent<EnemyCounter>();
        
        randomAmount = Random.Range(1, 3);
        
        if (randomAmount == 1)
        {
            healthMax = 100;
            lightModel.SetActive(true);
        }
        else if (randomAmount == 2)
        {
            healthMax = 200;
            heavyModel.SetActive(true);
        }
        
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
