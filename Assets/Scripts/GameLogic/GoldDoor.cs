using UnityEngine;

public class GoldDoor : MonoBehaviour
{
    public GameObject Door;
    public bool roomEntered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (roomEntered)
        {
            Door.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (HUDManager.Instance.keyCount > 0)
        {
            HUDManager.Instance.keyCount--;
            HUDManager.Instance.UpdateKeys(HUDManager.Instance.keyCount);
            Door.SetActive(false);
        }
    }
}
