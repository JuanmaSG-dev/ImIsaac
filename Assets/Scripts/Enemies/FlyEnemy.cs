/*using UnityEngine;
using UnityEngine.AI;

public class FlyEnemy : MonoBehaviour
{
    public float speed = 3.5f;
    public float hp = 7f;
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tear"))
        {
            Debug.Log("Mosca impactada por una lágrima");
            hp -= 3.5f;
            if (hp <= 0)
            {
                Die();
            }
            //Destroy(gameObject); // La mosca muere con un impacto
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Mosca chocó con Isaac, pero sin empujarlo raro");
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1f);
            // Aquí puedes restar vida sin que el jugador sea empujado
        }
    }

    public void Die() {
        Debug.Log("Mosca ha muerto");
        Destroy(gameObject, 0.3f);
    }

}*/

using UnityEngine;
using UnityEngine.AI;

public class FlyEnemy : MonoBehaviour
{
    public float speed = 3.5f;
    public float hp = 7f;
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

    // Cuando la lágrima golpea
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tear"))
        {
            TakeDamage(3.5f);
            Destroy(other.gameObject); // La lágrima desaparece
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

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Mosca impactada. Vida restante: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Mosca ha muerto");
        Destroy(gameObject, 0.3f);
    }
}

