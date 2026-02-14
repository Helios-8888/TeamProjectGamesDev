using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    [SerializeField] protected Slider _Healthbar;
    [SerializeField] protected TMP_Text _HealthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMaxHealth(int health)
    {
        _Healthbar.maxValue = health;
        _Healthbar.value = health;
        _HealthText.text = $"Health: {_Healthbar.value} / {_Healthbar.maxValue} ";
    }

    // Update is called once per frame
    public void SetHealth(int health)
    {
        _Healthbar.value = health;
        _HealthText.text = $"Health: {_Healthbar.value} / {_Healthbar.maxValue} ";  
    }
}
