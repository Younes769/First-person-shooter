using UnityEngine;

public class RevolverGun : MonoBehaviour
{
    public Transform firePoint; // The point from which bullets will be fired
    public GameObject bulletPrefab; // Prefab of the bullet GameObject
    public float bulletSpeed = 30f; // Speed of the bullet when fired
    public float fireRate = 1f; // Rate of fire (bullets per second)

    private float nextTimeToFire = 0f; // Time when the gun can fire next

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate; // Update next fire time
            Shoot(); // Call the Shoot method
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (rb != null)
        {
            // Apply forward force to the bullet
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}
