using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 20f;
    public float lifeTime = 2f;
    

    public void ShootBullet(Vector3 direction)
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * speed, ForceMode.Impulse);  
        Destroy(this.gameObject, lifeTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Destroy bullet on impact
        if (collision.gameObject.TryGetComponent<EntityHealth>(out EntityHealth hp))
        {
            hp.DamageHP(15);
        }
        Destroy(this.gameObject);
        
    }
}
