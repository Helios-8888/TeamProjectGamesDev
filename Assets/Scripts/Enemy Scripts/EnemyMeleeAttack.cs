using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float damage = 10f;
    public float cooldown = 1f;

    Transform Player;
    float nextTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var playerObj = GameObject.FindWithTag("Player");
        if (playerObj) Player = playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player) return;

        float d = Vector3.Distance(transform.position, Player.position);
        if (d > attackRange) return;

        if (Time.time > nextTime)
        {
            nextTime = Time.time + cooldown;

            var hp = Player.GetComponent<EntityHealth>();
            if (hp) hp.DamageHP((int)damage);
        }
    }
}
