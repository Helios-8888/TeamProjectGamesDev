using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public PlayerData Player;
    public float speed = 20f;
    public float lifeTime = 2f;
    

    public void ShootBullet(Vector3 direction, PlayerData player)
    {
        rb = GetComponent<Rigidbody>();
        Player = player;
        rb.AddForce(direction.normalized * speed, ForceMode.Impulse);  
        Destroy(this.gameObject, lifeTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Destroy bullet on impact
        if (collision.gameObject.TryGetComponent<EntityHealth>(out EntityHealth hp))
        {
            hp.DamageHP(15);
            Debug.Log(hp.name + hp.HP);
            if (hp.HP < 0)
            {
                if (hp.gameObject.CompareTag("Enemy"))
                {
                    Player.Pennies += 100;
                }
            }
        }
        Destroy(this.gameObject);
        
    }
}
