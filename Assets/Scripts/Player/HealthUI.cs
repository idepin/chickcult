using DG.Tweening;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private UnityEngine.UI.Slider healthSlider;

    private void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.onHealthChanged += UpdateHealthUI;
            UpdateHealthUI(playerHealth.maxhealth);
        }
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.onHealthChanged -= UpdateHealthUI;
        }
    }

    private void UpdateHealthUI(float health)
    {
        transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0), 0.2f, 10, 0.1f)
            .OnComplete(() => transform.localScale = Vector3.one); // Reset scale after punch effect
        if (healthSlider != null)
        {
            healthSlider.value = health; // Assuming MaxHealth is a property in PlayerHealth
        }
    }
}