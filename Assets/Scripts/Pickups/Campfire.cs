using UnityEngine;

public class Campfire : MonoBehaviour
{
    public bool hasFire = true; // Indica si la fogata tiene fuego o no
    public GameObject fireEffect; // Referencia al objeto de fuego visual
    public GameObject[] pickupPrefabs; // Lista de posibles pickups

    private void Start()
    {
        UpdateFireState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasFire) return; // Si la fogata no tiene fuego, no hace nada

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f);
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            FlyEnemy enemy = other.GetComponent<FlyEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(10f); // O el daño que quieras para los enemigos
            }
        }
        else if (other.CompareTag("Tear"))
        {
            ExtinguishFire();
            Destroy(other.gameObject); // Destruir la lágrima tras impacto
        }
    }

    void ExtinguishFire()
    {
        if (!hasFire) return; // Si ya está apagada, no hacer nada

        hasFire = false;
        UpdateFireState();

        // 10% de probabilidad de soltar un pickup
        if (Random.value <= 0.2f && pickupPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, pickupPrefabs.Length);
            Instantiate(pickupPrefabs[randomIndex], new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
        }
    }

    void UpdateFireState()
    {
        // Activa o desactiva el fuego visual
        if (fireEffect != null)
        {
            fireEffect.SetActive(hasFire);
        }
    }
}
