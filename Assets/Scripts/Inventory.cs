using System.Collections.Generic;
using Unity.VisualScripting;
<<<<<<< Updated upstream
using UnityEditorInternal;
=======
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
<<<<<<< Updated upstream
    public List<InteractableItem> PlayerInventory = new List<InteractableItem>();
    public List<InteractableItem> ShoppingList = new List<InteractableItem>();
    public int MaxShoppingItems = 3;
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
=======
    public List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log(itemName + "added to inventory.");
    }
    public void RemoveItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log(itemName + " removed from inventory.");
>>>>>>> Stashed changes
        }
    }
    public void ShowInventory()
    {
<<<<<<< Updated upstream
        foreach (var item in PlayerInventory)
        {
            Debug.Log($"Item: {item.itemName} /n");
        }
        //Debug.Log("Inventory: " + string.Join(", ", items));
    }

    public void GenerateShoppingList(Store store)
    {
        for (int i = 0; i < MaxShoppingItems; i++)
        {
            ShoppingList.Add(store.ObtainableItems[Random.Range(0, store.ObtainableItems.Count)]);
        }
            

        //I have this swtich statement setup in case we want to do something specific with each type of store

        //switch (store.storeType)
        //{
        //    case (Store.StoreType.Supermarket):

        //        
        //        break;
        //    case (Store.StoreType.Clothes):

        //        break;

        //    case (Store.StoreType.Hardware):

        //        break;

        //    case (Store.StoreType.None):

        //        break;
        //}
=======
        Debug.Log("Inventory: " + string.Join(", ", items));
>>>>>>> Stashed changes
    }
}



