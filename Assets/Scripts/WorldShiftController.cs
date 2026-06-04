using UnityEngine;
using UnityEngine.InputSystem;

public class WorldShiftController : MonoBehaviour
{
    public GameObject normalLight;
    public GameObject shiftLight;
    public GameObject darkObjects;
    public GameObject darkGrungeOverlay;

    public static bool IsDarkMode { get; private set; }

    public void OnShiftWorld(InputValue value)
    {
        if (!value.isPressed) return;

        IsDarkMode = !IsDarkMode;

        if (normalLight != null) normalLight.SetActive(!IsDarkMode);
        if (shiftLight != null) shiftLight.SetActive(IsDarkMode);
        if (darkObjects != null) darkObjects.SetActive(IsDarkMode);
        if (darkGrungeOverlay != null) darkGrungeOverlay.SetActive(IsDarkMode);
    }
}