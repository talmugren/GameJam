using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthSlider;
    public Image fillImage;
    public GameObject gameOverPanel;

    [Header("Player")]
    public FirstPersonInputController playerController;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        UpdateBarColor();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        UpdateBarColor();

        if (currentHealth <= 0)
            Die();
    }

    void UpdateBarColor()
    {
        if (fillImage == null) return;

        float percent = (float)currentHealth / maxHealth;

        if (percent > 0.5f)
        {
            // أخضر غامق
            fillImage.color = new Color32(11, 128, 2, 255);
        }
        else if (percent > 0.25f)
        {
            // برتقالي غامق
            fillImage.color = new Color32(160, 90, 0, 255);
        }
        else
        {
            // أحمر غامق
            fillImage.color = new Color32(120, 0, 0, 255);
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (playerController != null)
            playerController.enabled = false;

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}