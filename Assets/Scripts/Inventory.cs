using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemDictionary Items;
    public List<InteractableItem> PlayerInventory = new List<InteractableItem>();
    public List<InteractableItem> ShoppingList = new List<InteractableItem>();
    public List<TMP_Text> ShoppingListText = new List<TMP_Text>();  
    private List<InteractableItem> _RemainingShoppingList = new List<InteractableItem>();
    public int MaxShoppingItems = 3;
    public void AddItem(InteractableItem item)
    {
        PlayerInventory.Add(Items.SearchForItem(item.itemName));
        PlayerInventory.Sort();
        Debug.Log(item.itemName + "added to inventory.");
        UpdateShoppingList(item);

    }

    private void UpdateShoppingList(InteractableItem item)
    {
        InteractableItem tempItem = Items.SearchForItem(item.itemName);
        if (_RemainingShoppingList.Contains(tempItem))
        {
            _RemainingShoppingList.Remove(tempItem);
            Debug.Log($"Player collected {tempItem.itemName} on shopping list");
            if (_RemainingShoppingList.Count == 0)
            {
                Debug.Log($"Player collected all items on Shopping list.");
            }
        }
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
            InteractableItem item = store.ObtainableItems[Random.Range(0, store.ObtainableItems.Count)];
            ShoppingList.Add(item);
            _RemainingShoppingList.Add(Items.SearchForItem(item.itemName));
            ShoppingListText[i].text = item.name;
        }

        ShoppingList.Sort();
        _RemainingShoppingList.Sort();  
    }
}



