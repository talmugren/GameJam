using UnityEngine;
using UnityEngine.InputSystem;

public class DrawerInteract : MonoBehaviour
{
    public Animator drawerAnimator;
    public GameObject keyObject;

    private bool playerNear;
    private bool opened;

    void Start()
    {
        drawerAnimator.enabled = false;

        if (keyObject != null)
            keyObject.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !opened && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!WorldShiftController.IsDarkMode) return;

            opened = true;

            drawerAnimator.enabled = true;
            drawerAnimator.Play("deskDoor", 0, 0f);
        }

        if (opened && keyObject != null)
            keyObject.SetActive(!WorldShiftController.IsDarkMode);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}