using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool HasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasKey = true;
            gameObject.SetActive(false);

            Debug.Log("Key Collected");
        }
    }
}