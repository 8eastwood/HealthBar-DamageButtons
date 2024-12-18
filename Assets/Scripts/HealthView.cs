using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] private DamageButton _damageDealer;
    [SerializeField] private HealButton _healDealer;

    private void OnEnable()
    {
        _health.DamageTaken += UpdateHealth;
        _health.Healed += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.DamageTaken -= UpdateHealth;
        _health.Healed -= UpdateHealth;
    }

    protected virtual void UpdateHealth()
    {
    }
}
