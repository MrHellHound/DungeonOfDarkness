using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeBetweenShots = 1f;
    public float bulletSpeed = 10f;
    
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    
    public PlayerMovement playerMovement;
    public PlayerRotation playerRotation;
    
    private bool _isReadyToShoot = true;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _isReadyToShoot)
        { 
            StartCoroutine(ShootCooldown());
            
            Vector3 diff = playerRotation.mousePos - playerMovement.transform.position;
            
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
           
            bullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        }
    }

    private IEnumerator ShootCooldown()
    {
        _isReadyToShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        _isReadyToShoot = true;
    }
}
