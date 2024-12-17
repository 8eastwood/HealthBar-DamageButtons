using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private DamageButton _damageDealer;
    [SerializeField] private HealButton _healDealer;
    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private Text _textSmoothHealth;
    [SerializeField] private Text _textHealth;

    private string percentSign = "%";
    private float step = 0.5f;
    private int _healAmount;
    private int _damage;

    private void Awake()
    {
        _textHealth.text = DisplayTextHealth();
        _textSmoothHealth.text = DisplayTextHealth();
        _healthSlider.minValue = 0;
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.value = _health.MaxHealth;
        _smoothHealthSlider.minValue = 0;
        _smoothHealthSlider.maxValue = _health.MaxHealth;
        _smoothHealthSlider.value = _health.MaxHealth;
        _damage = _damageDealer.TransferDamage();
        _healAmount = _healDealer.TransferHealAmount();
    }

    private void Update()
    {
        UpdateHealth();
    }

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(TakeDamageButtonClick);
        _healButton.onClick.AddListener(TakeHealButtonClick);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(TakeDamageButtonClick);
        _healButton.onClick.RemoveListener(TakeHealButtonClick);
    }

    private void UpdateHealth()
    {
        _healthSlider.value = _health.CurrentHealth;
        _textHealth.text = DisplayTextHealth();
        _textSmoothHealth.text = DisplayTextHealth();
        _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, _health.CurrentHealth, step);
    }

    private string DisplayTextHealth()
    {
        return _health.CurrentHealth.ToString() + percentSign;
    }

    private void TakeDamageButtonClick()
    {
        _health.TakeDamage(_damage);
    }

    private void TakeHealButtonClick()
    {
        _health.TakeHeal(_healAmount);
    }
}
