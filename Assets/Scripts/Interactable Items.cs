using InteractableItems;
using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable, IComparable<InteractableItem>
{
    [SerializeField]
    string interactableMessage;
    public string InteractableMessage => interactableMessage;

    public string itemName;
    public string interactableName => itemName;

    public int ItemCost;
    public void Interact()
    {
        Debug.Log("Interacted with " + itemName);

        //Destroy(gameObject);
    }

    public int CompareTo(InteractableItem otherItem)
    {
        return otherItem.itemName.CompareTo(itemName);
    }
}
