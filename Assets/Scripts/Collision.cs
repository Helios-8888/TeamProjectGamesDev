using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            print("ENTER");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("STAY");
        }
    }


     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("EXIT");
        }
    }
}
