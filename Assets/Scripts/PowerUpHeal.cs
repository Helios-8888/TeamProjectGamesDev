using System;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    public int healAmount = (int)20f;

    public GameObject pickupEffect;

    public GameObject pickupHeal;
    private PlayerHealthbar MaxHP;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent<PlayerHealthbar>(out PlayerHealthbar playerHealth))
            {
                Pickup(other);
            }
        }

        // Fixed: compare the instance field `MaxHP` (not the type) and remove the stray semicolon.
        // If MaxHP is null, mark this pickup to persist across scene loads.
        if (MaxHP != null)
        {
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
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
