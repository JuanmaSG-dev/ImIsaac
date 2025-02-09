using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHP;
    private float currentHP;
    public float CurrentHP { get { return currentHP; } } // Nueva propiedad para acceder a la vida actual

    private void Start()
    {
        currentHP = maxHP;
    }



    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log(gameObject.name + " impactado. Vida restante: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " ha muerto");
        Destroy(gameObject, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tear"))
        {
            TearInstance tear = other.GetComponent<TearInstance>();
            if (tear != null)
            {
                TakeDamage(tear.damage); // Recibe el daño de la lágrima
            }

            Destroy(other.gameObject); // La lágrima desaparece
        }
    }

}
