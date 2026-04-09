using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public Bullet Bullet;
    private EntityHealth health;
    public float fireCooldown = 1.2f; // how long the enemy waits between each shot
    public float projectileSpeed = 12f;
    public float shootRange; // maximum distance the enemy can shoot the player
    public Animator EnemyAnimator;

    Transform player;
    float nextTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerObj = GameObject.FindWithTag("Player");
        if (playerObj) player = playerObj.transform;
        health = GetComponent<EntityHealth>();
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
            Bullet proj = Instantiate(Bullet, firePoint.position, Quaternion.LookRotation(dir)); // spawn the bullet and rotate towards the player
            proj.ShootBullet(dir, health);
            //Send a message to the animator
            EnemyAnimator.SetTrigger("Shoot");
        }
        
    }
}
