using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject enemyTearPrefab;  // Prefab de la lágrima enemiga
    public Transform firePoint;         // Empty desde donde dispara
    public float shootInterval = 2f;    // Cada cuánto dispara
    public float tearSpeed = 10f;       // Velocidad de la lágrima

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(Shoot), shootInterval, shootInterval); // Dispara en bucle
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 lookPos = player.position - transform.position;
            lookPos.y = 0; // Bloquea la rotación en el eje Y para que no se incline
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }

    void Shoot()
    {
        if (player == null) return;

        GameObject tear = Instantiate(enemyTearPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = tear.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = (player.position - firePoint.position).normalized;
            rb.linearVelocity = direction * tearSpeed;
        }
    }
}
