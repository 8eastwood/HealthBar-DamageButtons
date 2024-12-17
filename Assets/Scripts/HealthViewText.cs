using UnityEngine;
using UnityEngine.UI;

public class HealthViewText : HealthView
{
    [SerializeField] private Text _textSmoothHealth;
    [SerializeField] private Text _textHealth;

    private string percentSign = "%";

    private void Awake()
    {
        _textHealth.text = DisplayTextHealth();
        _textSmoothHealth.text = DisplayTextHealth();
    }

    private void Update()
    {
        //UpdateHealth();
    }

    private void OnEnable()
    {
        _health.DamageTaken += UpdateHealth;
        _health.Healed += UpdateHealth;
    }

    protected override void UpdateHealth()
    {
        _textHealth.text = DisplayTextHealth();
        _textSmoothHealth.text = DisplayTextHealth();
    }

    private string DisplayTextHealth()
    {
        return _health.CurrentHealth.ToString() + percentSign;
    }
}
