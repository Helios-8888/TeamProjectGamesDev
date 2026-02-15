using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;

    void Start()
    {
        // Destroy bullet after a set time
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy bullet on impact
        Destroy(gameObject);
    }
}
