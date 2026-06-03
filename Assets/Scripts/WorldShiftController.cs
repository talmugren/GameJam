using UnityEngine;
using UnityEngine.InputSystem;

public class WorldShiftController : MonoBehaviour
{
    public GameObject normalLight;
    public GameObject shiftLight;
    public GameObject darkObjects;

    private bool isShift = false;

    public void OnShiftWorld(InputValue value)
    {
        isShift = !isShift;

        normalLight.SetActive(!isShift);
        shiftLight.SetActive(isShift);
        darkObjects.SetActive(isShift);
    }
}