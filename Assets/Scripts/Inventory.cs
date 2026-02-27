using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public PlayerData playerData;
    public List<InteractableItem> PlayerInventory = new List<InteractableItem>();
    public List<InteractableItem> ShoppingList = new List<InteractableItem>();

    public void AddItem(InteractableItem item)
    {
        PlayerInventory.Add(item);
        Debug.Log(item.itemName + "added to inventory.");
    }
    public void RemoveItem(InteractableItem item)
    {
        if (PlayerInventory.Contains(item))
        {
            PlayerInventory.Remove(item);
            Debug.Log(item.itemName + " removed from inventory.");
        }
    }
    public void ShowInventory()
    {
        foreach (var item in PlayerInventory)
        {
            Debug.Log($"Item: {item.itemName} /n");
        }
        //Debug.Log("Inventory: " + string.Join(", ", items));
    }

    public void GenerateShoppingList()
    {
        switch (playerData.currentStore)
        {
            case (Store.StoreType.Supermarket):

                break;

            case (Store.StoreType.Clothes):

                break;

            case (Store.StoreType.Hardware):

                break;

            case (Store.StoreType.None):

                break;
        }
    }
}



