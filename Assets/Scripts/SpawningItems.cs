using UnityEditor;
using UnityEngine;

public class SpawningItems: MonoBehaviour
{
    public GameObject[] Food;

    void Start()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        // Create an array of food prefabs

        // Choose a random index
        int randomIndex = Random.Range(0, Food.Length);

        // Instantiate the selected food
        Instantiate(Food[randomIndex], transform.position, transform.rotation);
    }
}