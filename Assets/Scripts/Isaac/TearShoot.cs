using UnityEngine;

public class TearShoot : MonoBehaviour
{

    public GameObject tearPrefab;
    public Transform firePoint;
    public float tearSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootTear();
        }
    }

    void ShootTear()
    {
        // Instanciar la l�grima
        GameObject tear = Instantiate(tearPrefab, firePoint.position, firePoint.rotation);

        // Aplicar movimiento a la l�grima
        Rigidbody rb = tear.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * tearSpeed, ForceMode.VelocityChange);
        }
        Destroy(tear, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Lágrima impactó un enemigo");
            //Destroy(other.gameObject); // Mata al enemigo
            //Destroy(gameObject); // Destruye la lágrima
        }
    }


}
