using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDictionary", menuName = "Scriptable Objects/ItemDictionary")]
public class ItemDictionary : ScriptableObject
{
    public Dictionary<string, InteractableItem> Items = new Dictionary<string, InteractableItem>();
    public List<InteractableItem> ItemList = new List<InteractableItem>();
    public void InitialiseDictionary()
    {
        foreach (var item in ItemList)
        {
            Items.Add(item.itemName, item);
        }
    }

    public InteractableItem SearchForItem(string itemName)
    {
        InteractableItem tempItem = null;
        foreach (var kv in Items)
        {
            if (kv.Key == itemName)
            {
                tempItem = kv.Value;
            }

        }
        if (tempItem == null)
        {
            Debug.Log($"Item {itemName} not found");
            return null;
        }
        else
        {
            return tempItem;
        }

    }
}
