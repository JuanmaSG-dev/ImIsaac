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
        // Instanciar la lágrima
        GameObject tear = Instantiate(tearPrefab, firePoint.position, firePoint.rotation);

        // Aplicar movimiento a la lágrima
        Rigidbody rb = tear.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * tearSpeed, ForceMode.VelocityChange);
        }
    }
}
