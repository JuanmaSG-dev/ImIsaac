using UnityEngine;
using UnityEngine.AI;

public class MulliganEnemy : MonoBehaviour
{
    public GameObject flyPrefab;  // Prefab de la mosca
    public Transform spawnPoint;  // Lugar donde se generan las moscas
    public float spawnInterval = 2f; // Tiempo entre cada generación de moscas
    public float fleeSpeed = 3.5f; // Velocidad al huir de Isaac
    public float fleeDistance = 5f; // Distancia a la que intenta alejarse

    private Transform player;
    private NavMeshAgent agent;
    private EnemyHP enemyHP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyHP = GetComponent<EnemyHP>();

        if (agent != null)
        {
            agent.speed = fleeSpeed;
        }

        InvokeRepeating(nameof(SpawnFly), spawnInterval, spawnInterval); // Genera moscas cada X segundos
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 fleeDirection = (transform.position - player.position).normalized; // Dirección contraria a Isaac
            Vector3 newPos = transform.position + fleeDirection * fleeDistance;
            agent.SetDestination(newPos);
        }
    }

    void SpawnFly()
    {
        Instantiate(flyPrefab, spawnPoint.position, Quaternion.identity);
    }

    void OnDestroy()
    {
        // Cuando muere, genera 3 moscas
        for (int i = 0; i < 3; i++)
        {
            Instantiate(flyPrefab, transform.position, Quaternion.identity);
        }
    }
}
