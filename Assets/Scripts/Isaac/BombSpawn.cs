using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bombPrefab; // Prefab de la bomba
    public Transform dropPoint; // Punto donde aparece la bomba
    public int bomba; // Cantidad de bombas

    void Start() {
        
    }
    void Update()
    {
        bomba = HUDManager.Instance.bombCount;
        if (Input.GetKeyDown(KeyCode.E) && bomba > 0)
        {
            PlaceBomb();
        }
    }

    void PlaceBomb()
    {
        Instantiate(bombPrefab, dropPoint.position, Quaternion.identity);
        bomba--; // Restar una bomba
        HUDManager.Instance.UpdateBombs(bomba);
        Debug.Log("Bomba colocada, bombas restantes: " + bomba);
    }
}

