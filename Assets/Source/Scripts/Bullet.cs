using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy")) Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
}
