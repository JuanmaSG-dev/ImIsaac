using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    public List<Room> rooms; // Lista de todas las salas
    public GameObject doorPrefab;
    public List<GameObject> pickupPrefabs; // Cofre o ítem aleatorio

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        CheckActiveRooms();
    }

    public void EnterRoom(int roomID)
    {
        Room room = rooms.Find(r => r.id == roomID);
        if (room == null) return;

        Debug.Log($"Isaac entró en la sala {roomID}");

        // Instanciar puertas
        foreach (Transform puertaPos in room.zonaPuerta)
        {
            GameObject puerta = Instantiate(doorPrefab, puertaPos.position, puertaPos.rotation);
            room.doors.Add(puerta);
        }

        // Activar enemigos
        foreach (GameObject enemy in room.enemigos)
        {
            enemy.SetActive(true);
        }
    }

    public void CheckEnemies(int roomID)
    {
        Room room = rooms.Find(r => r.id == roomID);
        if (room == null) return;

        // Si no hay ningún objeto con el tag "Enemy", entonces la sala está limpia
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            Debug.Log($"Sala {roomID} limpia. Abriendo puertas.");

            foreach (GameObject puerta in room.doors)
            {
                Destroy(puerta);
            }
            room.doors.Clear();

            // Spawn de recompensa
            SpawnPickup(room.pickupSpawnPoint.position);
        }
    }


    void SpawnPickup(Vector3 position)
    {
        if (pickupPrefabs.Count == 0) return;

        // Elegir un pickup aleatorio
        GameObject selectedPickup = pickupPrefabs[Random.Range(0, pickupPrefabs.Count)];

        // Instanciarlo en la posición dada
        Instantiate(selectedPickup, position, Quaternion.identity);
    }

    void CheckActiveRooms()
    {
        foreach (Room room in rooms)
        {
            if (room.doors.Count > 0) // Solo chequear salas que tienen puertas cerradas
            {
                CheckEnemies(room.id);
                
            }
        }
    }

}
