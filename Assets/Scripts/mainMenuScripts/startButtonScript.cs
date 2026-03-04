using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData) // detects when the button is clicked
    {
        SceneManager.LoadScene("Andrew"); // switches to Andrew scene
    }
}
