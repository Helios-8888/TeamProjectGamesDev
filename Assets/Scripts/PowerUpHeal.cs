using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    public int healAmount = 20;

    public GameObject pickupEffect; //Attach some sort of vfx to this
    private PlayerHealthbar MaxHP;
    //public GameObject pickupHeal; unused variable

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //This doesn't seem right
            /*
            if (MaxHP != null)
            {
                DontDestroyOnLoad(MaxHP.gameObject);
            }
            */

            if (other.TryGetComponent<EntityHealth>(out EntityHealth playerHealth))
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
