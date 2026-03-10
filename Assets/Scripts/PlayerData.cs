using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealthbar PlayerHealthbar; //Need a way to assign this though code.
    public EntityHealth PlayerHealth;
    //public List<string> inventory = new List<string>(); //Replace this with the item class when items are made
    public Inventory PlayerInventory; //Try use this from now on
    public int Pennies=0;
    public int MaxPennies = 999;
    public Store currentStore;

    public void SetupPlayerData()
    {
        PlayerHealth = GetComponent<EntityHealth>();
        PlayerHealthbar.SetMaxHealth(PlayerHealth.MaxHP);
        PlayerInventory = GetComponent<Inventory>();
        PlayerInventory.GenerateShoppingList(currentStore);
        Pennies = 0;
    }
}
