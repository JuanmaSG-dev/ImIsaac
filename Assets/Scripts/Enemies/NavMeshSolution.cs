using UnityEngine;

public class NavMeshSolution : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position = GetComponent<UnityEngine.AI.NavMeshAgent>().nextPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("La mosca ha chocado con Isaac correctamente.");
        }
    }
}
