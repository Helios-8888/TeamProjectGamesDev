using UnityEngine;

public class PoweUpDamage : MonoBehaviour
{
     public float DamageIncrease = 15f;

    public GameObject pickupEffect;

    public GameObject pickupDamage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent<DamageHP>(out PlayerAttack playerAttack))
            {
                Pickup(other);
            }
        }

        void Pickup(Collider player)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);

            PlayerData data = player.GetComponent<PlayerData>();
            data.PlayerAttack.DamageHP(Mathf.RoundToInt(DamageIncrease));

            Destroy(gameObject);
        }
    }
}
