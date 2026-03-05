
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Store", menuName = "Scriptable Objects/Store")]
public class Store : ScriptableObject
{
    //MonoBehaviour might work better? Idk I think there needs to be some OnCollisionEnter SetStore on another script
    public enum StoreType
    {
        None,
        Supermarket,
        Hardware,
        Clothes
    }

    public StoreType storeType;
    public List<InteractableItem> ObtainableItems = new List<InteractableItem>(); 

}
