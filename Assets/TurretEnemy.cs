using System.Collections;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    [SerializeField] private float timeBetweenShots = 1f;
    [SerializeField] private float bulletSpeed = 10f;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    
    private bool _isReadyToShoot = true;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandleRotation();
            HandleShooting();
        }
    }

    private void HandleRotation()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    private void HandleShooting()
    {
        if (_isReadyToShoot)
        { 
            StartCoroutine(ShootCooldown());
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * (playerTransform.position - bulletSpawnPoint.position).normalized * bulletSpeed;
        }
    }

    private IEnumerator ShootCooldown()
    {
        _isReadyToShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        _isReadyToShoot = true;
    }
}
