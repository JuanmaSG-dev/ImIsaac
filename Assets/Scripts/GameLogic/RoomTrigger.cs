using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public int roomID; // ID de la sala a la que pertenece este trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (roomID == 20)
            {
                QuestManager.Instance.Secret1 = true;
            } else if (roomID == 21){
                QuestManager.Instance.Secret2 = true;
                GoldDoor goldDoor = other.GetComponent<GoldDoor>();
                goldDoor.roomEntered = true;
            } else {
                Debug.Log("Trigger activado");
                RoomManager.Instance.EnterRoom(roomID);
                Destroy(gameObject); // Elimina el trigger tras activarse
            }
        }
    }
}
