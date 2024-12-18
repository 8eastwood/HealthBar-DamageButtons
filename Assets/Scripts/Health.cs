using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealth { get; private set; }
    public int MinHealth { get; private set; } = 0;
    public int MaxHealth { get; private set; } = 100;

    public event Action DamageTaken;
    public event Action Healed;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeHeal(int heal)
    {
        CurrentHealth = Math.Clamp(CurrentHealth + heal, MinHealth, MaxHealth);
        Healed?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = Math.Clamp(CurrentHealth - damage, MinHealth, MaxHealth);
        DamageTaken?.Invoke();
    }
}
