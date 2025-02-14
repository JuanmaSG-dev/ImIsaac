using UnityEngine;

public class Monstro : MonoBehaviour
{
    public GameObject enemyTearPrefab; // Prefab de la lágrima enemiga
    public Transform firePoint; // Punto desde donde dispara
    public float attackCooldown = 2f; // Tiempo entre ataques
    public int numberOfTears = 10; // Cantidad de lágrimas por ataque
    public float minTearSpeed = 5f; // Velocidad mínima de la lágrima
    public float maxTearSpeed = 12f; // Velocidad máxima de la lágrima

    private Transform player;
    private float attackTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackTimer = attackCooldown;
    }

    void Update()
    {
        if (player != null)
        {
            // Monstro siempre mira a Isaac
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Evitar que se incline hacia arriba o abajo
            transform.rotation = Quaternion.LookRotation(-direction);
        }

        // Control del tiempo de ataque
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            ShootTears();
            attackTimer = attackCooldown;
        }
    }

    void ShootTears()
    {
        Debug.Log("¡Monstro dispara!");

        for (int i = 0; i < numberOfTears; i++)
        {
            // Dirección base hacia Isaac
            Vector3 directionToPlayer = (player.position - firePoint.position).normalized;

            // Variación aleatoria en el disparo
            Vector3 randomOffset = new Vector3(Random.Range(-0.3f, 0.3f), 0, Random.Range(-0.3f, 0.3f));
            Vector3 finalDirection = (directionToPlayer + randomOffset).normalized;

            // Velocidad aleatoria dentro del rango
            float randomSpeed = Random.Range(minTearSpeed, maxTearSpeed);

            // Instanciar la lágrima
            GameObject tear = Instantiate(enemyTearPrefab, firePoint.position, Quaternion.identity);
            Rigidbody rb = tear.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = finalDirection * randomSpeed;  // La lágrima viaja hacia Isaac con variación
            }

            Destroy(tear, 1.5f); // Destruir la lágrima tras 3 segundos
        }
    }

}
