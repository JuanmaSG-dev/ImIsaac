using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 3f; // Radio de la explosión
    public float explosionDelay = 3f; // Tiempo antes de explotar
    public float damage = 20f; // Daño que causa
    public GameObject explosionEffect;
    public AudioClip explosionSound;

    void Start()
    {
        Invoke("Explode", explosionDelay); // Iniciar la cuenta atrás
    }

    void Explode()
    {
        Debug.Log("¡Bomba explotó!");
        // Play Explosion Sound
        AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSound);
        // Instanciar la explosión en la posición de la bomba
        GameObject Explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearby in colliders)
        {
            if (nearby.CompareTag("Enemy"))
            {
                Debug.Log("Enemigo alcanzado por explosión");
                EnemyHP enemy = nearby.GetComponent<EnemyHP>();
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

        // Destruir la bomba después de explotar
        Destroy(gameObject);
        Destroy(Explosion, 3f); // Destruir la explosión después de 3 segundos
    }

}
