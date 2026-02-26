using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
public GameObject bulletPrefab;
public GameObject currentBullet;
public Transform bulletspawn;
public float bulletForce = 20f;
public float lifetime = 3f;

void Update()
{
if (Input.GetButtonDown("Fire1")) // Left mouse button
{
Shoot();
}
}

void Shoot()
{
    if (bulletPrefab != null)
    {
        GameObject currentBullet = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletspawn.forward * bulletForce, ForceMode.Impulse);
        Destroy(currentBullet, lifetime);
         if (TryGetComponent<EntityHealth>(out EntityHealth _HP))
                {
                    _HP.DamageHP(15);
                }
       
       
    }

}
private void OnCollisionEnter(Collision collision)
{
     
            // Destroy the bullet
         Destroy(currentBullet);
        
        
}
}