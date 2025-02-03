using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3f; // 3 corazones (cada uno vale 2 de vida)

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Isaac recibió daño. Vida restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Isaac ha muerto");
        // Aquí puedes hacer que aparezca una pantalla de Game Over
    }
}
