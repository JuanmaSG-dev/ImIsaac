using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 3f; // Radio de la explosión
    public float explosionDelay = 3f; // Tiempo antes de explotar
    public float damage = 10f; // Daño que causa

    void Start()
    {
        Invoke("Explode", explosionDelay); // Iniciar la cuenta atrás
    }

    void Explode()
    {
        Debug.Log("¡Bomba explotó!");

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearby in colliders)
        {
            if (nearby.CompareTag("Enemy"))
            {
                Debug.Log("Enemigo alcanzado por explosión");
                FlyEnemy enemy = nearby.GetComponent<FlyEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            else if (nearby.CompareTag("Player"))
            {
                Debug.Log("Isaac alcanzado por explosión");
                PlayerHealth playerHealth = nearby.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1f);
                }
            }
            else if (nearby.CompareTag("Rock"))
            {
                Debug.Log("Roca destruida por explosión");
                Destroy(nearby.gameObject);
            }
        }

        Destroy(gameObject); // Destruir la bomba después de explotar
    }
}
