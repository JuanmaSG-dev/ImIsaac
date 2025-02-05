using UnityEngine;

public class Pickups : MonoBehaviour
{
    public string pickupType; // Tipo de objeto
    public float rotationSpeed = 50f; // Velocidad de rotación
    public float floatSpeed = 0.5f; // Velocidad de movimiento vertical
    public float floatAmount = 0.2f; // Amplitud del movimiento vertical
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotar el objeto
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        // Movimiento flotante
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmount, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (pickupType)
            {
                case "Heart":
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    if (playerHealth != null) playerHealth.Heal();
                    break;
                case "Key":
                    HUDManager.Instance.CollectKey();
                    break;
                case "Bomb":
                    HUDManager.Instance.CollectBomb();
                    break;
                case "Penny":
                    HUDManager.Instance.CollectPenny();
                    break;
            }
            Destroy(gameObject, 0.3f);
        }
    }
}
