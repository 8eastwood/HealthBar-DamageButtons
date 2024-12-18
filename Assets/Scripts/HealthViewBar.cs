using UnityEngine;
using UnityEngine.UI;

public class HealthViewBar : HealthView
{
    [SerializeField] private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider.minValue = 0;
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.value = _health.MaxHealth;
    }
    private void OnEnable()
    {
        _health.DamageTaken += UpdateHealth;
        _health.Healed += UpdateHealth;
    }

    protected override void UpdateHealth()
    {
        _healthSlider.value = _health.CurrentHealth;
    }
}
