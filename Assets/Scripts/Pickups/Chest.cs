using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator; // Para la animación de apertura
    private bool isOpened = false;
    public float detectionRadius = 2f; // Distancia a la que se activa
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isOpened && Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpened = true;
        animator.SetBool("isOpened", isOpened);
        //animator.SetTrigger("Chest1Open"); // Activa la animación

        // Genera 10 pickups aleatorios
        for (int i = 0; i < 10; i++)
        {
            GiveRandomPickup();
        }

        // Destruir el cofre después de la animación
        Destroy(gameObject, 1f);
    }

    void GiveRandomPickup()
    {
        int randomPickup = Random.Range(0, 4); // 0 = Penny, 1 = Bomb, 2 = Key, 3 = Heart

        switch (randomPickup)
        {
            case 0:
                HUDManager.Instance.CollectPenny();
                break;
            case 1:
                HUDManager.Instance.CollectBomb();
                break;
            case 2:
                HUDManager.Instance.CollectKey();
                break;
            case 3:
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null) playerHealth.Heal();
                break;
        }
    }
}
