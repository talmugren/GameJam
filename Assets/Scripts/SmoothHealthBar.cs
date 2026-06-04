using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    public Slider slider;
    public float speed = 5f;

    private float targetValue;

    void Awake()
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        targetValue = slider.value;
    }

    public void SetHealth(float health)
    {
        targetValue = health;
    }

    void Update()
    {
        if (slider == null) return;

        slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * speed);
    }
}