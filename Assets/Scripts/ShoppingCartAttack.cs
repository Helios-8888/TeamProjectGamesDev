using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShoppingCartAttack : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            if enemyHealth.health > 0;
            {
                enemyHealth.health -= 20;
            }
        }
    }
}
