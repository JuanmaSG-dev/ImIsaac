using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Room : MonoBehaviour
{
    public int id; // ID unico de la sala
    public Transform[] zonaPuerta; // Lugares donde se generaran puertas
    public GameObject[] enemigos; // Lista de enemigos de la sala
    public Transform pickupSpawnPoint; // Punto donde aparece el premio al limpiar la sala
    public List<GameObject> doors = new List<GameObject>(); // Lista de puertas instanciadas
}
