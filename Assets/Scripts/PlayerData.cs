using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealthbar PlayerHealthbar;
    public EntityHealth PlayerHealth;
    public List<string> inventory = new List<string>(); //Replace this with the item class when items are made

    void Start()
    {
        PlayerHealth = GetComponent<EntityHealth>();
        PlayerHealthbar.SetMaxHealth(PlayerHealth.MaxHP);
    }
}
