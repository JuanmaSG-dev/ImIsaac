using UnityEngine;
using UnityEngine.AI;

public class FlyEnemy : MonoBehaviour
{
    public float speed = 3.5f;
    private Transform player;
    private NavMeshAgent agent;
    private EnemyHP enemyHP;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHP = GetComponent<EnemyHP>(); // Referencia al script de vida
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (agent != null)
        {
            agent.speed = speed;
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    // Cuando choca con Isaac
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f);
            }
        }
    }
}
