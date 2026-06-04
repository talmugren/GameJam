using UnityEngine;
using UnityEngine.InputSystem;

public class ExitDoor : MonoBehaviour
{
    public GameObject winPanel;

    private bool playerNear;

    void Start()
    {
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!KeyPickup.HasKey)
            {
                Debug.Log("Need Key");
                return;
            }

            winPanel.SetActive(true);

            Time.timeScale = 0f;
        }
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