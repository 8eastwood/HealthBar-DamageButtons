using UnityEngine;
using UnityEngine.UI;

public class smoothHealthbar : HealthView
{
    [SerializeField] private Slider _smoothHealthSlider;

    private float _step = 0.1f;

    private void Awake()
    {
        _smoothHealthSlider.minValue = 0;
        _smoothHealthSlider.maxValue = _health.MaxHealth;
        _smoothHealthSlider.value = _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.DamageTaken += UpdateHealth;
        _health.Healed += UpdateHealth;
    }

    private void Update()
    {
        //UpdateHealth();
    }

    protected override void UpdateHealth()
    {
        _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, _health.CurrentHealth, _step);
    }
}
