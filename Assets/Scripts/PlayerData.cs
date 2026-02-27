using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealthbar PlayerHealthbar;
    public EntityHealth PlayerHealth;
    public Inventory PlayerInventory; //Replace this with the item class when items are made
    //Track what store the player's in
    public Store.StoreType currentStore;
    //Track the player inventory



    void Start()
    {
        PlayerHealth = GetComponent<EntityHealth>();
        PlayerHealthbar.SetMaxHealth(PlayerHealth.MaxHP);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if collides with the door of the store
            //get the storetype of the store
            //set currentStore to store.storeType
    }
}
