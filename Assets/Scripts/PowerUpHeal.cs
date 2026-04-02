using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    public int healAmount = 20;

    public GameObject pickupEffect; //Attach some sort of vfx to this

    //public GameObject pickupHeal; unused variable

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent<EntityHealth>(out EntityHealth playerHealth))
            {
                Pickup(playerHealth);
            }
        }

    }

    void Pickup(EntityHealth player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        player.HealHP(healAmount);

        Destroy(gameObject);
    }
}
