using UnityEngine;
using UnityEngine.AI;

public class Gaper : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    private NavMeshAgent agent;
    private EnemyHP enemyHP;

    public GameObject head; // Arrastra aquí el objeto de la cabeza en el Inspector
    private bool isPacer = false; // Controla si ya se transformó

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHP = GetComponent<EnemyHP>();
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

        // Si la vida llega a la mitad y aún no se ha transformado
        if (!isPacer && enemyHP.CurrentHP <= enemyHP.maxHP / 2)
        {
            BecomePacer();
        }
    }

    private void BecomePacer()
    {
        isPacer = true;
        if (head != null)
        {
            head.SetActive(false); // Desactiva la cabeza
        }
        Debug.Log("Gaper se ha convertido en Pacer");
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
