using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] private DamageButton _damageDealer;
    [SerializeField] private HealButton _healDealer;
    //[SerializeField] private Button _damageButton;
    //[SerializeField] private Button _healButton;

    //private int _healAmount;
    //private int _damage;

    private void Awake()
    {
        //_damage = _damageDealer.TransferDamage();
        //_healAmount = _healDealer.TransferHealAmount();
    }

    private void OnEnable()
    {
        _damageDealer.ButtonClicked += TakeDamage;
        _healDealer.ButtonClicked += TakeHeal;
    }

    private void OnDisable()
    {
        _damageDealer.ButtonClicked -= TakeDamage;
        _healDealer.ButtonClicked -= TakeHeal;
    }

    virtual protected void UpdateHealth()
    {

    }

    private void TakeDamage()
    {
        _health.TakeDamage(_damageDealer.TransferDamage());
    }

    private void TakeHeal()
    {
        _health.TakeHeal(_healDealer.TransferHealAmount());
    }
}
