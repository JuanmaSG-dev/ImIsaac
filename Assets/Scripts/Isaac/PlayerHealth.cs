using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3f; // 3 corazones (cada uno vale 2 de vida)
    public bool isInvulnerable = false;
    public float invulnerabilityDuration = 0.5f;

    public void TakeDamage(float damage)
    {
        if (isInvulnerable) return;

        health -= damage;
        HUDManager.Instance.UpdateHearts(health);
        Debug.Log("Isaac ha sido golpeado. Vida restante: " + health);

        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvulnerabilityTimer());
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

    IEnumerator InvulnerabilityTimer()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }

    void Die()
    {
        Debug.Log("Isaac ha muerto");
        Heal();
        Heal();
        Heal();
        SceneManager.LoadScene("Basement");
    }
}
