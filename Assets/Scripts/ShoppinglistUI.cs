using UnityEngine;

public class ShoppingListUI : MonoBehaviour
{
    private bool isVisible = false;

    void Start()
    {
        gameObject.SetActive(false); // start hidden
    }

    public void Toggle()
    {
        isVisible = !isVisible;
        gameObject.SetActive(isVisible);
    }
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
        Toggle();
    }
    }
}
