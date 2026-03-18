using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    public float healAmount = 20f;

    public GameObject pickupEffect;

    public GameObject pickupHeal;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent<PlayerHealthbar>(out PlayerHealthbar playerHealth))
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
