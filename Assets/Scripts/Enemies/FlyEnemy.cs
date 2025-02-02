using UnityEngine;
using UnityEngine.AI;

public class FlyEnemy : MonoBehaviour
{
    public float speed = 3.5f;
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
        if (other.CompareTag("Player"))
        {
            Debug.Log("Mosca golpeó al jugador");
            // Aquí puedes llamar a un script para restarle vida a Isaac
        }
        else if (other.CompareTag("Tear"))
        {
            Debug.Log("Mosca impactada por una lágrima");
            //Destroy(gameObject); // La mosca muere con un impacto
        }
    }

}
