using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerBody; // Referencia al cuerpo del jugador

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Rotar solo el cuerpo de Isaac en el eje Y (horizontal)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
