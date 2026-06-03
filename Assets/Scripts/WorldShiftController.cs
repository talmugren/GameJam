using UnityEngine;
using UnityEngine.InputSystem;

public class WorldShiftController : MonoBehaviour
{
    public GameObject normalLight;
    public GameObject shiftLight;
    public GameObject darkObjects;

    private bool isShift;

    public void OnShiftWorld(InputValue value)
    {
        if (!value.isPressed) return;

        isShift = !isShift;

        normalLight.SetActive(!isShift);
        shiftLight.SetActive(isShift);
        darkObjects.SetActive(isShift);

        Debug.Log("SHIFT MODE: " + isShift);
    }
}