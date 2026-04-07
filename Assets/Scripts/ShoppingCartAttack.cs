using UnityEngine;

public class ShoppingCartAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (EntityHealth.health > 0)
            {
                EntityHealth.health -= 20;
            }
        }
    }
}
