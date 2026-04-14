using UnityEngine;

public class SpawningItems: MonoBehaviour
{
    public GameObject foods;

    void Start()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        // Create an array of food prefabs
        GameObject[] Food = { foods };

        // Choose a random index
        int randomIndex = Random.Range(0, Food.Length);

        // Instantiate the selected food
        Instantiate(Food[randomIndex], transform.position, transform.rotation);
    }
}