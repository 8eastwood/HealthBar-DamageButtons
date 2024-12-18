using UnityEngine;
using UnityEngine.UI;

public class smoothHealthbar : HealthView
{
    [SerializeField] private Slider _smoothHealthSlider;

    private float _step = 0.1f;
    private bool _isWorking = false;

    private void Awake()
    {
        _smoothHealthSlider.minValue = 0;
        _smoothHealthSlider.maxValue = _health.MaxHealth;
        _smoothHealthSlider.value = _health.MaxHealth;
    }

    private void Update()
    {
        if (_smoothHealthSlider.value != _health.CurrentHealth)
        {
            UpdateHealth();
        }
    }

    protected override void UpdateHealth()
    {
        _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, _health.CurrentHealth, _step);
    }
}
