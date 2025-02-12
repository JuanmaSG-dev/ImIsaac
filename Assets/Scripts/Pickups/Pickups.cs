using UnityEngine;

public class Pickups : MonoBehaviour
{
    public string pickupType; // Tipo de objeto
    public float rotationSpeed = 50f; // Velocidad de rotación
    public float floatSpeed = 0.5f; // Velocidad de movimiento vertical
    public float floatAmount = 0.2f; // Amplitud del movimiento vertical
    private Vector3 startPos;
    private SpriteRenderer spriteRender;
    public PlayerMovement playerMovement;
    public TearShoot ts;
    public Sprite[] itemSprites; // Array con los sprites de los ítems


    void Start()
    {
        startPos = transform.position;
        spriteRender = GetComponent<SpriteRenderer>();

        if (pickupType == "Item" && itemSprites.Length > 0)
        {
            spriteRender.sprite = itemSprites[Random.Range(0, itemSprites.Length)];
        }
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
                case "Item":
                    string itemName = spriteRender.sprite.name;

                    if (itemName == "SadOnion") ts.tearStats.fireRate = 0.2f;
                    if (itemName == "CricketHead") ts.tearStats.damage = 7;
                    if (itemName == "RoidRage")
                    {
                        ts.tearStats.range = 5;
                        playerMovement.moveSpeed = 5;
                    }
                    break;
            }
            Destroy(gameObject, 0.3f);
        }
    }

}
