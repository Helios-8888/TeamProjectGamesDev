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
    }
}



