using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] private DamageButton _damageDealer;
    [SerializeField] private HealButton _healDealer;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
   
    private int _healAmount;
    private int _damage;

    private void Awake()
    {
        _damage = _damageDealer.TransferDamage();
        _healAmount = _healDealer.TransferHealAmount();
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

    virtual protected void UpdateHealth()
    {

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
