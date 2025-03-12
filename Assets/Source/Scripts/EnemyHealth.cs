using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthMax;
    [SerializeField] private int randomAmount;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject enemyColor;
    
    [SerializeField] Slider healthBar;
    [SerializeField] int damage = 50;

    private EnemyCounter _enemyCounter;

    readonly Color _red = new Color(255f, 0f, 0f, 255f);
    readonly Color _orange = new Color(255f, 147f, 0f, 255f);

    private void Awake()
    {
        _enemyCounter = GameObject.FindWithTag("GameLogic").GetComponent<EnemyCounter>();
        
        randomAmount = Random.Range(1, 3);
        
        if (randomAmount == 1)
        {
            healthMax = 100;
            enemyColor.GetComponent<SpriteRenderer>().color = _red;
        }
        else if (randomAmount == 2)
        {
            healthMax = 200;
            enemyColor.GetComponent<SpriteRenderer>().color = _orange;
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
