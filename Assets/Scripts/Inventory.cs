using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InteractableItem> PlayerInventory = new List<InteractableItem>();
    public List<InteractableItem> ShoppingList = new List<InteractableItem>();
    public int MaxShoppingItems = 3;
    public void AddItem(InteractableItem item)
    {
        PlayerInventory.Add(item);
        PlayerInventory.Sort();
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
    }

    public void GenerateShoppingList(Store store)
    {
        for (int i = 0; i < MaxShoppingItems; i++)
        {
            ShoppingList.Add(store.ObtainableItems[Random.Range(0, store.ObtainableItems.Count)]);
        }
        ShoppingList.Sort();

    }
}



