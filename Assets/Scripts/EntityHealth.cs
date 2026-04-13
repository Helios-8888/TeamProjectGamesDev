using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] public int MaxHP = 100;
    [SerializeField] protected int _HP;
    public enum Team
    {
        None,
        Player,
        Enemy
    }
    [SerializeField] public Team EntityTeam; //Player on Team 1. Enemies on Team 2
    public int HP
    {
        get {  return _HP; }
    }

    public static int health { get; internal set; }

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
            //Ideally send a message to the animator
        }
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
        //Ideally send a message to the animator
        if (EntityTeam == Team.Player)
        {
            //Set the player to dead.
            SceneManager.LoadScene("Death scene");
            //Disable movement
            //Change the camera
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
