using System;
using UnityEngine;

public class HeroHealth
{
    public event Action HealthChanged;

    private const float MaxHealth = 100f;

    public HeroHealth()
    {
        Current = MaxHealth;
    }

    public float Current { get; private set; }

    public void TryTakeDamage(float damage)
    {
        Current = Mathf.Clamp(Current - damage, 0, MaxHealth);
        HealthChanged?.Invoke();
    }

    public void Heal(float healValue)
    {
        if (Current < MaxHealth)
        {
            Current = Mathf.Clamp(Current + healValue, 0, MaxHealth);
            HealthChanged?.Invoke();
        }
    }
}
