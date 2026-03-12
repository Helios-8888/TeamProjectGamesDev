using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] public int MaxHP = 100;
    [SerializeField] protected int _HP;
    
    public int HP
    {
        get {  return _HP; }
    }
  
    private void Start()
    {
        _HP = MaxHP;
        
    }

    public void DamageHP(int damage)
    {
        _HP -= damage;

        if (TryGetComponent<PlayerData>(out PlayerData data))
        {
            //Update the healthbar
            data.PlayerHealthbar.SetHealth(_HP);

        }
        //Check if it was the player
        if (_HP <= 0)
        {
            Die();
        }
    }

    public void HealHP(int heal)
    {
        _HP += heal;
        if (TryGetComponent<PlayerData>(out PlayerData data))
        {
            //Update the healthbar
            data.PlayerHealthbar.SetHealth(_HP);
        }
        if (_HP > MaxHP)
        {
            _HP  = MaxHP;
        }
    }


    public void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        if (TryGetComponent<PlayerData>(out PlayerData player))
        {
            SceneManager.LoadScene("Death scene");
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
