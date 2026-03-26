<<<<<<< Updated upstream
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Melee;
    public GameObject Tank;
    public GameObject Ranged;

    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Create an array of enemy prefabs
        GameObject[] enemies = { Melee, Tank, Ranged };

        // Choose a random index
        int randomIndex = Random.Range(0, enemies.Length);

        // Instantiate the selected enemy
        Instantiate(enemies[randomIndex], transform.position, transform.rotation);
    }
=======
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Melee;
    public GameObject Tank;
    public GameObject Ranged;

    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Create an array of enemy prefabs
        GameObject[] enemies = { Melee, Tank, Ranged };

        // Choose a random index
        int randomIndex = Random.Range(0, enemies.Length);

        // Instantiate the selected enemy
        Instantiate(enemies[randomIndex], transform.position, transform.rotation);
    }
>>>>>>> Stashed changes
}