using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    public int healAmount = 20;

    public GameObject pickupEffect; //Attach some sort of vfx to this
    private PlayerHealthbar MaxHP;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<EntityHealth>(out EntityHealth playerHealth))
            {
                Pickup(other);
            }
        }

        void Pickup(Collider player)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);

            PlayerData data = player.GetComponent<PlayerData>();
            data.PlayerHealth.HealHP(Mathf.RoundToInt(healAmount));

            Destroy(gameObject);
        }
    }
}
