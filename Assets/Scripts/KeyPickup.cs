using UnityEngine;
using UnityEngine.InputSystem;

public class KeyPickup : MonoBehaviour
{
    public static bool HasKey = false;

    public AudioSource pickupSound;

    private bool playerNear = false;
    private bool pickedUp = false;

    void Update()
    {
        if (playerNear && !pickedUp && Keyboard.current.eKey.wasPressedThisFrame)
        {
            PickUpKey();
        }
    }

    void PickUpKey()
    {
        pickedUp = true;
        HasKey = true;

        if (pickupSound != null)
            pickupSound.Play();

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}