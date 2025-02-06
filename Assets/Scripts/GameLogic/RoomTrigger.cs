using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public int roomID; // ID de la sala a la que pertenece este trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger activado");
            RoomManager.Instance.EnterRoom(roomID);
            Destroy(gameObject); // Elimina el trigger tras activarse
        }
    }
}
