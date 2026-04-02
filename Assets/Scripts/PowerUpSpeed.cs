using UnityEngine;
using UnityEngine.TextCore.Text;

public class PowerUpSpeed : MonoBehaviour
{
    public float speedIncrease = 2f;
    public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            if(other.TryGetComponent<PlayerController>(out PlayerController player))
            {
                Pickup(player);
            }
        }
    }
    void Pickup(PlayerController player) 
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        player.CurrentSpeed *= speedIncrease;
        Destroy(gameObject);
    }
}

     

