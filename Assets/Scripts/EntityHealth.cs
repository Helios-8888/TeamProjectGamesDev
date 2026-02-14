using UnityEngine;

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
        //Check if it was the player
        
        if (TryGetComponent<PlayerData>(out PlayerData data))
        {
            //Update the healthbar
            data.PlayerHealthbar.SetHealth(_HP);
        }
        if (IsDead())
        {
            //kill entity
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

    public bool IsDead()
    {
        return _HP <= 0;
    }
}
