using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public GameObject normalLight;
    public GameObject shiftLight;
    public GameObject monster;

    bool isShift = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isShift = !isShift;

            normalLight.SetActive(!isShift);
            shiftLight.SetActive(isShift);
            monster.SetActive(isShift);
        }
    }
}