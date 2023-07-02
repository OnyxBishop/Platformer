using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour
{
    private const float MaxHealth = 100f;

    public float Current { get; private set; }

    public void Initialize()
    {
        Current = MaxHealth;
    }

    public void TryTakeDamage(float damage)
    {
        if (Current >= damage)
        {
            Current = Mathf.Clamp(Current - damage, 0, MaxHealth);
        }
        else
        {
            Current = 0;
            //Hero.Die() 
        }
    }

    public void Heal(float healValue)
    {
        if (Current < MaxHealth)
        {
            Current = Mathf.Clamp(Current + healValue, 0, MaxHealth);
        }
    }
}
