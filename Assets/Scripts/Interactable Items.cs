using InteractableItems;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField]
    string interactableMessage;
    public string InteractableMessage => interactableMessage;

    public string itemName;
    public string interactableName => itemName;
    public void Interact()
    {
        Debug.Log("Interacted with " + itemName);

        Destroy(gameObject);
    }
}
