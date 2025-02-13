using UnityEngine;

public class EnemyTear : MonoBehaviour
{
    public float damage = 1f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        gameObject.tag = "Enemy"; // Asegura que la lágrima tiene el tag correcto
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
