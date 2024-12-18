using System;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    public int HealAmount { get; private set; } = 10;

    public event Action ButtonClicked;

    public int TransferHealAmount()
    {
        ButtonClicked?.Invoke();
        return HealAmount;
    }
}
