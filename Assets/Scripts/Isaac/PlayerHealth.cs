using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3f; // 3 corazones (cada uno vale 2 de vida)

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Isaac recibió daño. Vida restante: " + health);
        HUDManager.Instance.UpdateHearts(health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal() {
        if (health >= 3f)
        {
            Debug.Log("Tu vida está al máximo.");
        } else {
            health += 1f;
            Debug.Log("Isaac recibió curación. Vida restante: " + health);
            HUDManager.Instance.UpdateHearts(health);
        }
    }

    void Die()
    {
        Debug.Log("Isaac ha muerto");
        Heal();
        Heal();
        Heal();
        this.transform.position = new Vector3(0, 0, 11.0500002f);
    }
}
