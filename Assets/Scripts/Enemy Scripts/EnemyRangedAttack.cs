using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;
    public float fireCooldown = 1.2f; // how long the enemy waits between each shot
    public float projectileSpeed = 12f;
    public float shootRange; // maximum distance the enemy can shoot the player

    Transform player;
    float nextTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerObj = GameObject.FindWithTag("Player");
        if (playerObj) player = playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player || !firePoint || !Bullet) return;

        float d = Vector3.Distance(transform.position, player.position); // calculate the distance between the enemy and the player
        if (d < shootRange) return;

        if (Time.time >= nextTime) // checks if the cooldown has finished so the enemy can shoot again
        {
            nextTime = Time.time + fireCooldown;

            Vector3 dir = (player.position - firePoint.position).normalized;
            var proj = Instantiate(Bullet, firePoint.position, Quaternion.LookRotation(dir)); // spawn the bullet and rotate towards the player

            var rb = proj.GetComponent<Rigidbody>();
            if (rb) rb.linearVelocity = dir * projectileSpeed; // apply velocity to the rigid body so the bullet moves forward.
        }
        
    }
}
