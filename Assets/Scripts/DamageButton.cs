using System;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    public int Damage { get; private set; } = 20;

    public event Action ButtonClicked;

    public int TransferDamage()
    {
        ButtonClicked?.Invoke();
        return Damage;
    }
}
