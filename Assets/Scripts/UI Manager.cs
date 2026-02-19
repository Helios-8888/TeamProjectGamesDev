using UnityEngine;

public class UIManager : MonoBehaviour
{

    public PlayerHealthbar PlayerHealthbar;
    public EntityHealth PlayerHealth;

    public ShoppingListUI ShoppinglistUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShoppinglistUI.Toggle();
        }
    }

}
