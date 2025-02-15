using UnityEngine;

public class TearShoot : MonoBehaviour
{
    public Tear tearStats; // Referencia a los atributos de la lágrima
    public GameObject tearPrefab;
    public Transform firePoint;
    
    private float nextFireTime = 0f; // Control de la cadencia
    public AudioClip tearSound;

    void Update()
    {
        // Disparo continuo con cadencia
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            ShootTear();
            nextFireTime = Time.time + tearStats.fireRate; // Establece el próximo disparo
        }
    }

    public void PlayTearSound()
    {
        AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.PlayOneShot(tearSound);
    }

    void ShootTear()
    {
        GameObject tear = Instantiate(tearPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = tear.GetComponent<Rigidbody>();
        PlayTearSound();
        // Asigna el daño de la lágrima
        TearInstance tearInstance = tear.GetComponent<TearInstance>();
        if (tearInstance != null)
        {
            tearInstance.damage = tearStats.damage;
        }

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * tearStats.speed;
        }

        Destroy(tear, tearStats.range); // Destruye la lágrima tras X segundos
    }

}
