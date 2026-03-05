using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealthbar PlayerHealthbar;
    public EntityHealth PlayerHealth;
    public List<string> inventory = new List<string>(); //Replace this with the item class when items are made
    public Inventory PlayerInventory;
    public int Pennies=0;
    public int MaxPennies = 999;
    public Store currentStore;

    void Start()
    {
        PlayerHealth = GetComponent<EntityHealth>();
        PlayerHealthbar.SetMaxHealth(PlayerHealth.MaxHP);
        PlayerInventory = GetComponent<Inventory>();
        PlayerInventory.GenerateShoppingList(currentStore);
        Pennies = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if collides with the door of the store
            //get the storetype of the store
            //set currentStore to store.storeType
    }
}
