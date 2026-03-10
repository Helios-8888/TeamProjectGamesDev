using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public EntityHealth OriginalEntity;
    public float Speed = 20f;
    public float lifeTime = 2f;
    

    public void ShootBullet(Vector3 direction, EntityHealth entity)
    {
        rb = GetComponent<Rigidbody>();
        OriginalEntity = entity;
        rb.AddForce(direction.normalized * Speed, ForceMode.Impulse);  
        Destroy(this.gameObject, lifeTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Destroy bullet on impact
        if (collision.gameObject.TryGetComponent<EntityHealth>(out EntityHealth hp))
        {

            if (hp.EntityTeam != OriginalEntity.EntityTeam)
            {
                hp.DamageHP(15);
                Debug.Log(hp.name + hp.HP);
                if (hp.HP < 0)
                {
                    if (hp.EntityTeam == EntityHealth.Team.Enemy)
                    {
                        if (OriginalEntity.TryGetComponent<PlayerData>(out PlayerData playerData)) 
                        {
                            playerData.Pennies += 100;
                        }
                    }
                }

            }
        }
        Destroy(this.gameObject);
        
    }
}
