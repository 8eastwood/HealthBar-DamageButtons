using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private Text _textSmoothHealth;

    private int _currentHealth;
    private int _maxHealth = 100;
    private int _healAmount = 10;
    private int _damage = 20;
    private float step = 1f;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _textHealth.text = DisplayTextHealth();
        _textSmoothHealth.text = DisplayTextHealth();
        _healthSlider.minValue = 0;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _maxHealth;
        _smoothHealthSlider.minValue = 0;
        _smoothHealthSlider.maxValue = _maxHealth;
        _smoothHealthSlider.value = _maxHealth;
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

    public void TakeHeal(int heal)
    {
        _currentHealth += heal;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    private void UpdateHealth()
    {
        _healthSlider.value = _currentHealth;
        _textHealth.text = DisplayTextHealth();
        _textSmoothHealth.text = DisplayTextHealth();
        _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, _currentHealth, step);
    }

    private string DisplayTextHealth()
    {
        return _currentHealth.ToString() + "%";
    }

    private void TakeDamageButtonClick()
    {
        TakeDamage(_damage);
    }

    private void TakeHealButtonClick()
    {
        TakeHeal(_healAmount);
    }
}
