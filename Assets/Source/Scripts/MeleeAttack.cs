using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float meleeCooldown;
    public float animationTime;

    private bool _canAttack = true;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && _canAttack)
        {
            StartCoroutine(AttackCooldown());
            _spriteRenderer.enabled = true;
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        _spriteRenderer.enabled = true;
        
        yield return new WaitForSeconds(animationTime);

        _spriteRenderer.enabled = false;
        
        yield return new WaitForSeconds(meleeCooldown);
        _canAttack = true;
        _spriteRenderer.enabled = false;
    }
}
